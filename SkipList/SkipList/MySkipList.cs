// <copyright file="MySkipList.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace SkipList;

using System.Collections;

/// <summary>
/// Represents a generic skip list collection that implements <see cref="IList{T}"/>.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MySkipList<T> : IList<T>
{
    private readonly Random random = new();
    private readonly int maxLevel;
    private readonly Node head;
    private int count;
    private int version;

    /// <summary>
    /// Initializes a new instance of the <see cref="MySkipList{T}"/> class.
    /// </summary>
    public MySkipList()
    {
        this.maxLevel = 20;
        this.head = new Node(default!, this.maxLevel);
        this.count = 0;
        this.version = 0;
    }

    /// <summary>
    /// Gets the number of elements contained in the SkipList.
    /// </summary>
    public int Count => this.count;

    /// <summary>
    /// Gets a value indicating whether the SkipList is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    public T this[int index]
    {
        get
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var currentNode = this.head.Next[0];
            for (var i = 0; currentNode != null && i < index; i++)
            {
                currentNode = currentNode.Next[0];
            }

            if (currentNode == null)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return currentNode.Value;
        }
        set => throw new NotSupportedException();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the SkipList.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> for the SkipList.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var initialVersion = this.version;
        var currentNode = this.head.Next[0];
        while (currentNode != null)
        {
            if (initialVersion != this.version)
            {
                throw new InvalidOperationException("The collection has been changed.");
            }

            yield return currentNode.Value;
            currentNode = currentNode.Next[0];
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the <see cref="MySkipList{T}"/>.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> for the list.</returns>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    /// <summary>
    /// Adds an item to the SkipList.
    /// </summary>
    /// <param name="item">The object to add to the SkipList.</param>
    public void Add(T item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var updateNode = new Node?[this.maxLevel];
        var currentNode = this.head;

        for (var i = this.maxLevel - 1; i >= 0; i--)
        {
            while (currentNode?.Next[i] != null &&
                   Comparer<T>.Default.Compare(currentNode.Next[i]!.Value, item) < 0)
            {
                currentNode = currentNode.Next[i];
            }

            updateNode[i] = currentNode;
        }

        var newLevel = this.RandomLevel();
        var newNode = new Node(item, newLevel);

        for (var i = 0; i < newLevel; i++)
        {
            newNode.Next[i] = updateNode[i]?.Next[i];
            updateNode[i]!.Next[i] = newNode;
        }

        this.count++;
        this.version++;
    }

    /// <summary>
    /// Removes all items from the <see cref="MySkipList{T}"/>.
    /// </summary>
    public void Clear()
    {
        for (var i = 0; i < this.maxLevel; i++)
        {
            this.head.Next[i] = null;
        }

        this.count = 0;
        this.version++;
    }

    /// <summary>
    /// Determines whether the <see cref="MySkipList{T}"/> contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in the list.</param>
    /// <returns><c>true</c> if <paramref name="item"/> is found in the list; otherwise, <c>false</c>.</returns>
    public bool Contains(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        return this.Any(x => Comparer<T>.Default.Compare(x, item) == 0);
    }

    /// <summary>
    /// Copies the entire <see cref="MySkipList{T}"/> to a compatible one-dimensional array,
    /// starting at the specified index of the target array.
    /// </summary>
    /// <param name="array">The one-dimensional array that is the destination of the elements copied from the list.</param>
    /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        if (arrayIndex < 0 || arrayIndex + this.count > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        if (array.Length - arrayIndex < this.count)
        {
            throw new ArgumentException(
                "The number of elements is greater than the available space from arrayIndex to the end of the destination array.");
        }

        var currentNode = this.head.Next[0];
        for (var i = 0; i < this.count; i++)
        {
            array[arrayIndex + i] = currentNode!.Value;
            currentNode = currentNode.Next[0];
        }
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="MySkipList{T}"/>.
    /// </summary>
    /// <param name="item">The object to remove from the list.</param>
    /// <returns><c>true</c> if <paramref name="item"/> was successfully removed; otherwise, <c>false</c>.</returns>
    public bool Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var updateNode = new Node?[this.maxLevel];
        var currentNode = this.head;

        for (var i = this.maxLevel - 1; i >= 0; i--)
        {
            while (currentNode?.Next[i] != null &&
                   Comparer<T>.Default.Compare(currentNode.Next[i]!.Value, item) < 0)
            {
                currentNode = currentNode.Next[i];
            }

            updateNode[i] = currentNode;
        }

        currentNode = currentNode?.Next[0];

        if (currentNode != null && Comparer<T>.Default.Compare(currentNode.Value, item) == 0)
        {
            for (var i = 0; i < this.maxLevel; i++)
            {
                if (updateNode[i]?.Next[i] == currentNode)
                {
                    updateNode[i]!.Next[i] = currentNode.Next[i];
                }
            }

            this.count--;
            this.version++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines the index of a specific item in the SkipList.
    /// </summary>
    /// <param name="item">The object to locate in the SkipList.</param>
    /// <returns>The index of item if found in the list; otherwise, -1.</returns>
    public int IndexOf(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var currentNode = this.head.Next[0];
        var index = 0;

        while (currentNode != null)
        {
            if (Comparer<T>.Default.Compare(currentNode.Value, item) == 0)
            {
                return index;
            }

            currentNode = currentNode.Next[0];
            index++;
        }

        return -1;
    }

    /// <summary>
    /// Inserts an item to the SkipList at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which item should be inserted.</param>
    /// <param name="item">The object to insert into the SkipList.</param>
    public void Insert(int index, T item) => throw new NotSupportedException();

    /// <summary>
    /// Removes the SkipList item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    public void RemoveAt(int index) => throw new NotSupportedException();

    private int RandomLevel()
    {
        var level = 1;
        while (this.random.NextDouble() < 0.5 && level < this.maxLevel)
        {
            level++;
        }

        return level;
    }

    private class Node(T value, int level)
    {
        public T Value { get; } = value;

        public Node?[] Next { get; } = new Node?[level];
    }
}
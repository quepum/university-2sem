// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace NullElementsChecker;

using System.Collections;

/// <summary>
/// Represents a generic singly-linked list.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MyList<T> : IEnumerable<T>
{
    private ListNode<T>? head;
    private int counter;
    private int version;

    /// <summary>
    /// Gets the number of elements contained in the list.
    /// </summary>
    public int Count => this.counter;

    /// <summary>
    /// Adds an item to the end of the list.
    /// </summary>
    /// <param name="data">The object to add to the list.</param>
    public void Add(T data)
    {
        var node = new ListNode<T>(data);
        if (this.head is null)
        {
            this.head = node;
        }
        else
        {
            var currentNode = this.head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = node;
        }

        this.counter++;
        this.version++;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var currentVersion = this.version;
        var currentNode = this.head;
        while (currentNode != null)
        {
            if (currentVersion != this.version)
            {
                throw new InvalidOperationException();
            }

            yield return currentNode.Data;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Returns a non-generic enumerator that iterates through the list.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the list.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
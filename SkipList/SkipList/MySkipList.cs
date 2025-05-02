namespace SkipList;

using System.Collections;

public class MySkipList<T> : IList<T>
{
    private const int MaxLevel = 20;
    private const double P = 0.5;

    private SkipListNode<T> head = new(default!, 0);
    private readonly Random random = new();

    private int level = 0;
    private int size = 0;
    private int version = 0;

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        this.head = new SkipListNode<T>(default!, 0);
        this.level = 0;
        this.size = 0;
        ++this.version;
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count => this.size;

    public bool IsReadOnly => false;

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get
        {
            if (index >= this.size || index < 0)
            {
                throw new IndexOutOfRangeException("Out of range.");
            }

            var currentNode = this.head.Forward[0];
            int counter = 0;
            while (currentNode != null)
            {
                if (counter == index)
                {
                    return currentNode.Key;
                }

                currentNode = currentNode.Forward[0];
                ++counter;
            }

            throw new InvalidOperationException();
        }
        set => throw new NotSupportedException();
    }
}
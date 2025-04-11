// <copyright file="PriorityQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueue;

/// <summary>
/// Implementing a priority queue using a binary heap.
/// </summary>
public class PriorityQueue
{
    private int size;
    private int capacity;
    private int orderCounter;
    private HeapElement[] heap;

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityQueue"/> class.
    /// </summary>
    /// <param name="initialCapacity">Initial capacity.</param>
    public PriorityQueue(int initialCapacity = 16)
    {
        this.capacity = initialCapacity;
        this.heap = new HeapElement[this.capacity];
    }

    private bool Empty => this.size == 0;

    /// <summary>
    /// Adds new element to the queue.
    /// </summary>
    /// <param name="value">Input value.</param>
    /// <param name="priority">Numerical priority.</param>
    public void Enqueue(int value, int priority)
    {
        if (this.size == this.capacity)
        {
            this.ResizeHeap();
        }

        var element = new HeapElement
        {
            Value = value,
            Priority = priority,
            Order = this.orderCounter++,
        };
        this.heap[this.size] = element;
        this.RecoveringAfterAddition(this.size);
        this.size++;
    }

    /// <summary>
    /// Removes the value with the highest priority from the queue.
    /// </summary>
    /// <returns>The value with the highest priority.</returns>
    public int Dequeue()
    {
        if (this.Empty)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var root = this.heap[0];
        this.size--;
        if (this.size > 0)
        {
            this.heap[0] = this.heap[this.size];
            this.RecoveringAfterRemoving(0);
        }

        return root.Value;
    }

    private void ResizeHeap()
    {
        int newCapacity = this.capacity * 2;
        var newArray = new HeapElement[newCapacity];
        Array.Copy(this.heap, newArray, this.size);
        this.heap = newArray;
        this.capacity = newCapacity;
    }

    private void RecoveringAfterAddition(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (this.Compare(this.heap[index], this.heap[parentIndex]) <= 0)
            {
                break;
            }

            this.Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void RecoveringAfterRemoving(int index)
    {
        while (true)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;
            int largestIndex = index;

            if (leftChildIndex < this.size && this.Compare(this.heap[leftChildIndex], this.heap[largestIndex]) > 0)
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < this.size && this.Compare(this.heap[rightChildIndex], this.heap[largestIndex]) > 0)
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex == index)
            {
                break;
            }

            this.Swap(index, largestIndex);
            index = largestIndex;
        }
    }

    private int Compare(HeapElement x, HeapElement y)
    {
        return x.Priority != y.Priority ? x.Priority.CompareTo(y.Priority) : x.Order.CompareTo(y.Order);
    }

    private void Swap(int i, int j)
    {
        (this.heap[i], this.heap[j]) = (this.heap[j], this.heap[i]);
    }

    private class HeapElement
    {
        public int Value { get; init; }

        public int Priority { get; init; }

        public int Order { get; init; }
    }
}
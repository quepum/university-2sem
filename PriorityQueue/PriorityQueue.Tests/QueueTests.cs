// <copyright file="QueueTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueue.Tests;

public class Tests
{
    private PriorityQueue queue;

    [SetUp]
    public void Setup()
    {
        this.queue = new PriorityQueue();
    }

    [Test]
    public void EnqueueAndDequeue_SingleElement_ShouldReturnCorrectValue()
    {
        queue.Enqueue(1, 5);
        int result = queue.Dequeue();
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        Assert.That(ex.Message, Is.EqualTo("The queue is empty."));
    }

    [Test]
    public void EnqueueAndDequeue_MultipleElements_ShouldReturnRightOrder()
    {
        queue.Enqueue(1, 3);
        queue.Enqueue(2, 1);
        queue.Enqueue(3, 2);
        queue.Enqueue(4, 4);

        Assert.That(queue.Dequeue(), Is.EqualTo(4));
        Assert.That(queue.Dequeue(), Is.EqualTo(1));
        Assert.That(queue.Dequeue(), Is.EqualTo(3));
        Assert.That(queue.Dequeue(), Is.EqualTo(2));
    }
}
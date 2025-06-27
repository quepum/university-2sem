// <copyright file="MySkipListTests.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace SkipList.Tests;

public class MySkipListTests
{
    private static readonly int[] Expected = [1, 2, 3];

    private MySkipList<int> skipList;

    [SetUp]
    public void Setup() => this.skipList = [];

    [Test]
    public void Add_ShouldIncreaseCount()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        Assert.That(this.skipList, Has.Count.EqualTo(3));
    }

    [Test]
    public void Remove_ShouldDecreaseCount()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        this.skipList.Remove(2);

        Assert.That(this.skipList, Has.Count.EqualTo(2));
    }

    [Test]
    public void Contains_ShouldReturnTrueForExistingItem()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        Assert.That(this.skipList, Does.Contain(2));
    }

    [Test]
    public void Contains_ShouldReturnFalseForNonExistingItem()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        Assert.That(this.skipList, Does.Not.Contain(4));
    }

    [Test]
    public void Clear_ShouldRemoveAllItems()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        this.skipList.Clear();

        Assert.That(this.skipList, Is.Empty);
    }

    [Test]
    public void IndexOf_ShouldReturnCorrectIndex()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        Assert.That(this.skipList.IndexOf(2), Is.EqualTo(1));
    }

    [Test]
    public void CopyTo_ShouldCopyElementsToArray()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        var array = new int[3];
        this.skipList.CopyTo(array, 0);

        Assert.That(array, Is.EqualTo(Expected));
    }

    [Test]
    public void Add_ShouldHandleLargeNumberOfElements()
    {
        const int count = 50000;

        for (var i = 0; i < count; i++)
        {
            this.skipList.Add(i);
        }

        Assert.That(this.skipList, Has.Count.EqualTo(count));

        const int specificElement = 10000;
        Assert.Multiple(() =>
        {
            Assert.That(this.skipList, Does.Contain(specificElement));
            Assert.That(this.skipList.IndexOf(specificElement), Is.EqualTo(specificElement));
        });
    }

    [Test]
    public void Foreach_ShouldIterateThroughAllElements()
    {
        this.skipList.Add(1);
        this.skipList.Add(2);
        this.skipList.Add(3);

        var list = new List<int>();
        foreach (var item in this.skipList)
        {
            list.Add(item);
        }

        Assert.That(list, Is.EqualTo(Expected));
    }

    [Test]
    public void Insert_ShouldThrowNotSupportedException()
    {
        Assert.That(() => this.skipList.Insert(0, 1), Throws.TypeOf<NotSupportedException>());
    }

    [Test]
    public void RemoveAt_ShouldThrowNotSupportedException()
    {
        Assert.That(() => this.skipList.RemoveAt(0), Throws.TypeOf<NotSupportedException>());
    }
}
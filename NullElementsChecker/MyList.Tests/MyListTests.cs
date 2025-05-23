using NullElementsChecker;

namespace MyList.Tests;

public class Tests
{
    private MyList<int> list;
    private static readonly int[] expected = [1, 2, 3];

    [SetUp]
    public void Setup()
    {
        this.list = new MyList<int>();
    }

    [Test]
    public void Add_ShouldIncreaseCounter()
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.That(list, Has.Count.EqualTo(3));
    }

    [Test]
    public void GetEnumerator_ShouldReturnAllElements()
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);

        var result = this.list.ToList();

        Assert.That(result, Is.EqualTo(expected));
    }
}
using NullElementsChecker;

namespace NullElementsCounter.Tests;

[TestFixture]
public class NullCounterTests
{
    [Test]
    public void CountNulls_IntList_ReturnsCorrectCount()
    {
        var intList = new MyList<int>();
        intList.Add(0);
        intList.Add(1);
        intList.Add(2);
        intList.Add(0);
        intList.Add(3);

        INullElementsChecker intNullChecker = new IntNullChecker();

        var result = NullElementsChecker.NullElementsCounter.CountNulls(intList, intNullChecker);

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void CountNulls_StringList_ReturnsCorrectCount()
    {
        var stringList = new MyList<string?>();
        stringList.Add("");
        stringList.Add("hello");
        stringList.Add("world");
        stringList.Add("");

        INullElementsChecker stringNullChecker = new StrNullChecker();

        var result = NullElementsChecker.NullElementsCounter.CountNulls(stringList, stringNullChecker);

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void CountNulls_EmptyList_ReturnsZero()
    {
        var emptyList = new MyList<int>();
        INullElementsChecker intNullChecker = new IntNullChecker();

        var result = NullElementsChecker.NullElementsCounter.CountNulls(emptyList, intNullChecker);

        Assert.That(result, Is.EqualTo(0));
    }
}
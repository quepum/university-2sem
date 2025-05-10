namespace FunctionalUtils.Tests;

using FunctionalUtilsLibrary;

public class FoldTests
{
    [Test]
    public void Fold_SumNumbers_ReturnsCorrectResult()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        const int correctResult = 15;
        Func<int, int, int> func = (acc, x) => acc + x;
        int result = FunctionalUtils.Fold(numbers, 0, func);

        Assert.That(result, Is.EqualTo(correctResult));
    }

    [Test]
    public void Fold_ConcatenateStrings_ReturnsCorrectResult()
    {
        var strings = new List<string> { "hello", " ", "world" };
        const string correctResult = "hello world";
        Func<string, string, string> func = (acc, s) => acc + s;
        string result = FunctionalUtils.Fold(strings, string.Empty, func);

        Assert.That(result, Is.EqualTo(correctResult));
    }

    [Test]
    public void Fold_MergeListOfLists_ReturnsCorrectResult()
    {
        var listOfLists = new List<List<int>>
        {
            new() { 1, 2 },
            new() { 3, 4 },
        };
        var correctResult = new List<int> { 1, 2, 3, 4 };
        var initialValue = new List<int>();
        Func<List<int>, List<int>, List<int>> func = (acc, list) =>
        {
            acc.AddRange(list);
            return acc;
        };
        var result = FunctionalUtils.Fold(listOfLists, initialValue, func);

        Assert.That(result, Is.EqualTo(correctResult));
    }
}
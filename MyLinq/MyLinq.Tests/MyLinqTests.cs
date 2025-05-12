// <copyright file="MyLinq.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace MyLinq.Tests;

[TestFixture]
public class MyLinqTests
{
    [Test]
    public void GetPrimes_ShouldReturnsFirstFivePrimes()
    {
        var primes = MyLinq.GetPrimes().Take(5).ToList();
        var correctAnswer = new List<int> { 2, 3, 5, 7, 11 };

        Assert.That(correctAnswer, Is.EqualTo(primes));
    }

    [Test]
    public void Take_ShouldCorrectlyReturnsElements()
    {
        var input = new[] { 1, 2, 3, 4, 5 };
        var result = input.Take(3).ToList();
        var correctAnswer = new List<int> { 1, 2, 3 };

        Assert.That(correctAnswer, Is.EqualTo(result));
    }

    [Test]
    public void Take_WithNGreaterThanLength_ShouldReturnsAllElements()
    {
        var input = new[] { "a", "b" };
        var result = input.Take(5).ToList();
        var correctAnswer = new List<string> { "a", "b" };

        Assert.That(correctAnswer, Is.EqualTo(result));
    }

    [Test]
    public void Skip_ShouldSkipsElements()
    {
        var input = new[] { 10, 20, 30, 40 };
        var result = input.Skip(2).ToArray();
        var correctAnswer = new List<int> { 30, 40 };

        Assert.That(correctAnswer, Is.EqualTo(result));
    }

    [Test]
    public void Skip_WithNGreaterThanLength_ShouldReturnsEmpty()
    {
        var input = new[] { "a" };
        var result = input.Skip(2).ToArray();

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void SkipAndTake_Combined_IsCorrectly()
    {
        var input = new[] { 1, 2, 3, 4, 5 };
        var result = input.Skip(1).Take(2).ToArray();
        var correctAnswer = new List<int> { 2, 3 };

        Assert.That(correctAnswer, Is.EqualTo(result));
    }
}
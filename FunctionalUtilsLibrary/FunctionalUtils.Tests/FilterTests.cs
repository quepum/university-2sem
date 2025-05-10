namespace FunctionalUtils.Tests;

using FunctionalUtilsLibrary;

public class FilterTests
{
    [Test]
    [TestCaseSource(nameof(FilterTestCases))]
    public void Filter_FilterData_ShouldReturnCorrectResult<T>(IEnumerable<T> input, IEnumerable<T> expected)
    {
        Func<T, bool> func = x => x switch
        {
            int n => n % 2 == 0,
            string s => s.Length > 3,
            Person p => p.Age > 28,
            List<int> list => list.Count > 0,
            _ => throw new NotSupportedException("The data type is not supported."),
        };

        var result = FunctionalUtils.Filter(input, func);

        Assert.That(result, Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> FilterTestCases()
    {
        var testCases = new List<TestCaseData>
        {
            new(
                new List<int> { 1, 2, 3, 4, 5 },
                new List<int> { 2, 4 }),

            new(
                new List<string> { "apple", "bat", "carrot", "dog" },
                new List<string> { "apple", "carrot" }),

            new(
                new List<Person>
                {
                    new() { Name = "Alice", Age = 30 },
                    new() { Name = "Bob", Age = 25 },
                    new() { Name = "Charlie", Age = 35 },
                },
                new List<Person>
                {
                    new() { Name = "Alice", Age = 30 },
                    new() { Name = "Charlie", Age = 35 },
                }),

            new(
                new List<List<int>>
                {
                    new() { 1, 2 },
                    new(),
                    new() { 3, 4 },
                },
                new List<List<int>>
                {
                    new() { 1, 2 },
                    new() { 3, 4 },
                }),
        };

        return testCases;
    }

    private class Person
    {
        public required string Name { get; init; }

        public int Age { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age);
        }
    }
}
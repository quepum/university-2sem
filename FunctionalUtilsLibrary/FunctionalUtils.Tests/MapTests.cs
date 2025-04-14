namespace FunctionalUtils.Tests;

using FunctionalUtilsLibrary;

public class MapTests
{
    [Test]
    public void Map_EmptyList_ShouldReturnEmptyList()
    {
        Func<int, int> func = x => x * 2;
        var result = FunctionalUtils.Map(new List<int>(), func);
        
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Map_DoublesNumbers_ShouldReturnCorrectResult()
    {
        var numbers = new List<int> { 1, 2, 3 };
        Func<int, int> func = x => x * 2;
        var result = FunctionalUtils.Map(numbers, func);
        
        Assert.That(result, Is.EqualTo(new List<int> { 2, 4, 6 }));
    }
    
    [Test]
    public void Map_ConvertStringsToUppercase_ShouldReturnCorrectResult()
    {
        var strings = new List<string> { "hello", "world" };
        Func<string, string> func = s => s.ToUpper();
        var result = FunctionalUtils.Map(strings, func);
        
        Assert.That(result, Is.EqualTo(new List<string> { "HELLO", "WORLD" }));
    }
    
    [Test]
    public void Map_GetNamesFromPersons_ShouldReturnCorrectResult()
    {
        var people = new List<Person>
        {
            new() { Name = "Alice" },
            new() { Name = "Bob" }
        };
        Func<Person, string> func = p => p.Name;
        var result = FunctionalUtils.Map(people, func);

        Assert.That(result, Is.EqualTo(new List<string> { "Alice", "Bob" }));
    }
    
    [Test]
    public void Map_FlattenListOfLists_ShouldReturnCorrectResult()
    {
        var listOfLists = new List<List<int>>
        {
            new() { 1, 2 },
            new() { 3, 4 }
        };
        Func<List<int>, IEnumerable<int>> func = list => list;
        var result = FunctionalUtils.Map(listOfLists, func).SelectMany(x => x).ToList();

        Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3, 4 }));
    }

    private class Person
    {
        public required string Name { get; init; }
    }
}
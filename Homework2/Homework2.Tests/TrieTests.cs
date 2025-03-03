namespace Homework2.Tests;

public class TrieTests
{
    private static readonly string[] TestData = [string.Empty, "a", "ab", "abc", "abcd", "abcde"];

    private static Trie trie;

    [SetUp]
    public void SetUp()
    {
        trie = new Trie();
    }

    [Test]
    public void Trie_Add_ShouldNotAddDuplicateStrings([ValueSource(nameof(TestData))] string value)
    {
        bool resultOfFirstAdding = trie.Add(value);
        Assert.That(resultOfFirstAdding, Is.EqualTo(true));
        bool resultOfSecondAdding = trie.Add(value);
        Assert.That(resultOfSecondAdding, Is.EqualTo(false));
    }

    [Test]
    public void Trie_Add_And_Trie_Remove_ReturnCorrectValue([ValueSource(nameof(TestData))] string value)
    {
        Assert.Multiple(() =>
        {
            Assert.That(trie.Add(value), Is.EqualTo(true));
            Assert.That(trie.Size, Is.EqualTo(1));
            Assert.That(trie.Remove(value), Is.EqualTo(true));
            Assert.That(trie.Size, Is.EqualTo(0));
        });
    }

    [Test]
    public void Trie_Contains_IsCorrect([ValueSource(nameof(TestData))] string value)
    {
        Assert.That(trie.Contains(value), Is.EqualTo(false));
        trie.Add(value);
        Assert.That(trie.Contains(value), Is.EqualTo(true));
    }

    [Test]
    public void Trie_HowManyStartsWithPrefix_IsCorrect()
    {
        foreach (string element in TestData)
        {
            Assert.Multiple(() =>
            {
                Assert.That(trie.Add(element), Is.EqualTo(true));
                Assert.That(trie.HowManyStartsWithPrefix(element),
                    element == string.Empty ? Is.EqualTo(0) : Is.EqualTo(1));
            });
        }

        int length = TestData.Length;
        for (int i = 0; i < length; i++)
        {
            string element = TestData[i];
            Assert.That(trie.HowManyStartsWithPrefix(element),
                i == 0 ? Is.EqualTo(0) : Is.EqualTo(length - i));
        }
    }
}
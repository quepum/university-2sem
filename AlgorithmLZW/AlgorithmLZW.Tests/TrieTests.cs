namespace AlgorithmLZW.Tests;

public class Tests
{
    private readonly List<byte> testSequence = [1, 2, 3];

    private Trie trie;

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [Test]
    public void AddAndGetCode_ShouldReturnCorrectCode()
    {
        const int expectedCode = 256;
        trie.Add(testSequence, expectedCode);
        int? actualCode = trie.GetCode(testSequence);
        Assert.That(actualCode, Is.EqualTo(expectedCode));
    }

    [Test]
    public void Contains_ShouldReturnTrueForAddedSequence()
    {
        trie.Add(testSequence, 256);
        bool contains = trie.Contains(testSequence);

        Assert.That(contains, Is.True);
    }
    
    [Test]
    public void Contains_ShouldReturnFalseForNonExistentSequence()
    {
        bool contains = trie.Contains(testSequence);
        Assert.That(contains, Is.False);
    }
    
    [Test]
    public void GetCode_ShouldReturnNullForNonExistentSequence()
    {
        int? code = trie.GetCode(testSequence);
        Assert.That(code, Is.Null);
    }
    
    [Test]
    public void InitializeByteCodes_ShouldContainAllByteValues()
    {
        for (int i = 0; i < 256; i++)
        {
            var sequence = new List<byte> { (byte)i };
            Assert.Multiple(() =>
            {
                Assert.That(trie.Contains(sequence), Is.True);
                Assert.That(trie.GetCode(sequence), Is.EqualTo(i));
            });
        }
    }
}
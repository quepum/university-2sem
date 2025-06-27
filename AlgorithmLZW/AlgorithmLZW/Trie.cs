namespace AlgorithmLZW;

/// <summary>
/// Trie adapted for LZW algorithm.
/// </summary>
public class Trie
{
    private readonly TrieNode root = new();

    /// <summary>
    /// Initializing the Trie with byte codes.
    /// </summary>
    /// <returns>Initialized Trie.</returns>
    public Trie InitializeByteCodes()
    {
        Trie trie = new();
        for (int i = 0; i < 256; i++)
        {
            trie.Add([(byte)i], i);
        }

        return trie;
    }

    /// <summary>
    /// Add sequence of bytes to the Trie.
    /// </summary>
    /// <param name="sequence">Sequence of bytes.</param>
    /// <param name="code">Code.</param>
    public void Add(IEnumerable<byte> sequence, int code)
    {
        var node = this.root;
        foreach (byte item in sequence)
        {
            if (!node.Children.TryGetValue(item, out var child))
            {
                child = new TrieNode();
                node.Children[item] = child;
            }

            node = child;
        }

        node.Code = code;
    }

    /// <summary>
    /// Checking for a sequence in the Trie.
    /// </summary>
    /// <param name="sequence">Sequence of bytes.</param>
    /// <returns>True if the sequence is in the Trie, otherwise false. </returns>
    public bool Contains(IEnumerable<byte> sequence)
    {
        var node = this.root;
        foreach (byte item in sequence)
        {
            if (!node.Children.TryGetValue(item, out var child))
            {
                return false;
            }

            node = child;
        }

        return node.Code.HasValue;
    }

    /// <summary>
    /// Get code of byte sequence.
    /// </summary>
    /// <param name="sequence">Sequence of bytes.</param>
    /// <returns>Code for sequence.</returns>
    public int? GetCode(IEnumerable<byte> sequence)
    {
        var node = this.root;
        foreach (byte item in sequence)
        {
            if (!node.Children.TryGetValue(item, out var child))
            {
                return null;
            }

            node = child;
        }

        return node.Code;
    }

    private class TrieNode
    {
        public Dictionary<byte, TrieNode> Children { get; } = new();

        public int? Code { get; set; }
    }
}
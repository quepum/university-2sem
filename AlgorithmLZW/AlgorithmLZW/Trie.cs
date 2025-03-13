namespace AlgorithmLZW;

public class Trie
{
    private readonly TrieNode root = new();

    public Trie InitializeByteCodes()
    {
        Trie trie = new();
        for (int i = 0; i < 256; i++)
        {
            trie.Add([(byte)i], i);
        }

        return trie;
    }

    // Добавление последовательности в дерево
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

    // Проверка наличия последовательности в дереве
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

    // Получение кода для последовательности
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
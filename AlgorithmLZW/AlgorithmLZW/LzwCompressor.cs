namespace AlgorithmLZW;

public static class LzwCompression
{
    public static void Compress(string inputFilePath)
    {
        byte[] inputData = File.ReadAllBytes(inputFilePath);

        var trie = new Trie().InitializeByteCodes();
        List<int> compressed = [];

        int startCode = 256;
        List<byte> current = [];

        foreach (byte item in inputData)
        {
            var next = new List<byte>(current) { item };

            if (trie.Contains(next))
            {
                current = next;
            }
            else
            {
                int currentCode = trie.GetCode(current).Value;
                compressed.Add(currentCode);

                trie.Add(next, startCode);
                startCode++;
                current = [item];
            }
        }

        if (current.Count > 0)
        {
            int currentCode = trie.GetCode(current).Value;
            compressed.Add(currentCode);
        }

        string outputFilePath = Path.ChangeExtension(inputFilePath, ".zipped");
        using (var writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
        {
            foreach (int code in compressed)
            {
                writer.Write(code);
            }
        }

        Console.WriteLine($"Compressed file saved as: {outputFilePath}");
    }
}
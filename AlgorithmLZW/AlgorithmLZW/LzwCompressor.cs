namespace AlgorithmLZW;

/// <summary>
/// LZW compressor.
/// </summary>
public static class LzwCompression
{
    /// <summary>
    /// Compress method.
    /// </summary>
    /// <param name="inputFilePath">The path for the incoming file.</param>
    public static void Compress(string inputFilePath)
    {
        byte[] inputData = File.ReadAllBytes(inputFilePath);
        int inputDataSize = inputData.Length;

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

        int compressedDataSize = compressed.Count;

        string outputFilePath = Path.ChangeExtension(inputFilePath, ".zipped");
        using (var writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
        {
            foreach (int code in compressed)
            {
                writer.Write(code);
            }
        }

        Console.WriteLine($"Input data size {inputDataSize} bytes\n" +
                          $"Compressed data size {compressedDataSize} bytes\n" +
                          $"Compression rate {(float)inputDataSize / compressedDataSize}");

        Console.WriteLine($"Compressed file saved as: {outputFilePath}");
    }
}
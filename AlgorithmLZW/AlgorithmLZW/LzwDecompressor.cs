namespace AlgorithmLZW;

/// <summary>
/// LZW decompressor.
/// </summary>
public static class LzwDecompression
{
    /// <summary>
    /// Decompress method.
    /// </summary>
    /// <param name="compressedFilePath">The path for the file with compressed data.</param>
    /// <exception cref="Exception"></exception>
    public static void Decompress(string compressedFilePath)
    {
        List<int> compressed = [];
        using (var reader = new BinaryReader(File.Open(compressedFilePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                compressed.Add(reader.ReadInt32());
            }
        }

        Dictionary<int, List<byte>> dictionary = new();
        for (int i = 0; i < 256; i++)
        {
            dictionary[i] = [(byte)i];
        }

        int code = 256;
        var previous = dictionary[compressed[0]];
        List<byte> result = [..previous];

        for (int i = 1; i < compressed.Count; i++)
        {
            int currentCode = compressed[i];
            List<byte> entry;

            if (dictionary.TryGetValue(currentCode, out var value))
            {
                entry = value;
            }
            else if (currentCode == dictionary.Count)
            {
                entry =
                [
                    ..previous,
                    previous[0]
                ];
            }
            else
            {
                throw new Exception("Decompression error");
            }

            result.AddRange(entry);
            dictionary[code++] = [..previous, entry[0]];
            previous = entry;
        }

        string outputFilePath = Path.ChangeExtension(compressedFilePath, string.Empty);
        File.WriteAllBytes(outputFilePath, result.ToArray());

    Console.WriteLine($"Decompressed file saved as: {outputFilePath}");
}
}
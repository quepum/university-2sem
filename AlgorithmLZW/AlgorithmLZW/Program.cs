// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AlgorithmLZW;

if (args.Length == 0)
{
    Console.WriteLine("Error: input without filepath");
    return;
}

string filePath = args[0];
string key = args[1];
try
{
    if (!File.Exists(filePath))
    {
        Console.WriteLine("No such file");
        return;
    }

    switch (key)
    {
        case "-c":
            LzwCompression.Compress(filePath);
            Console.WriteLine("Successful compression");
            break;
        case "-u":
            LzwDecompression.Decompress(filePath);
            Console.WriteLine("Successful decompression");
            break;
        default:
            throw new ArgumentException($"Unknown parameter: {key}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AlgorithmLZW;

if (args.Length == 0)
{
    Console.WriteLine("Ошибка: не указан путь к файлу");
    return;
}

string filePath = args[0];
string key = args[1];
try
{
    if (!File.Exists(filePath))
    {
        Console.WriteLine("Файл не найден");
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
    Console.WriteLine($"Ошибка: {ex.Message}");
}

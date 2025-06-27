// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using ParsingTree;

string filePath = args[0];
try
{
    if (!File.Exists(filePath))
    {
        throw new FileNotFoundException("No such file");
    }

    string expression = File.ReadAllText(filePath).Trim();
    var parser = new Parser(expression);
    var root = parser.Parse();
    Console.WriteLine(root.Print());
    Console.WriteLine(root.Evaluate());
}
catch (FileNotFoundException e)
{
    Console.WriteLine($"Error: {e.Message}");
}
catch (DivideByZeroException e)
{
    Console.WriteLine($"Error: {e.Message}");
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Error: {e.Message}");
}
catch (FormatException e)
{
    Console.WriteLine($"Error: {e.Message}");
}
catch (ArgumentException e)
{
    Console.WriteLine($"Error: {e.Message}");
}
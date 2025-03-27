// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

string inputFilePath = args[0];
string outputFilePath = args[1];

try
{
    var generator = new ConfigurationGenerator(inputFilePath);
    generator.WriteOutput(outputFilePath);
}
catch (FileNotFoundException exception)
{
    Console.WriteLine($"File not found: {exception.FileName}");
    return 1;
}
catch (NullGraphException exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}
catch (NetworkDisconnectedException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
catch (FormatException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Unknown error: {ex.Message}");
}

return 0;
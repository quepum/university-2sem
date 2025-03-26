// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

try
{
    const string inputFilePath = @"C:\Users\Алина\RiderProjects\university-2sem\Routers\Routers\inputData.txt";
    string outputFilePath = @"C:\Users\Алина\RiderProjects\university-2sem\Routers\Routers\outputData.txt";
    var generator = new ConfigurationGenerator(inputFilePath);
}
catch (NetworkNotConnectedException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
catch (FormatException ex)
{
    Console.Error.WriteLine($"Data format error: {ex.Message}");
    return 2;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Unknown error: {ex.Message}");
}

return 0;
// <copyright file="ConfigGeneratorTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers.Tests;

public class Tests
{
    private string CreateTempFile(string data)
    {
        string tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, data);
        return tempFile;
    }

    [Test]
    public void SimpleConnectedNetworkTest()
    {
        const string inputData = @"1: 2(9)";

        string tempInputFile = this.CreateTempFile(inputData);
        string tempOutputFile = Path.GetTempFileName();

        var generator = new ConfigurationGenerator(tempInputFile);
        generator.WriteOutput(tempOutputFile);

        string[] outputData = File.ReadAllLines(tempOutputFile);
        Assert.That(outputData, Has.Member("1: 2 (9)"));

        File.Delete(tempInputFile);
        File.Delete(tempOutputFile);
    }

    [Test]
    public void NormalDataTest()
    {
        const string inputData = """
                                 1: 2 (10), 3 (9), 4 (8), 5 (7)
                                 2: 1 (10), 3 (6)
                                 3: 1 (9), 2 (6), 4 (5)
                                 4: 1 (8), 3 (5), 5 (4)
                                 5: 1 (7), 4 (4)
                                 """;

        string tempInputFile = CreateTempFile(inputData);
        string tempOutputFile = Path.GetTempFileName();

        var generator = new ConfigurationGenerator(tempInputFile);
        generator.WriteOutput(tempOutputFile);

        string[] outputData = File.ReadAllLines(tempOutputFile);
        Assert.That(outputData, Has.Member("1: 2 (10), 3 (9), 4 (8), 5 (7)"));

        File.Delete(tempInputFile);
        File.Delete(tempOutputFile);
    }

    [Test]
    public void DisconnectedNetworkTest()
    {
        const string inputContent = """
                                    1: 2 (10)
                                    3: 4 (5)
                                    """;
        string tempInput = CreateTempFile(inputContent);
        try
        {
            Assert.That(() => new ConfigurationGenerator(tempInput), Throws.TypeOf<NetworkDisconnectedException>());
        }
        finally
        {
            File.Delete(tempInput);
        }
    }

    [Test]
    public void NullGraphTest()
    {
        const string inputContent = "";
        string tempInput = CreateTempFile(inputContent);
        try
        {
            Assert.That(() => new ConfigurationGenerator(tempInput), Throws.TypeOf<NullGraphException>());
        }
        finally
        {
            File.Delete(tempInput);
        }
    }

    [Test]
    public void WrongFormatDataTest()
    {
        const string inputContent = """
                                    1: 2 (10)
                                    3: 4: 5
                                    """;
        string tempInput = CreateTempFile(inputContent);
        try
        {
            Assert.That(() => new ConfigurationGenerator(tempInput), Throws.TypeOf<FormatException>());
        }
        finally
        {
            File.Delete(tempInput);
        }
    }
}
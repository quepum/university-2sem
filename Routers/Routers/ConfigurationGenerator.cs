// <copyright file="ConfigurationGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Network Configuration Generator.
/// </summary>
public class ConfigurationGenerator
{
    private readonly Dictionary<int, List<(int, int)>> topology;
    private readonly Dictionary<int, List<(int, int)>> resultTopology;
    private int totalCapacity;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationGenerator"/> class.
    /// </summary>
    /// <param name="path">geg.</param>
    public ConfigurationGenerator(string path)
    {
        this.topology = new Dictionary<int, List<(int, int)>>();
        this.resultTopology = new Dictionary<int, List<(int, int)>>();
        this.ParseTopology(path);

        // Генерируем конфигурацию
        // GenerateMaxSpanningTree();
    }

    /// <summary>
    /// Parses the input file with the network topology.
    /// </summary>
    /// <param name="inputPath">The path to the input file.</param>
    private void ParseTopology(string inputPath)
    {
        foreach (string line in File.ReadAllLines(inputPath))
        {
            string trimmedString = line.Trim();
            if (string.IsNullOrEmpty(trimmedString))
            {
                continue;
            }

            string[] parts = trimmedString.Split(':');

            int router = int.Parse(parts[0]);
            var connections = parts[1].Trim().Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(item =>
                {
                    string[] neighbourPart = item.Trim().Split('(', 2);
                    int neighbour = int.Parse(neighbourPart[0]);
                    int capacity = int.Parse(neighbourPart[1].TrimEnd(')'));
                    return (neighbour, capacity);
                })
                .Where(c => c.neighbour > router)
                .ToList();
            this.topology[router] = connections;
        }

        ShowGraphContent(this.topology);
    }

    private static void ShowGraphContent(Dictionary<int, List<(int, int)>> graph)
    {
        foreach (var node in graph)
        {
            Console.WriteLine($"{node.Key}:");
            string edgesString = string.Join(", ", node.Value.Select(edge => $"{edge.Item1} ({edge.Item2})"));

            Console.WriteLine(edgesString);
        }
    }
}
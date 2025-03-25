// <copyright file="ConfigurationGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Network Configuration Generator.
/// </summary>
public class ConfigurationGenerator
{
    private List<(int, int, int)> topology;
    private SortedList<int, List<(int, int)>> resultTopology;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationGenerator"/> class.
    /// </summary>
    /// <param name="path">geg.</param>
    public ConfigurationGenerator(string path)
    {
        this.topology = [];
        this.resultTopology = new SortedList<int, List<(int, int)>>();

        // Парсим входные данные
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
        var vertices = new HashSet<int>();
        var edges = new HashSet<(int, int, int)>();

        foreach (string line in File.ReadAllLines(inputPath))
        {
            string trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed))
            {
                continue;
            }

            string[] parts = trimmed.Split(':', 2);
            int router = int.Parse(parts[0].Trim());
            vertices.Add(router);

            string[] connections = parts[1].Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (string conn in connections)
            {
                string[] neighborPart = conn.Trim().Split(['(', ')'], StringSplitOptions.RemoveEmptyEntries);
                int neighbor = int.Parse(neighborPart[0]);
                int capacity = int.Parse(neighborPart[1]);

                // Добавляем ребра в отсортированном виде (u < v)
                var sorted = (Math.Min(router, neighbor), Math.Max(router, neighbor), capacity);
                edges.Add(sorted);
            }
        }

        this.topology = edges.ToList();
    }
}
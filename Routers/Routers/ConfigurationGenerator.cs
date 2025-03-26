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
    /// <param name="path">A path to the input data file.</param>
    public ConfigurationGenerator(string path)
    {
        this.topology = new Dictionary<int, List<(int, int)>>();
        this.resultTopology = new Dictionary<int, List<(int, int)>>();
        this.ParseTopology(path);
        this.GenerateMaxSpanningTree();
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
    }

    private void GenerateMaxSpanningTree()
    {
        var edges = this.topology
            .SelectMany(routerEntry =>
                routerEntry.Value.Select(conn => (routerEntry.Key, conn.Item1, conn.Item2)))
            .OrderByDescending(e => e.Item3)
            .ToList();

        var allVertices = new HashSet<int>(this.topology.Keys);
        foreach ((int u, int v, int _) in edges)
        {
            allVertices.Add(u);
            allVertices.Add(v);
        }

        var dsu = new Dsu(allVertices);
        var mst = new List<(int, int, int)>();

        foreach ((int u, int v, int w) in edges)
        {
            if (dsu.Find(u) != dsu.Find(v))
            {
                dsu.Union(u, v);
                mst.Add((u, v, w));
                if (mst.Count == allVertices.Count - 1)
                {
                    break;
                }
            }
        }

        if (mst.Count != allVertices.Count - 1)
        {
            throw new NetworkNotConnectedException();
        }

        foreach (int vertex in allVertices)
        {
            this.resultTopology[vertex] = [];
        }

        foreach ((int u, int v, int w) in mst)
        {
            if (u < v)
            {
                this.resultTopology[u].Add((v, w));
            }
            else
            {
                this.resultTopology[v].Add((u, w));
            }
        }

        this.totalCapacity = mst.Sum(e => e.Item3);
    }
}
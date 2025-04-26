// <copyright file="DSU.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// A data structure for managing graph connectivity components.
/// </summary>
public class Dsu
{
    private readonly Dictionary<int, int> parent = new();
    private readonly Dictionary<int, int> rank = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Dsu"/> class.
    /// </summary>
    /// <param name="vertices">A list of graph vertices.</param>
    public Dsu(IEnumerable<int> vertices)
    {
        foreach (int v in vertices)
        {
            this.parent[v] = v;
            this.rank[v] = 0;
        }
    }

    /// <summary>
    /// Finding the root of a set for a given vertex.
    /// </summary>
    /// <param name="u">The vertex to search for.</param>
    /// <returns>The root of the set to which the vertex belongs.</returns>
    public int Find(int u)
    {
        if (this.parent[u] != u)
        {
            this.parent[u] = this.Find(this.parent[u]);
        }

        return this.parent[u];
    }

    /// <summary>
    /// Union of two sets containing vertices u and v.
    /// </summary>
    /// <param name="u">The first vertex.</param>
    /// <param name="v">The second vertex.</param>
    public void Union(int u, int v)
    {
        int rootU = this.Find(u);
        int rootV = this.Find(v);

        if (rootU == rootV)
        {
            return;
        }

        if (this.rank[rootU] > this.rank[rootV])
        {
            this.parent[rootV] = rootU;
        }
        else
        {
            this.parent[rootU] = rootV;
            if (this.rank[rootU] == this.rank[rootV])
            {
                this.rank[rootV]++;
            }
        }
    }
}
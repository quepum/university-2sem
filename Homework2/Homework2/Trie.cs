// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework2;

/// <summary>
/// Prefix tree data structure.
/// </summary>
public class Trie
{
    private readonly Node root;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.root = new Node();
        this.size = 0;
    }

    /// <summary>
    /// Gets the number of strings in the trie.
    /// </summary>
    public int Size => this.size;

    /// <summary>
    /// Adds new element to the trie.
    /// </summary>
    /// <param name="element">The string to add.</param>
    /// <returns>True if no such string has been added yet, otherwise false.</returns>
    public bool Add(string element)
    {
        var currentNode = this.root ?? throw new ArgumentNullException(nameof(element));
        foreach (char item in element)
        {
            if (!currentNode.Children.TryGetValue(item, out var child))
            {
                child = new Node();
                currentNode.Children[item] = child;
            }

            currentNode = child;
            currentNode.Counter++;
        }

        if (currentNode.IsEndOfTheWord)
        {
            return false;
        }

        currentNode.IsEndOfTheWord = true;
        this.size++;

        return true;
    }

    /// <summary>
    /// Checks whether the string is contained in the trie.
    /// </summary>
    /// <param name="element">The string to be found.</param>
    /// <returns>True if the string is contained in the trie, otherwise false.</returns>
    public bool Contains(string element)
    {
        var currentNode = this.root ?? throw new ArgumentNullException(nameof(element));
        foreach (char item in element)
        {
            if (!currentNode.Children.TryGetValue(item, out var child))
            {
                return false;
            }

            currentNode = child;
        }

        return currentNode.IsEndOfTheWord;
    }

    /// <summary>
    /// Removes string from the trie.
    /// </summary>
    /// <param name="element">The string to remove.</param>
    /// <returns>True if the string was in the trie before removing, otherwise false.</returns>
    public bool Remove(string element)
    {
        if (!this.Contains(element))
        {
            return false;
        }

        this.Remover(this.root, element, 0);
        this.size--;
        return true;
    }

    /// <summary>
    /// Counts how many strings start with a given prefix.
    /// </summary>
    /// <param name="prefix">Given prefix.</param>
    /// <returns>The number of strings that start with a given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        return this.GetPrefixCount(this.root, prefix, 0);
    }

    private int GetPrefixCount(Node currentNode, string prefix, int index)
    {
        if (currentNode is null || index == prefix.Length)
        {
            return currentNode?.Counter ?? 0;
        }

        char item = prefix[index];
        return !currentNode.Children.TryGetValue(item, out var child)
            ? 0
            : this.GetPrefixCount(child, prefix, index + 1);
    }

    private bool Remover(Node currentNode, string element, int index)
    {
        if (index == element.Length)
        {
            if (!currentNode.IsEndOfTheWord)
            {
                return false;
            }

            currentNode.IsEndOfTheWord = false;
            return currentNode.Children.Count == 0;
        }

        char item = element[index];
        if (!currentNode.Children.TryGetValue(item, out var childNode))
        {
            return false;
        }

        if (this.Remover(childNode, element, index + 1))
        {
            currentNode.Children.Remove(item);
            return !currentNode.IsEndOfTheWord && currentNode.Children.Count == 0;
        }

        return false;
    }

    private class Node
    {
        public int Counter { get; set; }

        public bool IsEndOfTheWord { get; set; }

        public Dictionary<char, Node> Children { get; } = new();
    }
}
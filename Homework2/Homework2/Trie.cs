// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework2;

/// <summary>
/// vdgebbr.
/// </summary>
public class Trie
{
    private readonly Node? root;
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
    /// Gets the number of words in the trie.
    /// </summary>
    public int Size => this.size;

    /// <summary>
    /// Adds new element to the trie.
    /// </summary>
    /// <param name="element">The string to add.</param>
    /// <returns>True if no such string has been added yet, otherwise false.</returns>
    public bool Add(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            throw new AggregateException("String is empty");
        }

        var current = this.root;
        bool isNewWord = false;
        if (current is not null)
        {
            foreach (char item in element)
            {
                if (!current.Children.TryGetValue(item, out var value))
                {
                    value = new Node();
                    current.Children[item] = value;
                    isNewWord = true;
                }

                current = value;
                current.Counter++;
            }

            if (!current.IsEndOfTheWord)
            {
                current.IsEndOfTheWord = true;
                this.size++;
                return true;
            }
        }

        return isNewWord;
    }

    private class Node
    {
        public int Counter { get; set; }

        public bool IsEndOfTheWord { get; set; }

        public Dictionary<char, Node> Children { get; } = new();
    }
}
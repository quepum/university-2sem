// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Abstract base class for all nodes in the expression parse tree.
/// Each node represents a part of an arithmetic expression:
/// either an operator or an operand.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Evaluates the value of the current node in the tree.
    /// </summary>
    /// <returns>An integer representing the result of evaluating the node.</returns>
    public abstract int Evaluate();

    /// <summary>
    /// Returns a string representation of the current node in the tree.
    /// </summary>
    /// <returns>A string representation of the node in a human-readable format.</returns>
    public abstract string Print();
}
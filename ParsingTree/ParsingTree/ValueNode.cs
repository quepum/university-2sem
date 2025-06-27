// <copyright file="ValueNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// This class represents a numeric operand.
/// </summary>
public class ValueNode(int value) : Node
{
    /// <summary>
    /// Returns the value of a number.
    /// </summary>
    /// <returns>The numeric value of the node.</returns>
    public override int Evaluate()
    {
        return value;
    }

    /// <summary>
    /// Converting a number to a string.
    /// </summary>
    /// <returns>The numeric value of the node in string format.</returns>
    public override string Print()
    {
        return value.ToString();
    }
}
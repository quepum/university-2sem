// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Parses an arithmetic expression in prefix notation and builds a parse tree.
/// </summary>
public class Parser
{
    private readonly string[] tokens;
    private int index;

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class.
    /// </summary>
    /// <param name="input">The input string representing the arithmetic expression in prefix notation.</param>
    public Parser(string input)
    {
        input = input.Replace("(", " ( ").Replace(")", " ) ");
        this.tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        this.index = 0;
    }

    /// <summary>
    /// Parses the input expression and constructs the parse tree.
    /// </summary>
    /// <returns>The root node of the parse tree.</returns>
    public Node Parse()
    {
        if (this.index >= this.tokens.Length)
        {
            throw new FormatException("Incorrect expression format");
        }

        string token = this.tokens[this.index++];
        if (token[0] == '(')
        {
            if (this.index >= this.tokens.Length)
            {
                throw new FormatException("Incorrect expression format");
            }

            char operation = this.tokens[this.index++][0];
            var left = this.Parse();
            var right = this.Parse();

            if (this.index >= this.tokens.Length || this.tokens[this.index++] != ")")
            {
                throw new FormatException("Incorrect expression format");
            }

            if (int.TryParse(token.TrimEnd(')'), out int value))
            {
                return new ValueNode(value);
            }

            return new OperatorNode(operation, left, right);
        }

        if (int.TryParse(token, out int number))
        {
            return new ValueNode(number);
        }

        throw new FormatException($"Incorrect expression format: {token}");
    }
}
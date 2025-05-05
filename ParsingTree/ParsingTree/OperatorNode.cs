// <copyright file="OperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree
{
    /// <summary>
    /// Represents an operator node in the expression parse tree.
    /// </summary>
    public class OperatorNode : Node
    {
        private readonly char operation;
        private readonly Node left;
        private readonly Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="operation">The arithmetic operator ('+', '-', '*', '/').</param>
        /// <param name="left">The left operand of the operator.</param>
        /// <param name="right">The right operand of the operator.</param>
        public OperatorNode(char operation, Node left, Node right)
        {
            if (!"+-*/".Contains(operation))
            {
                throw new ArgumentException($"Unknown operation: {operation}");
            }

            this.operation = operation;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Evaluates the value of the operator node by recursively evaluating its left and right operands.
        /// </summary>
        /// <returns>The result of applying the operator to the evaluated operands.</returns>
        public override int Evaluate()
        {
            int leftValue = this.left.Evaluate();
            int rightValue = this.right.Evaluate();

            switch (this.operation)
            {
                case '+': return leftValue + rightValue;
                case '-': return leftValue - rightValue;
                case '*': return leftValue * rightValue;
                case '/':
                    if (rightValue == 0)
                    {
                        throw new DivideByZeroException("Division by zero");
                    }

                    return leftValue / rightValue;
                default:
                    throw new InvalidOperationException("Incorrect operation");
            }
        }

        /// <summary>
        /// Returns a string representation of the operator node in prefix notation.
        /// </summary>
        /// <returns>A string in the format "(operator left right)".</returns>
        public override string Print()
        {
            return $"({this.operation} {this.left.Print()} {this.right.Print()})";
        }
    }
}
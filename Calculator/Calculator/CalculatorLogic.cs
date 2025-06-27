// <copyright file="CalculatorLogic.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace Calculator;

using System.Globalization;

/// <summary>
/// Represents the logic of a calculator including handling input, operations, and expressions.
/// </summary>
public class CalculatorLogic
{
    private readonly List<string> expression = [];

    private string currentInput = "0";
    private double previousResult;
    private string? currentOperator;
    private bool waitNewOperand = true;
    private bool hasDecimalPoint;

    private string DisplayResult { get; set; } = "0";

    /// <summary>
    /// Adds a digit to the current operand being entered.
    /// </summary>
    /// <param name="digit">The digit to add.</param>
    public void AddDigit(int digit)
    {
        if (this.waitNewOperand)
        {
            this.currentInput = digit.ToString();
            this.waitNewOperand = false;
        }
        else
        {
            this.currentInput += digit;
        }

        this.DisplayResult = this.currentInput;
    }

    /// <summary>
    /// Sets the operator for the calculation and applies the previous operation if needed.
    /// </summary>
    /// <param name="op">The operator to apply: +, -, *, or /.</param>
    public void SetOperator(string op)
    {
        if (!this.waitNewOperand)
        {
            this.ApplyOperation();
            this.expression.Add(this.currentInput);
            this.ResetState();
        }

        this.AddOperatorToExpression(op);
        this.currentOperator = op;
    }

    /// <summary>
    /// Performs the final calculation and updates the display with the result.
    /// </summary>
    public void CalculateResult()
    {
        if (this.waitNewOperand)
        {
            return;
        }

        this.ApplyOperation();

        this.expression.Add(this.currentInput);

        this.expression.Clear();
        this.expression.Add(this.previousResult.ToString(CultureInfo.CurrentCulture));

        this.ResetState();
    }

    /// <summary>
    /// Removes the last digit from the current operand.
    /// </summary>
    public void RemoveLastDigit()
    {
        if (this.waitNewOperand || this.currentInput.Length <= 1)
        {
            this.currentInput = "0";
            this.ResetState();
        }
        else
        {
            this.currentInput = this.currentInput[..^1];
        }

        this.DisplayResult = this.currentInput;
    }

    /// <summary>
    /// Toggles the sign of the current operand.
    /// </summary>
    public void ToggleSign()
    {
        if (this.waitNewOperand)
        {
            return;
        }

        if (!double.TryParse(this.currentInput, NumberStyles.Any, CultureInfo.CurrentCulture, out var currentValue))
        {
            return;
        }

        currentValue = -currentValue;
        this.currentInput = currentValue.ToString(CultureInfo.CurrentCulture);
        this.DisplayResult = this.currentInput;
    }

    /// <summary>
    /// Clears all data and resets the calculator to its initial state.
    /// </summary>
    public void ClearAll()
    {
        this.previousResult = 0;
        this.currentOperator = null;
        this.ResetState();
        this.expression.Clear();
        this.DisplayResult = "0";
    }

    /// <summary>
    /// Clears only the current operand without affecting the ongoing operation.
    /// </summary>
    public void ClearEntry()
    {
        if (!this.waitNewOperand)
        {
            this.ResetState();
        }

        this.DisplayResult = this.currentInput;
    }

    /// <summary>
    /// Gets the current value to be displayed on the calculator screen.
    /// </summary>
    /// <returns>The current result as a string.</returns>
    public string GetCurrentResult() => this.DisplayResult;

    /// <summary>
    /// Gets the full expression entered so far as a formatted string.
    /// </summary>
    /// <returns>The expression as a space-separated string.</returns>
    public string GetExpression() => string.Join(" ", this.expression);

    /// <summary>
    /// Adds a decimal point to the current operand if not already present.
    /// </summary>
    public void AddDecimalPoint()
    {
        if (this.hasDecimalPoint)
        {
            return;
        }

        this.hasDecimalPoint = true;
        this.currentInput += ',';
        this.DisplayResult = this.currentInput;
    }

    private static bool IsOperator(string token) => token is "+" or "-" or "*" or "/";

    private double ParseCurrentInput() =>
        double.TryParse(this.currentInput, NumberStyles.Any, CultureInfo.CurrentCulture, out var result)
            ? result
            : 0;

    private void AddOperatorToExpression(string op)
    {
        if (this.expression.Count > 0 && IsOperator(this.expression[^1]))
        {
            this.expression[^1] = op;
        }
        else
        {
            this.expression.Add(op);
        }
    }

    private void ApplyOperation()
    {
        var currentValue = this.ParseCurrentInput();

        if (this.currentOperator == null)
        {
            this.previousResult = currentValue;
        }
        else
        {
            switch (this.currentOperator)
            {
                case "+":
                    this.previousResult += currentValue;
                    break;
                case "-":
                    this.previousResult -= currentValue;
                    break;
                case "*":
                    this.previousResult *= currentValue;
                    break;
                case "/":
                    this.previousResult = currentValue != 0 ? this.previousResult / currentValue : 0;
                    break;
            }
        }

        this.DisplayResult = this.previousResult.ToString(CultureInfo.CurrentCulture);
    }

    private void ResetState()
    {
        this.currentInput = "0";
        this.hasDecimalPoint = false;
        this.waitNewOperand = true;
    }
}
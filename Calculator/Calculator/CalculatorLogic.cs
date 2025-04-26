namespace Calculator;

using System.Globalization;

public class CalculatorLogic
{
    private readonly List<string> expression = [];

    private string currentInput = "0";
    private double previousResult;
    private string? currentOperator;
    private bool waitNewOperand = true;
    private bool hasDecimalPoint;

    private string DisplayResult { get; set; } = "0";

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

    public void CalculateResult()
    {
        if (!this.waitNewOperand)
        {
            this.ApplyOperation();

            this.expression.Add(this.currentInput);

            this.expression.Clear();
            this.expression.Add(this.previousResult.ToString(CultureInfo.CurrentCulture));

            this.ResetState();
        }
    }

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

    public void ToggleSign()
    {
        if (this.waitNewOperand)
        {
            return;
        }

        if (double.TryParse(this.currentInput, NumberStyles.Any, CultureInfo.CurrentCulture, out double currentValue))
        {
            currentValue = -currentValue;
            this.currentInput = currentValue.ToString(CultureInfo.CurrentCulture);
            this.DisplayResult = this.currentInput;
        }
    }

    public void ClearAll()
    {
        this.previousResult = 0;
        this.currentOperator = null;
        this.ResetState();
        this.expression.Clear();
        this.DisplayResult = "0";
    }

    public void ClearEntry()
    {
        if (!this.waitNewOperand)
        {
            this.ResetState();
        }

        this.DisplayResult = this.currentInput;
    }

    public string GetCurrentResult()
    {
        return this.DisplayResult;
    }

    public string GetExpression()
    {
        return string.Join(" ", this.expression);
    }

    public void AddDecimalPoint()
    {
        if (!this.hasDecimalPoint)
        {
            this.hasDecimalPoint = true;
            this.currentInput += ',';
            this.DisplayResult = this.currentInput;
        }
    }

    private static bool IsOperator(string token)
    {
        return token is "+" or "-" or "*" or "/";
    }

    private double ParseCurrentInput()
    {
        return double.TryParse(this.currentInput, NumberStyles.Any, CultureInfo.CurrentCulture, out double result)
            ? result
            : 0;
    }

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
        double currentValue = this.ParseCurrentInput();

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
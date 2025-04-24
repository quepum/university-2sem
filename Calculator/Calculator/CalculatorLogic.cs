namespace Calculator;

using System.Globalization;

public class CalculatorLogic
{
    private readonly List<string> expression = [];

    private double currentValue;
    private double previousResult;
    private string? currentOperator;
    private bool waitNewOperand = true;
    private bool hasDecimalPoint;
    private int decimalPlaces;

    private double DisplayResult { get; set; } = 0;

    public void AddDigit(int digit)
    {
        if (this.waitNewOperand)
        {
            this.currentValue = digit;
            this.waitNewOperand = false;
        }
        else
        {
            if (this.hasDecimalPoint)
            {
                this.decimalPlaces++;
                this.currentValue += digit / Math.Pow(10, this.decimalPlaces);
            }
            else
            {
                this.currentValue = (this.currentValue * 10) + digit;
            }
        }

        this.DisplayResult = this.currentValue;
    }

    public void SetOperator(string op)
    {
        if (!this.waitNewOperand)
        {
            this.ApplyOperation();

            this.expression.Add(this.currentValue.ToString(CultureInfo.CurrentCulture));
            this.expression.Add(op);

            this.ResetState();
        }
        else
        {
            if (this.expression.Count > 0)
            {
                if (IsOperator(this.expression[^1]))
                {
                    this.expression[^1] = op;
                }
                else
                {
                    this.expression.Add(op);
                }
            }
        }

        this.currentOperator = op;
    }

    public void CalculateResult()
    {
        if (!this.waitNewOperand)
        {
            this.ApplyOperation();

            this.expression.Add(this.currentValue.ToString(CultureInfo.CurrentCulture));

            this.expression.Clear();
            this.expression.Add(this.previousResult.ToString(CultureInfo.CurrentCulture));

            this.ResetState();
        }
    }

    public void ClearAll()
    {
        this.previousResult = 0;
        this.currentOperator = null;
        this.ResetState();
        this.expression.Clear();
        this.DisplayResult = 0;
    }

    public void ClearEntry()
    {
        if (!this.waitNewOperand)
        {
            this.ResetState();
        }

        this.DisplayResult = this.currentValue;
    }

    public double GetCurrentValue()
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
            this.waitNewOperand = false;
        }
    }

    private static bool IsOperator(string token)
    {
        return token is "+" or "-" or "*" or "/";
    }

    private void ApplyOperation()
    {
        if (this.currentOperator == null)
        {
            this.previousResult = this.currentValue;
        }
        else
        {
            switch (this.currentOperator)
            {
                case "+": this.previousResult += this.currentValue; break;
                case "-": this.previousResult -= this.currentValue; break;
                case "*": this.previousResult *= this.currentValue; break;
                case "/":
                    this.previousResult = this.currentValue != 0 ? this.previousResult / this.currentValue : 0; break;
            }
        }

        this.DisplayResult = this.previousResult;
    }

    private void ResetState()
    {
        this.currentValue = 0;
        this.waitNewOperand = true;
        this.hasDecimalPoint = false;
        this.decimalPlaces = 0;
    }
}
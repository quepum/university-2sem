namespace Calculator;

using System.Globalization;

public class CalculatorLogic
{
    private readonly List<string> expression = [];

    private long integerPart;
    private long fractionalPart;
    private double previousResult;
    private string? currentOperator;
    private bool waitNewOperand = true;
    private bool hasDecimalPoint;
    private int decimalPlaces;

    private double DisplayResult { get; set; }

    public void AddDigit(int digit)
    {
        if (this.waitNewOperand)
        {
            this.integerPart = digit;
            this.fractionalPart = 0;
            this.decimalPlaces = 0;
            this.waitNewOperand = false;
        }
        else
        {
            if (this.hasDecimalPoint)
            {
                this.fractionalPart = (this.fractionalPart * 10) + digit;
                this.decimalPlaces++;
            }
            else
            {
                this.integerPart = (this.integerPart * 10) + digit;
            }
        }

        this.DisplayResult = this.GetCurrentDoubleValue();
    }

    public void SetOperator(string op)
    {
        if (!this.waitNewOperand)
        {
            this.ApplyOperation();

            this.expression.Add(this.GetCurrentDoubleValue().ToString(CultureInfo.CurrentCulture));
            this.expression.Add(op);

            this.ResetState();
        }
        else
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

        this.currentOperator = op;
    }

    public void CalculateResult()
    {
        if (!this.waitNewOperand)
        {
            this.ApplyOperation();

            this.expression.Add(this.GetCurrentDoubleValue().ToString(CultureInfo.CurrentCulture));

            this.expression.Clear();
            this.expression.Add(this.previousResult.ToString(CultureInfo.CurrentCulture));

            this.ResetState();
        }
    }

    public void RemoveLastDigit()
    {
        if (this.waitNewOperand)
        {
            return;
        }

        if (this.hasDecimalPoint && this.decimalPlaces > 0)
        {
            this.fractionalPart /= 10;
            this.decimalPlaces--;

            if (this.decimalPlaces == 0)
            {
                this.hasDecimalPoint = false;
            }
        }
        else if (this.integerPart > 0)
        {
            this.integerPart /= 10;

            if (this.integerPart == 0 && !this.hasDecimalPoint)
            {
                this.ResetState();
            }
        }
        else
        {
            this.ResetState();
        }

        this.DisplayResult = this.GetCurrentDoubleValue();
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

        this.DisplayResult = this.GetCurrentDoubleValue();
    }

    public double GetCurrentResult()
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
        }
    }

    private static bool IsOperator(string token)
    {
        return token is "+" or "-" or "*" or "/";
    }

    private double GetCurrentDoubleValue()
    {
        return this.integerPart + (this.fractionalPart / Math.Pow(10, this.decimalPlaces));
    }

    private void ApplyOperation()
    {
        double currentValue = this.GetCurrentDoubleValue();

        if (this.currentOperator == null)
        {
            this.previousResult = currentValue;
        }
        else
        {
            switch (this.currentOperator)
            {
                case "+": this.previousResult += currentValue; break;
                case "-": this.previousResult -= currentValue; break;
                case "*": this.previousResult *= currentValue; break;
                case "/":
                    this.previousResult = currentValue != 0 ? this.previousResult / currentValue : 0; break;
            }
        }

        this.DisplayResult = this.previousResult;
    }

    private void ResetState()
    {
        this.integerPart = 0;
        this.fractionalPart = 0;
        this.decimalPlaces = 0;
        this.hasDecimalPoint = false;
        this.waitNewOperand = true;
    }
}
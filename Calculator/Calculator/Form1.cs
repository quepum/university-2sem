namespace Calculator;

using System.Globalization;

/// <summary>
/// eds.
/// </summary>
public partial class Form1 : Form
{
    private readonly CalculatorLogic calculator;
    private string fullExpression = string.Empty;

    public Form1()
    {
        this.InitializeComponent();
        this.calculator = new CalculatorLogic();
    }

    private void NumberButton_Click(object sender, EventArgs e)
    {
        if (sender is Button button && int.TryParse(button.Text, out int number))
        {
            this.calculator.AddDigit(number);
            this.UpdateDisplay();
        }
    }

    private void OperatorButton_Click(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            this.calculator.SetOperator(button.Text);
            this.UpdateDisplay();
        }
    }

    private void EqualsButton_Click(object sender, EventArgs e)
    {
        this.calculator.CalculateResult();
        this.UpdateDisplay();
    }

    private void ClearAllButton_Click(object sender, EventArgs e)
    {
        this.calculator.ClearAll();
        this.UpdateDisplay();
    }

    private void ClearEntryButton_Click(object sender, EventArgs e)
    {
        this.calculator.ClearEntry();
        this.UpdateDisplay();
    }

    private void CommaButton_Click(object sender, EventArgs e)
    {
        this.calculator.AddDecimalPoint();
        this.UpdateDisplay();
    }

    private void BackspaceButton_Click(object sender, EventArgs e)
    {
        this.calculator.RemoveLastDigit();
        this.UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        this.fullExpression = this.calculator.GetExpression();
        double result = this.calculator.GetCurrentResult();
        this.label1.Text = this.fullExpression.Length > 30 ? this.fullExpression[^30..] : this.fullExpression;

        this.label2.Text = result.ToString(CultureInfo.CurrentCulture);
    }
}
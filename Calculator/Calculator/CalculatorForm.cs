// <copyright file="CalculatorForm.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace Calculator;

using System.Globalization;

/// <summary>
/// Represents the main form of the calculator application.
/// This class manages the user interface and handles user interactions,
/// delegating calculations and logic to the <see cref="CalculatorLogic"/> class.
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly CalculatorLogic calculator;
    private string fullExpression = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();
        this.calculator = new CalculatorLogic();
    }

    private void NumberButton_Click(object sender, EventArgs e)
    {
        if (sender is not Button button || !int.TryParse(button.Text, out var number))
        {
            return;
        }

        this.calculator.AddDigit(number);
        this.UpdateDisplay();
    }

    private void OperatorButton_Click(object sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        this.calculator.SetOperator(button.Text);
        this.UpdateDisplay();
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

    private void ToggleSignButton_Click(object sender, EventArgs e)
    {
        this.calculator.ToggleSign();
        this.UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        this.fullExpression = this.calculator.GetExpression();
        var result = this.calculator.GetCurrentResult();
        this.label1.Text = this.fullExpression.Length > 30 ? this.fullExpression[^30..] : this.fullExpression;

        this.label2.Text = result.ToString(CultureInfo.CurrentCulture);
    }
}
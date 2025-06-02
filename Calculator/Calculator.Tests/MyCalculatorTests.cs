// <copyright file="MyCalculatorTests.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace Calculator.Tests;

/// <summary>
/// Unit tests for the <see cref="CalculatorLogic"/> class to ensure correct behavior of calculator operations.
/// </summary>
public class MyCalculatorTests
{
    private CalculatorLogic calculator;

    [SetUp]
    public void Setup() => this.calculator = new CalculatorLogic();

    [Test]
    public void AddDigit_AddSingleDigit_ShouldUpdateCurrentInput()
    {
        this.calculator.AddDigit(5);

        Assert.That(this.calculator.GetCurrentResult(), Is.EqualTo("5"));
    }

    [Test]
    public void AddDigit_AddMultipleDigits_ShouldConcatenateDigits()
    {
        this.calculator.AddDigit(1);
        this.calculator.AddDigit(2);
        this.calculator.AddDigit(3);

        Assert.That(this.calculator.GetCurrentResult(), Is.EqualTo("123"));
    }

    [Test]
    public void SetOperator_SetPlusOperator_ShouldAddOperatorToExpression()
    {
        this.calculator.AddDigit(5);
        this.calculator.SetOperator("+");

        var expression = this.calculator.GetExpression();

        Assert.That(expression, Is.EqualTo("5 +"));
    }

    [Test]
    public void SetOperator_ReplaceOperator_ShouldUpdateLastOperator()
    {
        this.calculator.AddDigit(5);
        this.calculator.SetOperator("+");
        this.calculator.SetOperator("-");

        var expression = this.calculator.GetExpression();

        Assert.That(expression, Is.EqualTo("5 -"));
    }

    [Test]
    public void CalculateResult_SimpleAddition_ShouldReturnCorrectResult()
    {
        this.calculator.AddDigit(5);
        this.calculator.SetOperator("+");
        this.calculator.AddDigit(3);
        this.calculator.CalculateResult();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("8"));
    }

    [Test]
    public void CalculateResult_MultipleOperations_ShouldReturnCorrectResult()
    {
        this.calculator.AddDigit(10);
        this.calculator.SetOperator("+");
        this.calculator.AddDigit(5);
        this.calculator.SetOperator("*");
        this.calculator.AddDigit(2);
        this.calculator.CalculateResult();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("30"));
    }

    [Test]
    public void CalculateResult_DivisionByZero_ShouldReturnZero()
    {
        this.calculator.AddDigit(10);
        this.calculator.SetOperator("/");
        this.calculator.AddDigit(0);
        this.calculator.CalculateResult();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("0"));
    }

    [Test]
    public void RemoveLastDigit_RemoveFromSingleDigit_ShouldResetToZero()
    {
        this.calculator.AddDigit(5);
        this.calculator.RemoveLastDigit();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("0"));
    }

    [Test]
    public void RemoveLastDigit_RemoveFromMultiDigitNumber_ShouldRemoveLastDigit()
    {
        this.calculator.AddDigit(1);
        this.calculator.AddDigit(2);
        this.calculator.AddDigit(3);
        this.calculator.RemoveLastDigit();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("12"));
    }

    [Test]
    public void ClearAll_ClearAfterOperation_ShouldResetState()
    {
        this.calculator.AddDigit(5);
        this.calculator.SetOperator("+");
        this.calculator.AddDigit(3);
        this.calculator.CalculateResult();
        this.calculator.ClearAll();

        var result = this.calculator.GetCurrentResult();
        var expression = this.calculator.GetExpression();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo("0"));
            Assert.That(expression, Is.EqualTo(string.Empty));
        });
    }

    [Test]
    public void ClearEntry_ClearDuringInput_ShouldResetCurrentInput()
    {
        this.calculator.AddDigit(1);
        this.calculator.AddDigit(2);
        this.calculator.ClearEntry();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("0"));
    }

    [Test]
    public void AddDecimalPoint_AddDecimalPoint_ShouldAppendComma()
    {
        this.calculator.AddDigit(5);
        this.calculator.AddDecimalPoint();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("5,"));
    }

    [Test]
    public void AddDecimalPoint_AddMultipleDecimalPoints_ShouldIgnoreExtraCommas()
    {
        this.calculator.AddDigit(5);
        this.calculator.AddDecimalPoint();
        this.calculator.AddDecimalPoint();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("5,"));
    }

    [Test]
    public void ToggleSign_TogglePositiveNumber_ShouldMakeItNegative()
    {
        this.calculator.AddDigit(5);
        this.calculator.ToggleSign();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("-5"));
    }

    [Test]
    public void ToggleSign_ToggleNegativeNumber_ShouldMakeItPositive()
    {
        this.calculator.AddDigit(5);
        this.calculator.ToggleSign();
        this.calculator.ToggleSign();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("5"));
    }

    [Test]
    public void ToggleSign_ToggleZero_ShouldRemainZero()
    {
        this.calculator.ToggleSign();

        var result = this.calculator.GetCurrentResult();

        Assert.That(result, Is.EqualTo("0"));
    }
}
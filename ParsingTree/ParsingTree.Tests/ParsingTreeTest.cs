namespace ParsingTree.Tests;

[TestFixture]
public class Tests
{
    private static readonly object[] ValidExpressions =
    [
        new TestCaseData("(* (+ 1 2) (- 3 4))", -3),
        new TestCaseData("(+ (* 2 3) (/ 10 2))", 11),
        new TestCaseData("(/ (- 10 5) 5)", 1),
        new TestCaseData("(+ 1 2)", 3),
        new TestCaseData("(* 3 4)", 12)
    ];

    private static readonly object[] InvalidExpressions =
    [
        new TestCaseData("(* (+ 1 2) (- 3 4) (/ 8 2))"),
        new TestCaseData("(* (+ 1 2)"),
        new TestCaseData(string.Empty),
        new TestCaseData("(* (+ 1 2) abc)")
    ];

    [Test]
    [TestCaseSource(nameof(ValidExpressions))]
    public void ParseAndEvaluate_ValidExpression_ReturnsCorrectResult(string expression, int expectedValue)
    {
        using var tempFile = new TempFile(expression);
        var parser = new Parser(File.ReadAllText(tempFile.Path));
        var root = parser.Parse();
        int result = root.Evaluate();
        Assert.That(expectedValue, Is.EqualTo(result));
    }

    [Test]
    [TestCaseSource(nameof(InvalidExpressions))]
    public void ParseAndEvaluate_InvalidExpression_ThrowsFormatException(string expression)
    {
        using var tempFile = new TempFile(expression);
        var parser = new Parser(File.ReadAllText(tempFile.Path));
        Assert.Throws<FormatException>(() => parser.Parse());
    }

    [Test]
    public void ParseAndEvaluate_InvalidExpression_ThrowsDivideByZeroException()
    {
        const string expression = "(/ 10 0)";
        using var tempFile = new TempFile(expression);
        var parser = new Parser(File.ReadAllText(tempFile.Path));
        Assert.Throws<DivideByZeroException>(() => parser.Parse().Evaluate());
    }

    [Test]
    public void ParseAndEvaluate_InvalidExpression_ThrowsArgumentException()
    {
        const string expression = "(^ 2 3)";
        using var tempFile = new TempFile(expression);
        var parser = new Parser(File.ReadAllText(tempFile.Path));
        Assert.Throws<ArgumentException>(() => parser.Parse());
    }


    private class TempFile : IDisposable
    {
        public string Path { get; }

        public TempFile(string content)
        {
            this.Path = System.IO.Path.GetTempFileName();
            File.WriteAllText(this.Path, content);
        }

        public void Dispose()
        {
            if (File.Exists(this.Path))
            {
                File.Delete(this.Path);
            }
        }
    }
}
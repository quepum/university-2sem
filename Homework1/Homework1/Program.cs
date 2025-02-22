namespace Homework1;

/// <summary>
/// Burrows Wheeler algorithm.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    /// <returns>The result of the program execution.</returns>
    public static int Main()
    {
        if (!RunAllTests())
        {
            Console.WriteLine("Tests failed");
            return -1;
        }

        string? inputString = Console.ReadLine();
        if (inputString is null)
        {
            Console.WriteLine("Input error");
            return -1;
        }

        Console.WriteLine($"Input string: {inputString}");
        (string output, int position) = Bwt(inputString);
        Console.WriteLine($"After BWT: {output}\nPosition: {position}");
        string originalString = ReverseBwt(output, position);
        Console.WriteLine($"Recovered string: {originalString}");

        return 0;
    }

    /// <summary>
    /// Burrows-Wheeler transformer.
    /// </summary>
    /// <param name="input">Transformable string.</param>
    /// <returns>Transformed string and position of the end.</returns>
    private static (string OutputString, int Position) Bwt(string input)
    {
        int inputLength = input.Length;
        var rotations = new int[inputLength];

        for (var i = 0; i < inputLength; i++)
        {
            rotations[i] = i;
        }

        Array.Sort(rotations, (a, b) => CompareCyclicShifts(input, a, b));

        int endPosition = Array.IndexOf(rotations, 0);
        var result = new char[inputLength];
        for (var i = 0; i < inputLength; i++)
        {
            result[i] = input[(rotations[i] + inputLength - 1) % inputLength];
        }

        return (new string(result), endPosition);
    }

    /// <summary>
    /// Comparisons of two cyclic shifts.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <param name="indexA">The index of the first character of the first cyclic shift.</param>
    /// <param name="indexB">The index of the first character of the second cyclic shift.</param>
    /// <returns>Comparison result.</returns>
    private static int CompareCyclicShifts(string input, int indexA, int indexB)
    {
        int length = input.Length;

        for (var i = 0; i < length; i++)
        {
            char charA = input[(indexA + i) % length];
            char charB = input[(indexB + i) % length];

            if (charA != charB)
            {
                return charA.CompareTo(charB);
            }
        }

        return 0;
    }

    /// <summary>
    /// Reverse Burrows-Wheeler transformation.
    /// </summary>
    /// <param name="transformedString">transformable string.</param>
    /// <param name="position">end of string position.</param>
    /// <returns>the string before the BWT transformation.</returns>
    private static string ReverseBwt(string transformedString, int position)
    {
        int length = transformedString.Length;
        char[] firstColumn = transformedString.ToCharArray();
        Array.Sort(firstColumn);

        var nextIndex = new int[length];
        var usedPositions = new bool[length];

        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < length; j++)
            {
                if (transformedString[j] == firstColumn[i] && !usedPositions[j])
                {
                    nextIndex[i] = j;
                    usedPositions[j] = true;
                    break;
                }
            }
        }

        var result = new char[length];
        int currentPosition = position;
        for (var i = 0; i < length; i++)
        {
            result[i] = firstColumn[currentPosition];
            currentPosition = nextIndex[currentPosition];
        }

        return new string(result);
    }

    /// <summary>
    /// Tests for BWT.
    /// </summary>
    /// <returns>True if the tests were passed and false if not.</returns>
    private static bool RunAllTests()
    {
        const string inputTest1 = "a";
        (string outputTest1, int testPosition1) = Bwt(inputTest1);
        if (ReverseBwt(outputTest1, testPosition1) != inputTest1)
        {
            Console.WriteLine("test 1");
            return false;
        }

        const string inputTest2 = "banana";
        (string outputTest2, int testPosition2) = Bwt(inputTest2);
        if (ReverseBwt(outputTest2, testPosition2) != inputTest2)
        {
            Console.WriteLine("test 2");
            return false;
        }

        const string inputTest3 = "mississippi";
        (string outputTest3, int testPosition3) = Bwt(inputTest3);
        if (ReverseBwt(outputTest3, testPosition3) != inputTest3)
        {
            Console.WriteLine("test 3");
            return false;
        }

        return true;
    }
}
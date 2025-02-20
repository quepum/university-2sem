internal class Program
{
    public static int Main(string[] args)
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

    private static (string, int) Bwt(string input)
    {
        input += "$";
        int inputLength = input.Length;
        string[] rotations = new string[inputLength];

        for (int i = 0; i < inputLength; i++)
        {
            string rotation = input.Substring(i) + input.Substring(0, i);
            rotations[i] = rotation;
        }

        Array.Sort(rotations);
        int position = Array.IndexOf(rotations, input);
        char[] lastCharacters = new char[inputLength];

        for (int i = 0; i < inputLength; i++)
        {
            lastCharacters[i] = rotations[i][inputLength - 1];
        }

        string result = new string(lastCharacters);
        return (result, position);
    }

    private static string ReverseBwt(string transformedString, int position)
    {
        int length = transformedString.Length;
        char[] firstColumn = transformedString.ToCharArray();
        Array.Sort(firstColumn);

        int[] nextIndex = new int[length];
        bool[] usedPositions = new bool[length];

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (transformedString[j] == firstColumn[i] && !usedPositions[j])
                {
                    nextIndex[i] = j;
                    usedPositions[j] = true;
                    break;
                }
            }
        }

        char[] result = new char[length - 1];
        int currentPosition = position;
        for (int i = 0; i < length - 1; i++)
        {
            result[i] = firstColumn[currentPosition];
            currentPosition = nextIndex[currentPosition];
        }

        return new string(result);
    }

    private static bool RunAllTests()
    {
        string inputTest1 = "a";
        (string outputTest1, int testPosition1) = Bwt(inputTest1);
        if (inputTest1 != ReverseBwt(outputTest1, testPosition1))
        {
            return false;
        }

        string inputTest2 = "banana";
        (string outputTest2, int testPosition2) = Bwt(inputTest2);
        if (inputTest2 != ReverseBwt(outputTest2, testPosition2))
        {
            return false;
        }

        string inputTest3 = "mississippi";
        (string outputTest3, int testPosition3) = Bwt(inputTest3);
        if (inputTest3 != ReverseBwt(outputTest3, testPosition3))
        {
            return false;
        }

        return true;
    }
}
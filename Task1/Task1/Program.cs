internal class Program
{
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

        char[] result = new char[length];
        int currentPosition = position;
        for (int i = 0; i < length; i++)
        {
            result[i] = firstColumn[currentPosition];
            currentPosition = nextIndex[currentPosition];
        }

        return new string(result);
    }

    public static int Main(string[] args)
    {
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
}
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

        return 0;
    }
}
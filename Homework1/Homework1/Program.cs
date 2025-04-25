using static Homework1.BwtResult;

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
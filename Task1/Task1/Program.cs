internal class Program
{
    public static int Main(string[] args)
    {
        string? inputString = Console.ReadLine();
        if (inputString is null)
        {
            Console.WriteLine("Всё плохо");
            return -1;
        }

        return 1;
    }
}
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Homework2;

var trie = new Trie();
Console.WriteLine($"Available Commands:\n" +
              $"1. Add new string to the trie.\n" +
              $"2. Check if the string is contained in the trie.\n" +
              $"3. Remove string from the trie.\n" +
              $"4. Count the number of strings with a given prefix in the trie.\n" +
              $"5. Get current size of the trie.\n" +
              $"6. Exit.\n");
while (true)
{
    Console.WriteLine("Enter the command\n");
    string? command = Console.ReadLine();
    switch (command)
    {
        case "1":
            Console.WriteLine("Enter the string\n");
            string? inputString1 = Console.ReadLine();
            if (inputString1 != null && trie.Add(inputString1))
            {
                Console.WriteLine("Your string added successfully\n");
            }

            break;
        case "2":
            Console.WriteLine("Enter the string\n");
            var inputString2 = Console.ReadLine();
            if (inputString2 != null && trie.Contains(inputString2))
            {
                Console.WriteLine("Your string contains in the trie\n");
            }
            else
            {
                Console.WriteLine("No such string\n");
            }

            break;
        case "3":
            Console.WriteLine("Enter the string\n");
            var inputString3 = Console.ReadLine();
            if (inputString3 != null)
            {
                trie.Remove(inputString3);
            }

            break;
        case "4":
            Console.WriteLine("Enter the string\n");
            var inputString4 = Console.ReadLine();
            if (inputString4 != null)
            {
                Console.WriteLine($"{trie.HowManyStartsWithPrefix(inputString4)} strings start with this prefix\n");
            }

            break;
        case "5":
            Console.WriteLine($"Current number of strings: {trie.Size}\n");
            break;
        case "6":
            return;
        default:
            Console.WriteLine("No such command\n");
            break;
    }
}
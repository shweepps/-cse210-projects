using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a scripture with reference and text
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display the complete scripture
        scripture.Display();

        // Prompt the user to press Enter or type "quit"
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (input.ToLower() != "quit" && scripture.HasHiddenWords())
        {
            // Hide a few random words in the scripture
            scripture.HideRandomWords(2);

            // Clear the console screen
            Console.Clear();

            // Display the modified scripture
            scripture.Display();

            // Prompt the user to press Enter or type "quit"
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }
}



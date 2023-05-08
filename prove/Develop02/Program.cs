using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            Console.WriteLine("Welcome to your journal!");
            Console.WriteLine();

            bool done = false;

            while (!done)
            {
                Console.WriteLine("Please select one of the following choices");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display all entries");
                Console.WriteLine("3. Save entries to a file");
                Console.WriteLine("4. Load entries from a file");
                Console.WriteLine("5. Quit");
                Console.WriteLine();

                Console.Write("What would you like to do? ");
                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        Entry entry = new Entry(GetPromptFromUser(), GetResponseFromUser(), GetDateFromUser());
                        journal.AddEntry(entry);
                        break;
                    case 2:
                        journal.DisplayEntries();
                        break;
                    case 3:
                        journal.SaveToFile();
                        break;
                    case 4:
                        journal.LoadFromFile();
                        break;
                    case 5:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        
                        break;
                    
                }
            }

            Console.WriteLine("Goodbye!");
        }

        static int GetChoice()
        {
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. Please choose again.");
                Console.WriteLine();
            }

            return choice;
        }

        static string GetPromptFromUser()
        {
            Random rnd = new Random();
            int index = rnd.Next(prompts.Count);
            Console.WriteLine("Prompt: " + prompts[index]);
            return prompts[index];
        }

        static string GetResponseFromUser()
        {
            Console.Write("Enter a response: ");
            return Console.ReadLine();
        }
        public static List<string> prompts = new List<string> {
            "What did you do today?",
            "What are you grateful for?",
            "What are your goals for the week?",
            "What is something you learned recently?",
            "What was the highlight of your day?",
            "What are you looking forward to?",
            "What is something that made you smile today?",
            "What is something you want to improve?",
            "What is something you're proud of?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        static string GetDateFromUser()
        {
            Console.Write("Enter a date (MM/DD/YYYY): ");
            return Console.ReadLine();
        }
    }
}

using System;

public class Program
{
    public static void Main()
    {
        bool isRunning = true;
        Console.Clear();
        while (isRunning)
        {
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. To Quit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                         

                        Console.Write("Enter the duration (in seconds): ");
                        int breathingDuration = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                        Activity breathingActivity = new BreathingActivity(breathingDuration);
                        breathingActivity.Start();
                       
                        break;

                    case 2:
                        Console.Write("Enter the duration (in seconds): ");
                        int reflectionDuration = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                        Activity reflectionActivity = new ReflectionActivity(reflectionDuration);
                        reflectionActivity.Start();
                        break;

                    case 3:
                        Console.Write("Enter the duration (in seconds): ");
                        int listingDuration = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                        Activity listingActivity = new ListingActivity(listingDuration);
                        listingActivity.Start();
                        break;

                    case 4:
                        isRunning = false; 
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}

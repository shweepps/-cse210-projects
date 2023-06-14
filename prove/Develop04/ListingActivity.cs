using System;

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine();

        Console.WriteLine($"Set the duration for this activity (in seconds): {duration}");
        Console.Write("Prepare to begin... ");
         Animation(5);
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine();

        Console.WriteLine("Start listing items...");
        Console.WriteLine("(Press Enter after each item)");
        Console.WriteLine();

        int count = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                break;

            count++;
        }

        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Listing Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine($"Number of items listed: {count}");
       Animation(5);
       Console.Clear();
    }
}

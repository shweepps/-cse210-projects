using System;

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine();

        Console.WriteLine($"Set the duration for this activity (in seconds): {duration}");
        Console.Write("Prepare to begin...");
          Animation(5);

        Random random = new Random(); 
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine();

        for (int i = 0; i < duration; i++)
        {
            string question = questions[random.Next(questions.Length)];
            Console.Write($"Question {i + 1}: {question} ");
             Animation(5);
              Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Reflection Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
       Animation(5);
        Console.Clear();
    }
}

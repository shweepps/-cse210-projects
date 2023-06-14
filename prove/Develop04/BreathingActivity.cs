using System;

// Breathing activity

public class BreathingActivity : Activity
{
    
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine();

        Console.WriteLine($"Set the duration for this activity (in seconds): {duration}");
        Console.WriteLine("Prepare to begin...");
        Animation(5);

        for (int i = duration; i > 0; i--)
        {
            Console.Write("Breathe in... ");
            Pause(2);
          

            Console.Write("Breathe out... ");
            Pause(3);
             Console.WriteLine();

        }

        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Breathing Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Animation(5);
        Console.Clear();
    }
}

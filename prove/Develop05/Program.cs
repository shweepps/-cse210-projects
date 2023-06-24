using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Completed { get; set; }

    public virtual void Complete()
    {
        Completed = true;
    }

    public abstract string GetProgress();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override string GetProgress()
    {
        return Completed ? "Completed" : "Not Completed";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override string GetProgress()
    {
        return "Ongoing";
    }
}

public class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int CompletedCount { get; set; }
    public int BonusValue { get; set; }

    public ChecklistGoal(string name, int value, int requiredCount, int bonusValue)
    {
        Name = name;
        Value = value;
        RequiredCount = requiredCount;
        BonusValue = bonusValue;
    }

    public override void Complete()
    {
        CompletedCount++;
        if (CompletedCount >= RequiredCount)
        {
            Completed = true;
            Value += BonusValue;
        }
    }

    public override string GetProgress()
    {
        return $"Completed {CompletedCount}/{RequiredCount} times";
    }
}

public class EternalQuestProgram
{
    private List<Goal> goals;
    private int score;
    private string saveFilePath;

    public int Score
    {
        get { return score; }
    }

    public EternalQuestProgram(string saveFilePath)
    {
        goals = new List<Goal>();
        score = 0;
        this.saveFilePath = saveFilePath;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null && !goal.Completed)
        {
            goal.Complete();
            score += goal.Value;
            Console.WriteLine($"Goal '{goal.Name}' completed! You earned {goal.Value} points.");
        }
        else
        {
            Console.WriteLine("Goal not found or already completed.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals)
        {
            string progress = goal.GetProgress();
            Console.WriteLine($"{(goal.Completed ? "[X]" : "[ ]")} {goal.Name} - {progress}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your Score: {score}");
    }

 public void SaveGoals()
{
    Console.Write("Enter the file path to save the goals: ");
    string filePath = Console.ReadLine();
    
    var options = new JsonSerializerOptions { WriteIndented = true };
    string json = JsonSerializer.Serialize(goals, options);
    File.WriteAllText(filePath, json);
    
    Console.WriteLine("Goals saved successfully.");
}


public void LoadGoals()
{
    Console.Write("Enter the file name to load the goals: ");
    string fileName = Console.ReadLine();

    try
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        string fileContent = File.ReadAllText(filePath);
        // Deserialize the goals from the file content
        goals = JsonSerializer.Deserialize<List<Goal>>(fileContent);
        Console.WriteLine("Goals loaded successfully.");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}


}

public class Program
{
    public static void Main(string[] args)
    {
        string saveFilePath = "goals.json";
        EternalQuestProgram questProgram = new EternalQuestProgram(saveFilePath);

      
        bool running = true;
        while (running)
        {
            
            questProgram.DisplayScore();
            Console.WriteLine();

            Console.WriteLine("========== Eternal Quest ==========");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("===================================");

            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(questProgram);
                    break;
                case "2":
                    ListGoals(questProgram);
                    break;
                case "3":
                    SaveGoals(questProgram);
                    break;
                case "4":
                    LoadGoals(questProgram);
                    break;
                case "5":
                    RecordEvent(questProgram);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void CreateNewGoal(EternalQuestProgram questProgram)
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        int goalChoice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal value: ");
        int value = int.Parse(Console.ReadLine());

        Goal goal;
        switch (goalChoice)
        {
            case 1:
                goal = new SimpleGoal(name, value);
                break;
            case 2:
                goal = new EternalGoal(name, value);
                break;
            case 3:
                Console.Write("Enter required count: ");
                int requiredCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus value: ");
                int bonusValue = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, value, requiredCount, bonusValue);
                break;
            default:
                Console.WriteLine("Invalid choice. Creating a Simple Goal by default.");
                goal = new SimpleGoal(name, value);
                break;
        }

        questProgram.AddGoal(goal);
        Console.WriteLine("New goal created successfully.");
    }

    public static void ListGoals(EternalQuestProgram questProgram)
    {
        questProgram.DisplayGoals();
    }

    public static void SaveGoals(EternalQuestProgram questProgram)
    {
        questProgram.SaveGoals();
    }

    public static void LoadGoals(EternalQuestProgram questProgram)
    {
        questProgram.LoadGoals();
    }

    public static void RecordEvent(EternalQuestProgram questProgram)
    {
        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();
        questProgram.RecordEvent(goalName);
    }
}

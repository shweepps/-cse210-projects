using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestProgram
{
    public class EternalQuestProgram
    {
        private List<Goal> goals;
        public int TotalPoints { get; set; }

        public EternalQuestProgram()
        {
            goals = new List<Goal>();
            TotalPoints = 0;
        }

        public void AddGoal(Goal goal)
        {
            goals.Add(goal);

            // Update TotalPoints only if the goal is completed
            if (goal.Completed)
            {
                TotalPoints += goal.Value;

                // Check if the completed goal is a ChecklistGoal
                if (goal is ChecklistGoal checklistGoal && checklistGoal.Completed)
                {
                    TotalPoints += checklistGoal.BonusPoints;
                }
            }
        }

        public void ShowGoals()
        {
            Console.WriteLine("Goals:");
            foreach (var goal in goals)
            {
                string progress = goal.GetProgress();
                string completionStatus = goal.Completed ? "[X]" : "[ ]";
                int bonusPoints = 0;

                if (goal is ChecklistGoal checklistGoal && checklistGoal.Completed)
                {
                    bonusPoints = checklistGoal.BonusPoints;
                }

                Console.WriteLine($"Name: {goal.Name}, Value: {goal.Value}, Bonus Points: {bonusPoints}, Progress: {completionStatus} {progress}");
            }
            Console.WriteLine($"Total Points: {TotalPoints}");
        }

        public void SaveGoals()
        {
            Console.Write("Enter the filename to save the goals: ");
            string fileName = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var goal in goals)
                    {
                        if (goal is ChecklistGoal checklistGoal)
                        {
                            writer.WriteLine($"{goal.Name},{goal.Value},{goal.Completed},{checklistGoal.TargetCount},{checklistGoal.CompletionCount},{checklistGoal.BonusPoints}");
                        }
                        else
                        {
                            writer.WriteLine($"{goal.Name},{goal.Value},{goal.Completed},,,");
                        }
                    }
                }
                Console.WriteLine("Goals saved successfully.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error saving goals: {e.Message}");
            }
        }

        public void LoadGoals()
{
    Console.Write("Enter the filename to load the goals: ");
    string fileName = Console.ReadLine();

    try
    {
        goals.Clear();
        TotalPoints = 0;

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 3)
                {
                    string name = parts[0];
                    int value = int.Parse(parts[1]);
                    bool completed = bool.Parse(parts[2]);

                    if (name.EndsWith("(C)"))
                    {
                        if (parts.Length == 6)
                        {
                            int targetCount = int.Parse(parts[3]);
                            int completionCount = int.Parse(parts[4]);
                            int bonusPoints = int.Parse(parts[5]);

                            var checklistGoal = new ChecklistGoal
                            {
                                Name = name.Substring(0, name.Length - 3),
                                Value = value,
                                Completed = completed,
                                TargetCount = targetCount,
                                CompletionCount = completionCount,
                                BonusPoints = bonusPoints
                            };

                            goals.Add(checklistGoal);

                            if (checklistGoal.Completed)
                            {
                                TotalPoints += checklistGoal.Value;
                                TotalPoints += checklistGoal.BonusPoints;
                            }
                        }
                    }
                    else if (name.EndsWith("(E)"))
                    {
                        var eternalGoal = new EternalGoal
                        {
                            Name = name.Substring(0, name.Length - 3),
                            Value = value,
                            Completed = completed
                        };

                        goals.Add(eternalGoal);

                        if (eternalGoal.Completed)
                        {
                            TotalPoints += eternalGoal.Value;
                        }
                    }
                    else
                    {
                        var simpleGoal = new SimpleGoal
                        {
                            Name = name,
                            Value = value,
                            Completed = completed
                        };

                        goals.Add(simpleGoal);

                        if (simpleGoal.Completed)
                        {
                            TotalPoints += simpleGoal.Value;
                        }
                    }
                }
            }
        }

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


        public void RecordEvent()
        {
            Console.Write("Enter the name of the goal: ");
            string goalName = Console.ReadLine();

            Goal goal = goals.Find(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));

            if (goal != null)
            {
                goal.Complete();
                TotalPoints += goal.Value;

                if (goal is ChecklistGoal checklistGoal && checklistGoal.Completed)
                {
                    TotalPoints += checklistGoal.BonusPoints;
                }

                Console.WriteLine($"Event recorded for goal: {goal.Name}");
            }
            else
            {
                Console.WriteLine("Goal not found.");
            }
        }

        static void Main()
        {
            var eternalQuest = new EternalQuestProgram();

            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.WriteLine($"Total Points: {eternalQuest.TotalPoints}");
                Console.WriteLine("1. Add Goal");
                Console.WriteLine("2. Show Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":



                        Console.WriteLine("Select the type of goal:");
                        Console.WriteLine("1. Simple Goal");
                        Console.WriteLine("2. Eternal Goal");
                        Console.WriteLine("3. Checklist Goal");
                        Console.Write("Enter your choice (1-3): ");
                        string goalTypeChoice = Console.ReadLine();

                        Console.Write("Enter the name of the goal: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter the value of the goal: ");
                        int value = int.Parse(Console.ReadLine());


                        Goal goal;
                        switch (goalTypeChoice)
                        {
                            case "1":
                                goal = new SimpleGoal();
                                break;
                            case "2":
                                goal = new EternalGoal();
                                break;
                            case "3":
                                Console.Write("Enter the target count for the checklist goal: ");
                                int targetCount = int.Parse(Console.ReadLine());

                                Console.Write("Enter the bonus points for the checklist goal: ");
                                int bonusPoints = int.Parse(Console.ReadLine());

                                goal = new ChecklistGoal
                                {
                                    TargetCount = targetCount,
                                    BonusPoints = bonusPoints
                                };
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Creating a simple goal by default.");
                                goal = new SimpleGoal();
                                break;
                        }

                        goal.Name = name;
                        goal.Value = value;
                        eternalQuest.AddGoal(goal);
                        Console.WriteLine($"Goal '{name}' added successfully.");
                        break;
                    case "2":
                        eternalQuest.ShowGoals();
                        break;
                    case "3":
                        eternalQuest.SaveGoals();
                        break;
                    case "4":
                        eternalQuest.LoadGoals();
                        break;
                    case "5":
                        eternalQuest.RecordEvent();
                        break;
                    case "6":
                        exitProgram = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}

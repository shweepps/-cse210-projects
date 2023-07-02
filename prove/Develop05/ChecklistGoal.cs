using System;

namespace EternalQuestProgram
{
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int CompletionCount { get; set; }
        public int BonusPoints { get; set; }

        public override void Complete()
        {
            CompletionCount++;
            if (CompletionCount == TargetCount)
            {
                Completed = true;
            }
        }

        public override string GetProgress()
        {
            return $"Completed {CompletionCount}/{TargetCount} times";
        }
    }
}

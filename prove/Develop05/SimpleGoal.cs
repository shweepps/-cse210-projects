using System;

namespace EternalQuestProgram
{
    public class SimpleGoal : Goal
    {
        public override void Complete()
        {
            base.Complete();
        }

        public override string GetProgress()
        {
            return Completed ? "Completed" : "Not Completed";
        }
    }
}

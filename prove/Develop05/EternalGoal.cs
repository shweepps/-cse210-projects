using System;

namespace EternalQuestProgram
{
    public class EternalGoal : Goal
    {
        public override void Complete()
        {
            base.Complete();
        }

        public override string GetProgress()
        {
            return "Ongoing";
        }
    }
}

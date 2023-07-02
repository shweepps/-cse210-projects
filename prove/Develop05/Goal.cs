using System;

namespace EternalQuestProgram
{
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
}

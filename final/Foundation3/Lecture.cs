namespace EventPlanning
{
    class Lecture : Event
    {
        public string Speaker { get; set; }
        public int LectureCapacity { get; set; }

        public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            Speaker = speaker;
            LectureCapacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {LectureCapacity}";
        }
    }
}

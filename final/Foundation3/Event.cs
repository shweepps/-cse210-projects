namespace EventPlanning
{
    class Event
    {
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Address EventAddress { get; set; }

        public Event(string title, string description, DateTime date, TimeSpan time, Address address)
        {
            EventTitle = title;
            Description = description;
            Date = date;
            Time = time;
            EventAddress = address;
        }

        public string GetStandardDetails()
        {
            return $"Event: {EventTitle}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time.ToString()}\nAddress: {GetAddress()}";
        }

        public virtual string GetFullDetails()
        {
            return GetStandardDetails();
        }

        public string GetShortDescription()
        {
            return $"Type: {GetType().Name}\nEvent: {EventTitle}\nDate: {Date.ToShortDateString()}";
        }

        private string GetAddress()
        {
            return $"{EventAddress.Street}, {EventAddress.City}, {EventAddress.State}, {EventAddress.Country}";
        }
    }
}

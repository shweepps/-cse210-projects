using System;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of different event types
            var lecture = new Lecture("Introduction to ML", "Learn the basics of Machine Learning", DateTime.Now, TimeSpan.FromHours(2),
                new Address { Street = "123 Main St", City = "New York", State = "NY", Country = "USA" }, "John Doe", 100);

            var reception = new Reception("Networking Night", "An evening of networking and socializing", DateTime.Now.AddDays(7), TimeSpan.FromHours(3),
                new Address { Street = "456 Park Ave", City = "San Francisco", State = "CA", Country = "USA" }, "email@willie.com");

            var gathering = new OutdoorGathering("Summer Picnic", "Enjoy outdoor activities and delicious food", DateTime.Now.AddDays(14), TimeSpan.FromHours(4),
                new Address { Street = "789 Elm St", City = "London", State = "N/A", Country = "UK" }, "Sunny with a high of 25°C");

            // Generate marketing messages for the events
            string lectureStandardDetails = lecture.GetStandardDetails();
            string lectureFullDetails = lecture.GetFullDetails();
            string lectureShortDescription = lecture.GetShortDescription();

            string receptionStandardDetails = reception.GetStandardDetails();
            string receptionFullDetails = reception.GetFullDetails();
            string receptionShortDescription = reception.GetShortDescription();

            string gatheringStandardDetails = gathering.GetStandardDetails();
            string gatheringFullDetails = gathering.GetFullDetails();
            string gatheringShortDescription = gathering.GetShortDescription();

            // Display the marketing messages
            Console.WriteLine("Lecture:");
            Console.WriteLine(lectureStandardDetails);
            Console.WriteLine(lectureFullDetails);
            Console.WriteLine(lectureShortDescription);

            Console.WriteLine("\nReception:");
            Console.WriteLine(receptionStandardDetails);
            Console.WriteLine(receptionFullDetails);
            Console.WriteLine(receptionShortDescription);

            Console.WriteLine("\nOutdoor Gathering:");
            Console.WriteLine(gatheringStandardDetails);
            Console.WriteLine(gatheringFullDetails);
            Console.WriteLine(gatheringShortDescription);
        }
    }
}

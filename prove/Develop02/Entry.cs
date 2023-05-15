using System;
using System.Collections.Generic;

namespace JournalApp
{
    class Entry
    {
        private string prompt;
        private string response;
        private string date;

        public Entry(string prompt, string response, string date)
        {
            this.prompt = prompt;
            this.response = response;
            this.date = date;
        }

        // Add this method to get a random prompt
        public static string GetRandomPrompt()
        {
            List<string> prompts = new List<string>()
            {
              
            };

            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            return prompts[index];
        }
        static string GetPromptFromUser()
        {
            return Entry.GetRandomPrompt();
        }


        public void Write()
        {
            prompt = GetRandomPrompt();
            Console.WriteLine("Prompt: " + prompt);
            Console.Write("Response: ");
            response = Console.ReadLine();
            date = DateTime.Now.ToString();
        }

        public string GetPrompt()
        {
            return prompt;
        }

        public string GetResponse()
        {
            return response;
        }

        public string GetDate()
        {
            return date;
        }

        public void Display()
        {
            Console.Write("Date: " + date);//must display computer date
            Console.WriteLine(" - Prompt: " + prompt);
            Console.WriteLine("Response: " + response);
            Console.WriteLine();
        }

        public string ToCsvString()
        {
            return prompt + "," + response + "," + date;
        }

        public static Entry FromCsvString(string csvString)
        {
            string[] values = csvString.Split(',');
            return new Entry(values[0], values[1], values[2]);
        }
    }
}

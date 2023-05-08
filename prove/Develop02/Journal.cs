using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Journal
    {
        private List<Entry> entries;

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("There are no entries in the journal.");
            }
            else
            {
                Console.WriteLine("Journal Entries:");
                Console.WriteLine();

                foreach (Entry entry in entries)
                {
                    entry.Display();
                }
            }
        }

        public void SaveToFile()
        {
            Console.Write("Enter the filename to save to: ");
            string filename = Console.ReadLine();
            string csv = "prompt,response,date\n";

            foreach (Entry entry in entries)
            {
                csv += entry.ToCsvString() + "\n";
            }

            try
            {
                File.WriteAllText(filename, csv);
                Console.WriteLine("Journal saved to file successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving journal to file: " + e.Message);
            }
        }

        public void LoadFromFile()
        {
            Console.Write("Enter the filename to load from: ");
            string filename = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filename);
                List<Entry> loadedEntries = new List<Entry>();

                for (int i = 1; i < lines.Length; i++)
                {
                    Entry entry = Entry.FromCsvString(lines[i]);
                    loadedEntries.Add(entry);
                }

                entries = loadedEntries;
                Console.WriteLine("Journal loaded from file successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading journal from file: " + e.Message);
            }
        }
    }




}


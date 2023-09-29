using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Programming_3
{
    public class MedalistManager
    {
        private List<Medalist> medalists = new List<Medalist>();

        // Step 2: Read data from the CSV file and store it in a List<Medalist>.
        public void LoadData(string csvFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(csvFilePath);

                foreach (string line in lines.Skip(1)) // Skip the header row
                {
                    string[] values = line.Split(',');
                    if (values.Length == 5)
                    {
                        Medalist medalist = new Medalist
                        {
                            Athlete = values[0],
                            Year = int.Parse(values[1]),
                            GoldMedals = int.Parse(values[2]),
                            SilverMedals = int.Parse(values[3]),
                            BronzeMedals = int.Parse(values[4])
                        };
                        medalists.Add(medalist);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading data: " + ex.Message);
            }
        }

    public void AddMedalist(Medalist medalist)
    {
        medalists.Add(medalist);
    }

    public void DeleteMedalist(string name)
    {
        Medalist medalistToRemove = medalists.Find(m => m.Athlete == name);
        if (medalistToRemove != null)
        {
            medalists.Remove(medalistToRemove);
        }
    }

    public IEnumerable<Medalist> SearchMedalists(string searchKey)
    {
        return medalists.Where(m => m.Athlete.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    m.Year.ToString().IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    m.GoldMedals.ToString().IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    m.SilverMedals.ToString().IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    m.BronzeMedals.ToString().IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public void DisplayMedalists()
    {
        Console.WriteLine("Medalist Information:");
        foreach (var medalist in medalists)
        {
            Console.WriteLine($"Athlete: {medalist.Athlete}, Year: {medalist.Year}, Gold Medals: {medalist.GoldMedals}, Silver Medals: {medalist.SilverMedals}, Bronze Medals: {medalist.BronzeMedals}");
        }
    }

    }

}
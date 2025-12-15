using System.Globalization;

public static class LogHelpers
{
    public static BoatLogEntry? PickLog(IBoatLogEntryRepository _logRep, string callType)
    {
        while (true)
        {
            ShowBoatLogController SBLC = new ShowBoatLogController(_logRep);
            List<BoatLogEntry> allLogs = SBLC.ShowLogs(callType);

            Console.WriteLine("Q. Cancel");
            Console.WriteLine();

            Console.Write("Update log by order number: ");
            string input = Console.ReadLine().ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber <= allLogs.Count && chosenNumber > 0)
            {
                BoatLogEntry chosenEntry = allLogs[chosenNumber - 1];
                return chosenEntry;
            }

            else if (input == "q")
            {
                return null;
            }
        }
    }

    public static void DisplayChosenBoat(Boat chosenBoat)
    {
        Console.WriteLine($"Editing boat: {chosenBoat.Id}");
        Console.WriteLine();
    }

    public static dynamic DisplayEdit(string propertyName, Boat chosenBoat)
    {
        while (true)
        {
            Console.Clear();

            DisplayChosenBoat(chosenBoat);
            Console.WriteLine($"Editing: {propertyName}");

            Console.Write("Value: ");
            string input = Console.ReadLine().ToLower();

            //Return log date
            if (propertyName != "Log description")
            {
                if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate;
                }

                else
                {
                    continue;
                }
            }

            //Return log description
            if (input.Length < 10000)
            {
                return input;
            }
        }
    }

    public static void DisplayOverview(string logDesc, DateTime logDate, Boat chosenBoat)
    {
        DisplayChosenBoat(chosenBoat);

        Console.WriteLine($"1. Log description - {logDesc}");
        Console.WriteLine($"2. Log date - {logDate.ToString("dd/MM/yyyy HH:mm")}");
        Console.WriteLine();

        Console.WriteLine("C. Confirm");
        Console.WriteLine("Q. Cancel");
        Console.WriteLine();
    }
}
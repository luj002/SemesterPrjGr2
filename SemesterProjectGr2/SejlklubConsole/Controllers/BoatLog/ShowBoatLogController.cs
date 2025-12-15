public class ShowBoatLogController
{
    private IBoatLogEntryRepository _logRep;

    public ShowBoatLogController(IBoatLogEntryRepository givenRep)
    {
        _logRep = givenRep;
    }

    public List<BoatLogEntry> ShowLogs(string callType)
    {
        Console.Clear();

        Console.WriteLine("Logs are sorted by the date they occoured (Log1 = most recent log).");
        Console.WriteLine();

        List<BoatLogEntry> allLogs = _logRep.Entries;
        allLogs.Sort((valueA,valueB) => valueB.Timestamp.CompareTo(valueA.Timestamp));

        for (int index = 0; index < allLogs.Count; index++)
        {
            BoatLogEntry locatedLog = allLogs[index];
            Console.WriteLine($"Log{index + 1} = (Description: {locatedLog.Description} | Date: {locatedLog.Timestamp.ToString("dd/MM/yyyy HH:mm")})");
        }

        Console.WriteLine();

        if (callType == "display")
        {
            Console.Write("Press any key to return to boat selection.");
            Console.ReadLine();
        }

        return allLogs;

    }
}
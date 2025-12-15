public class RemoveBoatLogController
{
    private IBoatLogEntryRepository _logRep;

    public RemoveBoatLogController(IBoatLogEntryRepository givenRep)
    {
        _logRep = givenRep;
    }

    public void RemoveLog()
    {
        string callType = "remove";
        BoatLogEntry? logEntry = LogHelpers.PickLog(_logRep, callType);

        if (logEntry == null)
        {
            return;
        }

        _logRep.RemoveEntry(logEntry);

        Console.Clear();
        Console.WriteLine($"Log removed!");

        Console.WriteLine();
        Console.Write("Press any key to return to boat selection.");
        Console.ReadKey();
    }
}
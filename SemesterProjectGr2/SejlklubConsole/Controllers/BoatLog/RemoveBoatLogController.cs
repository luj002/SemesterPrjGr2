public class RemoveBoatLogController
{
    #region Instance field
    private IBoatLogEntryRepository _logRep;
    #endregion

    #region Constructor
    public RemoveBoatLogController(IBoatLogEntryRepository givenRep)
    {
        _logRep = givenRep;
    }
    #endregion

    #region Methods
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
    #endregion
}
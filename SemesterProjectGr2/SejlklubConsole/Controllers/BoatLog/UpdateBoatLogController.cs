public class UpdateBoatLogController
{
    #region Instance field
    private IBoatLogEntryRepository _logRep;
    private Boat _chosenBoat;
    #endregion

    #region Constructor
    public UpdateBoatLogController(IBoatLogEntryRepository givenRep, Boat givenBoat)
    {
        _logRep = givenRep;
        _chosenBoat = givenBoat;
    }
    #endregion

    #region Methods
    public void UpdateLog()
    {
        //Define logEntry
        string callType = "update";
        BoatLogEntry? logEntry = LogHelpers.PickLog(_logRep,callType);

        if (logEntry == null)
        {
            return;
        }

        //Input detection and overview/edit displaying
        string logDesc = logEntry.Description;
        DateTime logDate = logEntry.Timestamp;

        while (true)
        {
            Console.Clear();

            LogHelpers.DisplayOverview(logDesc,logDate,_chosenBoat);

            Console.Write("Your choice: ");
            string input = Console.ReadLine().ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true)
            {
                //Edit property
                if (chosenNumber == 1)
                {
                    logDesc = LogHelpers.DisplayEdit("Log description",_chosenBoat);
                }

                else if (chosenNumber == 2)
                {
                    logDate = LogHelpers.DisplayEdit("Log date. Format: day/month/year hour:minute. Example: 20/12/2010 03:54",_chosenBoat);
                }
            }

            else if (input == "q")
            {
                //Return and ignore log
                break;
            }

            else if (input == "c")
            {
                //Update log
                logEntry.Description = logDesc;
                logEntry.Timestamp = logDate;

                Console.Clear();
                Console.WriteLine($"Log for {_chosenBoat.Id} has been updated!");

                Console.WriteLine();
                Console.Write("Press any key to return to boat logging.");
                Console.ReadKey();

                break;
            }
        }
    }
    #endregion
}
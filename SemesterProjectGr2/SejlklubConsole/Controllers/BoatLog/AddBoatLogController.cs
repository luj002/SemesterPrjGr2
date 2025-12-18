using System.Globalization;

public class AddBoatLogController
{
    #region Instance field
    private IBoatLogEntryRepository _logRep;
    private Boat _chosenBoat;
    #endregion

    #region Constructor

    public AddBoatLogController(IBoatLogEntryRepository givenRep, Boat givenBoat)
    {
        _logRep = givenRep;
        _chosenBoat = givenBoat;
    }
    #endregion

    #region Methods

    public void AddLog()
    {
        //Input detection and overview/edit displaying
        string logDesc = "???";
        DateTime logDate = DateTime.Now;

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
                //Add log to boat
                BoatLogEntry logEntry = new BoatLogEntry(logDesc, logDate);
                _logRep.AddEntry(logEntry);

                Console.Clear();
                Console.WriteLine($"Log has been added to \"{_chosenBoat.Id}\"!");

                Console.WriteLine();
                Console.Write("Press any key to return to boat logging.");
                Console.ReadKey();

                break;
            }
        }
    }
    #endregion
}
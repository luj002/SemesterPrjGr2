using static System.Runtime.InteropServices.JavaScript.JSType;

public class AssignToBoatSpaceController
{
    #region Instance field
    private IBoatSpaceRepository _boatSpaceRepository;
    private IBoatRepository _boatRepository;
    #endregion

    #region Properties

    #endregion

    #region Constructor
    public AssignToBoatSpaceController(IBoatSpaceRepository boatSpaceRepository, IBoatRepository boatRepository)
    {
        _boatSpaceRepository = boatSpaceRepository;
        _boatRepository = boatRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// TO FILL OUT
    /// </summary>
    private void Assign()
    {
        List<string> choices = new List<string> {
            "1. Show boats",
            "2. Select boat",
            "3. Show boat spaces",
            "4. Select boat space",
            "\nC. Confirm",
            "Q. Cancel (Discard Boat Space)"
        };
        string theChoice = Helpers.ReadChoice(choices);
        while (theChoice != "c" && theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    BoatHelpers.SelectBoat(_boatRepository);
                    break;
                case "2":
                    break;
                case "3":
                    BoatSpaceHelpers.SelectBoatSpace(_boatSpaceRepository);
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any button to try again.");
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
        if (theChoice == "c")
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}

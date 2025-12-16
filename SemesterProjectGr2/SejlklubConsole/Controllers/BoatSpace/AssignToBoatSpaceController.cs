using static System.Runtime.InteropServices.JavaScript.JSType;

public class AssignToBoatSpaceController
{
    #region Instance field
    private IBoatSpaceRepository _boatSpaceRepository;
    private IBoatRepository _boatRepository;
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
/// Prompts the user to input the values needed to assign a boat to a boat space.
/// </summary>
    public void Assign()
    {
        List<string> choices = new List<string> {
            "1. Select boat",
            "2. Select boat space",
            "\nC. Confirm",
            "Q. Cancel (Discard Boat Space)"
        };
        Boat curBoat = null;
        BoatSpace curBoatSpace = null;
        string theChoice = Helpers.ReadChoice(choices);
        while (theChoice != "c" && theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    curBoat = BoatHelpers.SelectBoat(_boatRepository);
                    break;
                case "2":
                    curBoatSpace = BoatSpaceHelpers.SelectBoatSpace(_boatSpaceRepository);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any button to try again.");
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
        if (theChoice == "c")
        {
            AssignConfirm(curBoat, curBoatSpace);
        }
    }

    /// <summary>
    /// Asks for confirmation to assign the boat to the boat space, while checking for null values and already assigned values.
    /// </summary>
    /// <param name="boat">The boat to assign.</param>
    /// <param name="boatSpace">The boat space to assign to.</param>
    public void AssignConfirm(Boat boat, BoatSpace? boatSpace)
    {
        Console.WriteLine(boat);
        if(boatSpace != null)
        {
            Console.WriteLine(boatSpace);
        }
        else
        {
            Console.WriteLine("No boat space.");
        }
        bool AddConfirmed = Helpers.YesOrNo("Assign this boat to this boat space?") ?? false;
        if (AddConfirmed)
        {
            if(boatSpace.Boat == null)
            {
                if (boat.AssignedSpace != null)
                {
                    _boatSpaceRepository.GetBoatSpaceByNumber(Convert.ToInt32(boat.AssignedSpace)).Boat = null;
                }
                if (boatSpace != null)
                {
                    boat.AssignedSpace = boatSpace.Number;
                    boatSpace.Boat = boat;
                }
                else
                {
                    boat.AssignedSpace = null;
                }
            }
            else
            {
                Console.WriteLine($"Boat space already occupied by {boatSpace.Boat.ModelName}");
                Console.ReadKey();
            }
            
        }
    }
    #endregion
}

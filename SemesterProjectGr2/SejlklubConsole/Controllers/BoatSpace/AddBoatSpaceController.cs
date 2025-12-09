using System.Runtime.InteropServices;

public class AddBoatSpaceController
{
    #region Instance fields
    private BoatSpace _boatSpace;
    private IBoatSpaceRepository _boatSpaceRepository;
    #endregion

    #region Properties
    public BoatSpace BoatSpace
    {
        get { return _boatSpace; }
    }
    #endregion

    #region Constructor
	public AddBoatSpaceController(IBoatSpaceRepository boatSpaceRepository)
	{
        _boatSpaceRepository = boatSpaceRepository;
        Create();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Handles creation of new boat spaces using ReadLine inputs.
    /// </summary>
    /// <returns>A new boat space ready to be added.</returns>
    //private BoatSpace Create()
    //{
    //    List<string> boatSpaceInfoFields = new List<string> { "1. Number", "B. Back" };
    //    int number = 0;

    //    string theChoice = Helpers.ReadChoice(boatSpaceInfoFields);

    //    while (theChoice != "b")
    //    {
    //        switch (theChoice)
    //        {
    //            case "1":
    //                Console.Write("Enter number: ");
    //                number = Convert.ToInt32(Console.ReadLine());

    //                boatSpaceInfoFields[0] = $"1. Number - {number}";
    //                break;
    //            default:
    //                Console.WriteLine("Choose 1 or b to go back");
    //                break;
    //        }
    //        theChoice = Helpers.ReadChoice(boatSpaceInfoFields);
    //    }

    //    return new BoatSpace(number);
    //}

    private void Create()
    {
        List<string> choices = new List<string> {
            "1. Number",
            "\nC. Confirm",
            "Q. Cancel (Discard Boat Space)"
        };
        int number = 0;

        string theChoice = Helpers.ReadChoice(choices);

        while (theChoice != "c" && theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Console.Write("Enter number: ");
                    number = Convert.ToInt32(Console.ReadLine());

                    choices[0] = $"1. Number - {number}";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any button to try again.");
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }

        _boatSpace = new BoatSpace(number);
        if(theChoice == "c")
        {
            AddBoatSpace();
        }
    }

    /// <summary>
    /// Adds the boat space to the repository.
    /// </summary>
    public void AddBoatSpace()
	{
        Console.WriteLine(BoatSpace);
        bool AddConfirmed = Helpers.YesOrNo("Add this boat space?");
        if (AddConfirmed)
            _boatSpaceRepository.Add(BoatSpace);
	}
    #endregion
}


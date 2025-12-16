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
    }
    #endregion

    #region Methods
    /// <summary>
    /// Begins the process of creating a new boat space to add.
    /// </summary>
    public void Create()
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
                    int? numberInput = Helpers.IntFromReadLine("Enter number: ", 1, 255);
                    if (numberInput == null)
                        break;

                    number = (int)numberInput;

                    choices[0] = $"1. Number - {number}";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any button to try again.");
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
        if(theChoice == "c")
        {
            _boatSpace = new BoatSpace(number);
            AddBoatSpace();
        }
    }

    /// <summary>
    /// Adds the boat space to the repository.
    /// </summary>
    public void AddBoatSpace()
	{
        Console.WriteLine(_boatSpace);
        bool AddConfirmed = Helpers.YesOrNo("Add this boat space?") ?? false;
        if (AddConfirmed)
        {
            if(_boatSpaceRepository.GetBoatSpaceByNumber(_boatSpace.Number) == null)
            {
                _boatSpaceRepository.Add(_boatSpace);
            }
            else
            {
                Console.WriteLine("BoatSpace with that number already exists.");
                Console.ReadKey();
            }
        }
            
	}
    #endregion
}


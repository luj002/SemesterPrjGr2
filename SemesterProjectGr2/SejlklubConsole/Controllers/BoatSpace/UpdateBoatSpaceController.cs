using System.Net;
using System.Reflection;
using System.Xml.Linq;

public class UpdateBoatSpaceController
{
    #region Instance Fields
    private IBoatSpaceRepository _boatSpaceRepository;
    #endregion

    #region Constructors
    public UpdateBoatSpaceController(IBoatSpaceRepository boatSpaceRepository)
    {
        _boatSpaceRepository = boatSpaceRepository;
        BoatSpace = BoatSpaceHelpers.SelectBoatSpace(_boatSpaceRepository);
    }
    #endregion

    #region Properties
    public BoatSpace BoatSpace { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Updates the boat space within the repository.
    /// </summary>
    public void UpdateBoatSpace()
    {
        if (BoatSpace == null)
        {
            return;
        }
        int number = BoatSpace.Number;

        List<string> boatSpaceInfoFields = new List<string>
        {
            $"1. Number - {number}",
        };

        string theChoice = Helpers.ReadChoice(boatSpaceInfoFields);


        while (theChoice != "b")
        {
            switch (theChoice)
            {
                case "1":
                    Console.Write("Enter number: ");
                    number = Convert.ToInt32(Console.ReadLine());

                    boatSpaceInfoFields[0] = $"1. Number - {number}";
                    break;
                default:
                    Console.WriteLine("Choose 1 or b to go back");
                    break;
            }
            theChoice = Helpers.ReadChoice(boatSpaceInfoFields);
        }

        bool confirm = Helpers.YesOrNo("Save changes to boat space?") ?? false;

        if (confirm)
        {
            BoatSpace.Number = number;
            Console.WriteLine("Boat space updated successfully.");
        }
        else
        {
            Console.WriteLine("Changes discarded.");
        }
    }
    #endregion
}



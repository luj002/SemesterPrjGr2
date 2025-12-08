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
        _boatSpace = Create();
    }
    #endregion

    #region Methods
    private BoatSpace Create()
    {
        List<string> boatSpaceInfoFields = new List<string> { "1. Number", "B. Back" };
        int number = 0;

        string theChoice = ReadChoice(boatSpaceInfoFields);

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
            theChoice = ReadChoice(boatSpaceInfoFields);
        }

        return new BoatSpace(number);
    }

    private string ReadChoice(List<string> choices)
    {
        Console.Clear();
        foreach (string s in choices)
        {
            Console.WriteLine(s);
        }
        Console.Write("\nYour choice: ");
        string choice = Console.ReadLine();
        Console.Clear();

        return choice.ToLower();

	}

    /// <summary>
    /// Handles input of integers.
    /// </summary>
    /// <param name="inputDescription">Description for what will be assigned with the input</param>
    /// <param name="min">Minimum value for input</param>
    /// <param name="max">Maximum value for input</param>
    /// <returns>Int from ReadLine input in specified range</returns>
    private int IntFromReadLine(string inputDescription, int min, int max)
    {
        int input = 0;
        bool validInput = false;
        while (!validInput)
        {
            Console.Write($"{inputDescription} ");
            try
            {
                input = int.Parse(Console.ReadLine());

                if (input < min)
                    throw new ArgumentException($"Input must be at least {min}");

                if (input > max)
                    throw new ArgumentException($"Input must be less than {max}");

                validInput = true;
            }
            catch (ArgumentException aex)
            {
                Console.Clear();
                Console.WriteLine(aex.Message);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Input must be an integer");
            }
        }
        return input;
    }

    private bool YesOrNo(string question)
    {
        string input = "";
        bool choiceFinalized = false;
        while (!choiceFinalized)
        {
            Console.Write($"{question} [ y / n ]: ");
            try
            {
                input = Console.ReadLine().ToLower();
                if (input[0] != 'y' && input[0] != 'n')
                    throw new ArgumentException($"Input was not 'y' or 'n'");
                choiceFinalized = true;
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Input was not valid");
            }
        }
        return input[0] == 'y';
    }

    public void AddBoatSpace()
	{
        Console.WriteLine(BoatSpace);
        bool AddConfirmed = YesOrNo("Add this boat space?");
        if (AddConfirmed)
            _boatSpaceRepository.Add(BoatSpace);
	}
    #endregion
}


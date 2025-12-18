public class AddBoatController
{
    #region Instance field
    //Variables for class.
    private IBoatRepository _boatRep;
    private string _modelName;
    private BoatType _type;
    private double _length;
    private double _width;
    private double _draft;
    private string _buildYear;
    private string _nickname;
    private string _sailNumber;
    private string _motor;

    //Dynamic is to prevent type error when creating the BoatInstance. The variable types never change.
    private List<dynamic> _properties;
    #endregion

    #region Properties
    public bool ShouldAdd { get; set; }
    #endregion

    #region Constructor
    //Constructor initializes variables for controller object and calls the "DetectInput" function.
    public AddBoatController(IBoatRepository boatRep)
    {
        _boatRep = boatRep;
        _modelName = "???";
        _buildYear = "???";
        _nickname = "???";
        _sailNumber = "???";
        _motor = "???";
        _properties = new List<dynamic> { _modelName, _type, _length, _width, _draft, _buildYear, _nickname, _sailNumber, _motor, "", "cancel" };
        DetectInput();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Adds boat to boat repository. The console writing notifies the user that the boat has been succesfully added.
    /// </summary>
    public void AddBoat()
    {
        Boat BoatInstance = new Boat(_properties[0], _properties[1], _properties[2], _properties[3], _properties[4], _properties[5], _properties[6], _properties[7], _properties[8]);
        _boatRep.Add(BoatInstance);

        Console.Clear();
        Console.WriteLine($"Boat \"{_properties[0]}\" added!");
        
        Console.WriteLine();
        Console.Write("Press any key to return to boat selection.");
        Console.ReadKey();
    }

    /// <summary>
    /// Displays the variable editing.
    /// </summary>
    /// <param name="entry"> entry is the value of index chosenNumber in the list "options". entry example: "1. Model Name". </param>
    /// <param name="chosenNumber"> chosenNumber is the number that the user typed in DetectInput(). chosenNumber decides which property will be edited. </param>
    public void DisplayEdit(string entry,int chosenNumber)
    {
        while (true)
        {
            Console.Clear();

            //.Split splits the string entry into an array with the length of 2.
            //It uses the . to split the string at the dot ("4. Width" = {"4", " Width"})
            //We trim (remove) the white spaces (" Width" = "Width").
            //[1] means the split function returns index 1 of the array, which is "Width" in this example.
            string propertyName = entry.Split('.',2)[1].Trim();
            Console.WriteLine("Editing property: " + propertyName);

            var currentProperty = _properties[chosenNumber - 1];

            if (currentProperty is BoatType)
            {
                Helpers.PrintEnumerable(Enum.GetValues(typeof(BoatType)));
            }

            Console.Write("Value: ");
            string defaultInput = Console.ReadLine();
            dynamic handledInput = null;

            if (currentProperty is string)
            {
                handledInput = defaultInput;
            }

            else if (currentProperty is double)
            {
                if (double.TryParse(defaultInput, out double output))
                {
                    handledInput = output;
                }
            }

            else if (currentProperty is BoatType)
            {
                if (Enum.TryParse<BoatType>(defaultInput, true, out BoatType output) && Enum.IsDefined(typeof(BoatType), output))
                {
                    handledInput = output;
                }
            }

            if (handledInput != null)
            {
                _properties[chosenNumber - 1] = handledInput;
                break;
            }
        }

        Console.Clear();
    }

    /// <summary>
    /// Display overview of variables to edit.
    /// </summary>
    /// <param name="options"> options is a list that contains display information for AddBoatController. You can view the list at the top of DetectInput(). </param>
    public void DisplayOverview(List<string> options)
    {
        Console.WriteLine("Choose a property to edit:");
        Console.WriteLine();

        int count = 0;

        foreach (string option in options)
        {
            if (count < _properties.Count - 2)
            {
                Console.WriteLine($"{option} - {_properties[count]}");
            }

            else if (_properties[count] == "")
            {
                Console.WriteLine();
                Console.WriteLine($"{option}");
            }

            count += 1;
        }

        Console.WriteLine(options[10]);
        Console.WriteLine();
    }

    /// <summary>
    /// Detect input of user and display overview or edit.
    /// </summary>
    public void DetectInput()
    {
        List<string> options = new List<string> { "1. Model Name", "2. Boat Type", "3. Length", "4. Width", "5. Draft", "6. Build Year", "7. Nickname", "8. Sail Number", "9. Motor", "10. Done", "11. Cancel"};
        string input = "";

        while (true)
        {
            DisplayOverview(options);
            Console.Write("Your choice: ");
            input = Console.ReadLine()!.ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber < 10 && chosenNumber > 0)
            {
                DisplayEdit(options[chosenNumber - 1], chosenNumber);
            }

            else if (int.TryParse(input, out chosenNumber) == true && chosenNumber == 10)
            {
                ShouldAdd = true;
                break;
            }

            else if (int.TryParse(input, out chosenNumber) == true && chosenNumber == 11)
            {
                ShouldAdd = false;
                break;
            }

            Console.Clear();
        }
    }
    #endregion
}
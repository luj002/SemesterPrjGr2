public class AddBoatController
{
    
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
    
    public bool ShouldAdd { get; set;}

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

    //Adds boat to boat repository. The console writing notifies the user that the boat has been succesfully added.
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

    //Displays the variable editing.
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
                if (Enum.TryParse<BoatType>(defaultInput, true, out BoatType output))
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
    
    //Display overview of variables to edit
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

    //Detect input of user and display overview or edit
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

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber < 10)
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
}
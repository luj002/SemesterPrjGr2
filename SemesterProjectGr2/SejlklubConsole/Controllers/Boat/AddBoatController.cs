using System.Security.Cryptography;
using System.Text.RegularExpressions;

public class AddBoatController
{
    public struct Nothing {};
    
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
    private List<dynamic> _properties;

    public AddBoatController(IBoatRepository boatRep)
    {
        _boatRep = boatRep;
        _modelName = "???";
        _buildYear = "???";
        _nickname = "???";
        _sailNumber = "???";
        _motor = "???";
        _properties = new List<dynamic> { _modelName, _type, _length, _width, _draft, _buildYear, _nickname, _sailNumber, _motor, "" };
        DetectInput();
    }

    public void AddBoat()
    {
        Console.Clear();
        Console.WriteLine($"Boat \"{_properties[0]}\" added!");

        Console.Write("Press any key to return to boat selection.");
        Console.ReadKey();

        Console.Clear();

        Boat BoatInstance = new Boat(_properties[0], _properties[1], _properties[2], _properties[3], _properties[4], _properties[5], _properties[6], _properties[7], _properties[8]);
        _boatRep.Add(BoatInstance);
    }

    public Nothing DisplayEdit(string entry,int chosenNumber)
    {
        Console.Clear();

        string propertyName = Regex.Match(entry,@"^\s*\d+\.\s*(.+)$").Groups[1].Value;
        Console.WriteLine("Editing property: " + propertyName);

        var currentProperty = _properties[chosenNumber - 1];

        if (currentProperty is BoatType)
        {
            Lua.print(Enum.GetValues(typeof(BoatType)));
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
            if (Enum.TryParse<BoatType>(defaultInput,true,out BoatType output))
            {
                handledInput = output;
            }
        }

        if (handledInput == null)
        {
            return DisplayEdit(entry, chosenNumber);
        }

        _properties[chosenNumber - 1] = handledInput;

        Nothing nothing = new Nothing();
        return nothing;
    }

    public void DisplayOverview(List<string> options)
    {
        Console.WriteLine("Choose a property to edit:");
        Console.WriteLine();

        int count = 0;

        foreach (string option in options)
        {
            if (count < _properties.Count - 1)
            {
                Console.WriteLine($"{option} - {_properties[count]}");
            }

            else if (count == _properties.Count - 1)
            {
                Console.WriteLine();
                Console.WriteLine($"{option}");
            }

            count += 1;
        }

        Console.WriteLine();
    }

    public void DetectInput()
    {
        List<string> options = new List<string> { "1. Model Name", "2. Boat Type", "3. Length", "4. Width", "5. Draft", "6. Build Year", "7. Nickname", "8. Sail Number", "9. Motor", "10. Done" };
        string input = "";

        while (true)
        {
            DisplayOverview(options);
            Console.Write("Your choice: ");
            input = Console.ReadLine().ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber < options.Count)
            {
                DisplayEdit(options[chosenNumber - 1], chosenNumber);
            }

            else if (int.TryParse(input, out chosenNumber) == true && chosenNumber == options.Count)
            {
                break;
            }

            Console.Clear();
        }
    }
}
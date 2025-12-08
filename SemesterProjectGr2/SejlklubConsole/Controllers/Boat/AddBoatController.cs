using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class AddBoatController
{
    private IBoatRepository _boatRep;
    private string _modelName = "???";
    private BoatType _type;
    private double _length;
    private double _width;
    private double _draft;
    private string _buildYear = "???";
    private string _nickname = "???";
    private string _sailNumber = "???";
    private string _motor = "???";
    private List<dynamic> _properties;

    public AddBoatController(IBoatRepository boatRep)
    {
        _boatRep = boatRep;
        _properties = new List<dynamic> { _modelName, _type, _length, _width, _draft, _buildYear, _nickname, _sailNumber, _motor, "" };
        DetectInput();
    }

    public void AddBoat()
    {
        Lua.print(_properties[2]);
        Boat BoatInstance = new Boat(_properties[0], _properties[1], _properties[2], _properties[3], _properties[4], _properties[5], _properties[6], _properties[7], _properties[8]);
        _boatRep.Add(BoatInstance);
    }

    public void DisplayEdit(string entry,dynamic property)
    {
        Console.Clear();

        string propertyName = Regex.Match(entry,@"^\s*\d+\.\s*(.+)$").Groups[1].Value;
        Console.WriteLine("Editing property: " + propertyName);
        Console.Write("Value: ");

        property = Console.ReadLine();
    }

    public void DisplayOverview(List<string> options,List<dynamic> properties)
    {
        Console.WriteLine("Choose a property to edit:");
        Console.WriteLine();

        int count = 0;

        foreach (string option in options)
        {
            if (count < properties.Count - 1)
            {
                Console.WriteLine($"{option} - {properties[count]}");
            }

            else if (count == properties.Count - 1)
            {
                Console.WriteLine($"{option}");
            }

            count += 1;
        }

        Console.WriteLine();
    }

    public async Task DetectInput()
    {
        List<string> options = new List<string> { "1. Model Name", "2. Boat Type", "3. Length", "4. Width", "5. Draft", "6. Build Year", "7. Nickname", "8. Sail Number", "9. Motor", "10. Confirm" };
        string input = "";

        while (true)
        {
            DisplayOverview(options, _properties);
            Console.Write("Your choice: ");
            input = Console.ReadLine().ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber < options.Count)
            {
                DisplayEdit(options[chosenNumber - 1], _properties[chosenNumber - 1]);
            }

            else if (int.TryParse(input, out chosenNumber) == true && chosenNumber == options.Count)
            {
                AddBoat();

                Console.Clear();
                Console.WriteLine($"Boat {_properties[0]} added!");

                await Lua.wait(2);

                Console.Clear();
                break;
            }

            Console.Clear();
        }
    }
}
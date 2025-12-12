using System.Reflection;
using System.Text;

public class UpdateBoatController
{
	public Boat ChosenBoat { get; set; }
	private IBoatRepository _boatRep;

	public UpdateBoatController(IBoatRepository boatRepository)
	{
		_boatRep = boatRepository;
		DetectInput();
	}

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    /// <param name="givenProperty">TO FILL OUT!!!!!</param>
    /// <param name="givenValue">TO FILL OUT!!!!!</param>
	public void UpdateBoat(PropertyInfo givenProperty, object givenValue)
	{
        givenProperty.SetValue(ChosenBoat, givenValue);

        Console.Clear();
        Console.WriteLine($"Boat \"{ChosenBoat.Id}\" updated!");

        Console.WriteLine();
        Console.Write("Press any key to return to boat updating.");
        Console.ReadKey();
    }

    /// <summary>
    /// Converts merged text into spaced text (SailNumber --> Sail Number)
    /// </summary>
    /// <param name="propertyName">A string of merged text.</param>
    /// <returns>A string of spaced text.</returns>
    public string GetDisplayName(string propertyName)
    {
        StringBuilder displayName = new StringBuilder();
        displayName.Append(propertyName[0]);

        for (int index = 1; index < propertyName.Length; index++)
        {
            char previousCharacter = propertyName[index - 1];
            char currentCharacter = propertyName[index];

            if (char.IsLower(previousCharacter) && char.IsUpper(currentCharacter))
            {
                displayName.Append(' ');
            }

            displayName.Append(currentCharacter);
        }

        return displayName.ToString();
    }

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    /// <param name="chosenNumber">TO FILL OUT!!!!!</param>
    /// <param name="properties">TO FILL OUT!!!!!</param>
    public void DisplayEdit(int chosenNumber, List<PropertyInfo> properties)
    {
        while (true)
        {
            Console.Clear();

            var property = properties[chosenNumber - 1];
            string displayName = GetDisplayName(property.Name);
            Console.WriteLine("Editing property: " + displayName);

            Console.Write("Value: ");
            string defaultInput = Console.ReadLine();
            dynamic handledInput = null;

            if (property.PropertyType == typeof(string))
            {
                handledInput = defaultInput;
            }

            else if (property.PropertyType == typeof(double))
            {
                if (double.TryParse(defaultInput, out double output))
                {
                    handledInput = output;
                }
            }

            if (handledInput != null)
            {
                UpdateBoat(property,handledInput);
                break;
            }
        }
    }

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    /// <returns>TO FILL OUT!!!!!</returns>
    public List<PropertyInfo> DisplayOverview()
    {
        Console.WriteLine("Choose a property to edit:");
        Console.WriteLine();

        var properties = typeof(Boat).GetProperties().Where(property => property.Name != "Id" && property.Name != "Log" && property.Name != "AssignedSpace" && property.Name != "Type" && property.Name != "ModelName" && property.Name != "BuildYear").ToList();
        int count = 0;

        foreach (var property in properties)
        {
            count += 1;

            string displayName = GetDisplayName(property.Name);
            object displayValue = property.GetValue(ChosenBoat);

            if (displayValue == null)
            {
                displayValue = "???";
            }

            Console.WriteLine($"{count}. {displayName} - {displayValue}");
        }

        Console.WriteLine();
        Console.WriteLine("Q. Back");
        Console.WriteLine();

        return properties;
    }

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
	public void DetectInput()
	{
        //Pick boat.
        while (true)
        {
            Console.Clear();

            ShowBoatController SBC = new ShowBoatController(_boatRep);
            string callType = "update";
            SBC.ShowAllBoats(callType);

            Console.WriteLine("Q. Cancel");
            Console.WriteLine();

            Console.Write("Update boat by id number: ");
            string input = Console.ReadLine();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true)
            {
                string BoatID = "#BOAT_" + chosenNumber.ToString("0000");
                ChosenBoat = _boatRep.GetBoatById(BoatID);
                break;
            }

            else if (input == "q")
            {
                return;
            }
        }

        //Edit boat.
        while (true)
        {
            Console.Clear();

            List<PropertyInfo> properties = DisplayOverview();
            int propertyAmount = properties.Count;

            Console.Write("Your choice: ");
            string input = Console.ReadLine().ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber <= propertyAmount && chosenNumber > 0)
            {
                DisplayEdit(chosenNumber,properties);
            }

            else if (input == "q")
            {
                break;
            }
        }
    }
}

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
    /// UpdateBoat() takes the givenProperty and sets it to givenValue. 
    /// Afterwards it tells the user that the boat has been updated.
    /// </summary>
    /// <param name="givenProperty"> Property passed as the 1st argument. It is a "PropertyInfo" which has a SetValue() function. </param>
    /// <param name="givenValue"> The value that is used to update the boat property. For example: ModelName (givenProperty) = "TheGorba2000" (givenValue). </param>
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
    /// Displays the property to edit, and uses the user input to call UpdateBoat().
    /// </summary>
    /// <param name="chosenNumber"> The number that the user typed in. It determines which property that is being edited. </param>
    /// <param name="properties"> List of properties that is returned from DisplayOverview(). </param>
    public void DisplayEdit(int chosenNumber, List<PropertyInfo> properties)
    {
        while (true)
        {
            Console.Clear();

            PropertyInfo property = properties[chosenNumber - 1];
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
    /// Displays properties that can be updated (those that have set; in their property field).
    /// </summary>
    /// <returns> Returns a list of boat properties. 
    /// You can see the properties list being defined by the GetProperties(). Where() excludes properties that do not have set; in their property field. </returns>
    public List<PropertyInfo> DisplayOverview()
    {
        Console.WriteLine("Choose a property to edit:");
        Console.WriteLine();

        List<PropertyInfo> properties = typeof(Boat).GetProperties().Where(property => property.Name != "Id" && property.Name != "Log" && property.Name != "AssignedSpace" && property.Name != "Type" && property.Name != "ModelName" && property.Name != "BuildYear").ToList();
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
    /// Pick boat: Shows boats, and then detects user input for a boat id to pick a boat.
    /// Edit boat: Displays property overview and waits for user input. The input that is handled as "chosenNumber", determines which property will be edited in DisplayEdit().
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

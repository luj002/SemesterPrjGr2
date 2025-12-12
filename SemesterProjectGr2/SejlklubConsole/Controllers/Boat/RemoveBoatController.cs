
public class RemoveBoatController
{
    public string BoatID { get; set; }
    private IBoatRepository _boatRep;

    public RemoveBoatController(IBoatRepository boatRep)
    {
        BoatID = "";
        _boatRep = boatRep;
    }

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
	public void Remove()
    {
        _boatRep.Remove(BoatID);

        Console.Clear();
        Console.WriteLine($"Boat \"{BoatID}\" removed!");

        Console.WriteLine();
        Console.Write("Press any key to return to boat selection.");
        Console.ReadKey();
    }

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
	public void RemoveBoat()
	{
        while (true)
        {
            Console.Clear();

            ShowBoatController SBC = new ShowBoatController(_boatRep);
            string callType = "remove";
            SBC.ShowAllBoats(callType);

            Console.WriteLine("Q. Cancel");
            Console.WriteLine();

            Console.Write("Remove boat by id number: ");
            string input = Console.ReadLine().ToLower();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber < 10)
            {
                BoatID = "#BOAT_" + chosenNumber.ToString("0000");
                Remove();
                break;
            }

            else if (input == "q")
            {
                break;
            }
        }

        Console.Clear();
    }
}
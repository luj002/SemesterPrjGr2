public class RemoveBoatController
{
    #region Instance field
    public string BoatID { get; set; }
    private IBoatRepository _boatRep;
    #endregion

    #region Constructor
    public RemoveBoatController(IBoatRepository boatRep)
    {
        BoatID = "";
        _boatRep = boatRep;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Removes boat by calling the BoatRepository Remove() function.
    /// It then tells the user the boat has been removed.
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
    /// Waits for the user to input an id of the boat they want to delete.
    /// The BoatID variable is defined based on user input, so RemoveBoat() can call Remove().
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

            if (int.TryParse(input, out chosenNumber) == true)
            {
                BoatID = "#BOAT_" + chosenNumber.ToString("0000");
                Boat? chosenBoat = _boatRep.GetBoatById(BoatID);

                if (chosenBoat == null)
                {
                    continue;
                }

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
    #endregion
}
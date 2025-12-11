public class UpdateBoatController
{
	public Boat ChosenBoat { get; set; }
	private IBoatRepository _boatRep;

	public UpdateBoatController(IBoatRepository boatRepository)
	{
		_boatRep = boatRepository;
		DetectInput();
	}

	public void UpdateBoat()
	{
        Console.WriteLine("updating boat...");

        Console.Clear();
        Console.WriteLine($"Boat \"{ChosenBoat.Id}\" updated!");

        Console.WriteLine();
        Console.Write("Press any key to return to boat selection.");
        Console.ReadKey();
    }

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

            if (int.TryParse(input, out chosenNumber) == true && chosenNumber < 10)
            {
                string BoatID = "#BOAT_" + chosenNumber.ToString("0000");
                ChosenBoat = _boatRep.GetBoatById(BoatID);
                break;
            }

            else if (input == "q")
            {
                break;
            }
        }

        Console.Clear();

        //Edit boat.
    }
}

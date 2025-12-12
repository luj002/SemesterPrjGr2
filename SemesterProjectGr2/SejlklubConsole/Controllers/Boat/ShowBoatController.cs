public class ShowBoatController
{
	IBoatRepository _boatRep;

	public ShowBoatController(IBoatRepository boatRepository)
	{
		_boatRep = boatRepository;
	}

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    /// <param name="callType">TO FILL OUT!!!!!</param>
    public void ShowAllBoats(string callType)
	{
		List<Boat> allBoats = _boatRep.GetAll();
        
		for (int index = 0; index < allBoats.Count; index++)
		{
			Boat locatedBoat = allBoats[index];
            Console.WriteLine($"{locatedBoat.Id}: {locatedBoat}");
            Console.WriteLine();
		}

		if (callType == "display")
		{
            Console.Write("Press any key to return to boat selection.");
            Console.ReadLine();
        }
	}
}

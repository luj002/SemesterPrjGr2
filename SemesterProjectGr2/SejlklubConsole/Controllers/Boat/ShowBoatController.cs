public class ShowBoatController
{
	IBoatRepository _boatRep;

	public ShowBoatController(IBoatRepository boatRepository)
	{
		_boatRep = boatRepository;
	}

	public void ShowAllBoats()
	{
		List<Boat> allBoats = _boatRep.GetAll();
        
		for (int index = 0; index < allBoats.Count; index++)
		{
			Boat locatedBoat = allBoats[index];
            Console.WriteLine($"{locatedBoat.Id}: {locatedBoat}");
            Console.WriteLine();
		}

        Console.Write("Press any key to return to boat selection.");
        Console.ReadLine();
	}
}

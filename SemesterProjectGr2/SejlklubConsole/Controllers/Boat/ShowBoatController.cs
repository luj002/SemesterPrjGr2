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
	}
}

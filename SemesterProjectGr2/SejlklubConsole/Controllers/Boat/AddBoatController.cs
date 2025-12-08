
public class AddBoatController
{
    public Boat BoatInstance { get; set; }
    private IBoatRepository _boatRep;

    public AddBoatController(IBoatRepository boatRep, string modelName, BoatType type, double length, double width, double buildYear, string nickname, string sailNumber, string motor)
    {
        BoatInstance = new Boat(modelName, type, length, width, buildYear, nickname, sailNumber, motor);
        _boatRep = boatRep;
    }

	public AddBoatController(IBoatRepository boatRepository)
	{
	}

	public void Add()
    {
        _boatRep.Add(BoatInstance);
    }

	internal void AddBoat()
	{
		throw new NotImplementedException();
	}
}
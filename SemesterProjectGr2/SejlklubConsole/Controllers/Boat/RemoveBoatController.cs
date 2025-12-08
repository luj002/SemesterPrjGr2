
public class RemoveBoatController
{
    public string BoatID { get; set; }
    private IBoatRepository _boatRep;

    public RemoveBoatController(IBoatRepository boatRep, string id)
    {
        BoatID = id;
        _boatRep = boatRep;
    }

	public RemoveBoatController(IBoatRepository boatRepository)
	{
	}

	public void Remove()
    {
        _boatRep.Remove(BoatID);
    }

	internal void RemoveBoat()
	{
		throw new NotImplementedException();
	}
}
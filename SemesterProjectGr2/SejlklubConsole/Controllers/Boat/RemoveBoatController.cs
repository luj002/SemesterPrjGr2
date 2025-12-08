public class RemoveBoatController
{
<<<<<<< HEAD
	public RemoveBoatController(IBoatRepository boatRepository)
	{
		throw new NotImplementedException();
	}
}
=======
    public int BoatID { get; set; }
    private IBoatRepository _boatRep;

    public RemoveBoatController(IBoatRepository boatRep, int id)
    {
        BoatID = id;
        _boatRep = boatRep;
    }
    
    public void Remove()
    {
        _boatRep.Remove(BoatID);
    }
}
>>>>>>> 6b6d3b5a8c4416d43d846a50edf3f042283b3fcf

public class AddBoatController
{
    public Boat BoatInstance { get; set; }
    private IBoatRepository _boatRep;

<<<<<<< HEAD
	public AddBoatController(IBoatRepository boatRepository)
	{
		throw new NotImplementedException();
	}
	public AddBoatController(IBoatRepository boatRep, string modelName, BoatType type, double length, double width, double buildYear, string nickname, string sailNumber, string motor)
=======
    public AddBoatController(IBoatRepository boatRep, string modelName, BoatType type, double length, double width, double buildYear, string nickname, string sailNumber, string motor)
>>>>>>> 6b6d3b5a8c4416d43d846a50edf3f042283b3fcf
    {
        BoatInstance = new Boat(modelName, type, length, width, buildYear, nickname, sailNumber, motor);
        _boatRep = boatRep;
    }
    
    public void Add()
    {
        _boatRep.Add(BoatInstance);
    }
<<<<<<< HEAD
}

=======
}
>>>>>>> 6b6d3b5a8c4416d43d846a50edf3f042283b3fcf

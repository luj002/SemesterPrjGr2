public class BoatSpace
{
	public int Number { get; set; }
	public bool Occupied
	{
		get
		{
			return Boat != null;
		}
	}
	public Boat? Boat { get; set; }
	public BoatSpace(int number, Boat? boat = null)
	{
		Number = number;
		Boat = boat;
	}
	public override string ToString()
	{
		return $"Boat Space {Number}: {(Occupied ? $"Occupied by {Boat}" : "Available")}";
	}

	public BoatSpace AssignSpace(Boat boat)
	{
        throw new NotImplementedException();
    }
}
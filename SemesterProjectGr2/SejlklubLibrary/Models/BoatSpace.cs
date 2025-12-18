public class BoatSpace
{
    #region Properties
    public int Number { get; set; }
	public bool Occupied
	{
		get
		{
			return Boat != null;
		}
	}
	public Boat? Boat { get; set; }
    #endregion

    #region Constructor
    public BoatSpace(int number, Boat? boat = null)
	{
		Number = number;
		Boat = boat;
	}
	public BoatSpace()
	{

    }
    #endregion

    #region Methods
    public override string ToString()
	{
		return $"Boat Space {Number}: {(Occupied ? $"Occupied by {Boat}" : "Available")}";
	}
    #endregion
}
public class ShowBoatController
{
    #region Instance field
    IBoatRepository _boatRep;
    #endregion

    #region Constructor

    public ShowBoatController(IBoatRepository boatRepository)
	{
		_boatRep = boatRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Loops over a list of all boats.
    /// </summary>
    /// <param name="callType"> Determines where the function was called from. This is so that only the "display" callType will display the message. </param>
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
    #endregion
}

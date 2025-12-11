
public class RemoveBoatController
{
    public string BoatID { get; set; }
    private IBoatRepository _boatRep;

    public RemoveBoatController(IBoatRepository boatRep)
    {
        BoatID = "";
        _boatRep = boatRep;
    }

	public void Remove()
    {
        _boatRep.Remove(BoatID);
    }

	internal void RemoveBoat()
	{
		ShowBoatController SBC = new ShowBoatController(_boatRep);
        string callType = "remove";
        SBC.ShowAllBoats(callType);

        Console.Write("Remove boat by id number: ");
        Console.WriteLine("Q. Cancel");
	}
}
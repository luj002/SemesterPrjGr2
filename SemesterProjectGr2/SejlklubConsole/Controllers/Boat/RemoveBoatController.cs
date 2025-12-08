public class RemoveBoatController
{
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
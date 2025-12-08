public class AddBoatController
{
    public Boat BoatInstance { get; set; }
    private IBoatRepository _boatRep;

    public AddBoatController(IBoatRepository boatRep)
    {
        _boatRep = boatRep;
    }
    
    public void Add(string modelName, BoatType type, double length, double width, double draft, string buildYear, string nickname, string sailNumber, string motor)
    {
        BoatInstance = new Boat(modelName,type,length,width,draft,buildYear,nickname,sailNumber,motor);
        _boatRep.Add(BoatInstance);
    }
}
public class ShowBoatsController
{
    private IBoatRepository _boatRep;

    public ShowBoatsController(IBoatRepository boatRep)
    {
        _boatRep = boatRep;
    }

    public void Show()
    {
        Console.WriteLine("Boat List;");

        foreach (var locatedBoat in _boatRep.GetAll())
        {
            Console.WriteLine(locatedBoat);
        }
    }
}
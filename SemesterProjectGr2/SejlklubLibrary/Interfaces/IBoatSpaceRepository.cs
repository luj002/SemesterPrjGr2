public interface IBoatSpaceRepository
{
    int Count { get; }
    List<BoatSpace> GetAll();
    void Add(BoatSpace boatSpace);
    Boat? GetBoatSpaceByNumber(int number);
    void Remove(int number);
}

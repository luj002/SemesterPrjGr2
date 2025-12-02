public interface IBoatSpaceRepository
{
    int Count { get; }
    List<BoatSpace> GetAll();
    void Add(BoatSpace boatSpace);
    BoatSpace? GetBoatSpaceByNumber(int number);
    void Remove(int number);
}

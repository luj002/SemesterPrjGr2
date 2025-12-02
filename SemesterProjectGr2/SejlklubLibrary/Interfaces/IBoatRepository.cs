public interface IBoatRepository
{
    int Count { get; }
    List<Boat> GetAll();
    void Add(Boat boat);
    Boat? GetBoatById(int id);
    void Remove(int id);
}


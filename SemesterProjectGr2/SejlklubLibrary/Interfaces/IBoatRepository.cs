public interface IBoatRepository
{
    int Count { get; }
    List<Boat> GetAll();
    void Add(Boat boat);
    Boat? GetBoatById(string id);
    void Remove(string id);
}


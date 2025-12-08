public class BoatRepository : IBoatRepository
{
    #region Instance field
    private Dictionary<string, Boat> _boats;
    #endregion

    #region Properties
    public int Count { get { return GetAll().Count; } }
    #endregion

    #region Constructor
    public BoatRepository()
    {
        _boats = new Dictionary<string, Boat>();
    }
    #endregion

    #region Methods
    public List<Boat> GetAll()
    {
        return _boats.Values.ToList();
    }

    public void Add(Boat boat)
    {
        if (!_boats.TryAdd(boat.Id, boat))
        {
            throw new RepositoryException(RepositoryExceptionType.Add, "Boat with the given id already exists.");
        }
    }

    public Boat? GetBoatById(string id)
    {
        if(_boats.TryGetValue(id, out Boat? value))
        {
            return value;
        }
        else
        {
            return null;
        }
    }

    public void Remove(string id)
    {
        if(_boats.TryGetValue(id, out Boat? value))
        {
            _boats.Remove(id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Remove, "No boat with the given id found.");
        }
    }
    #endregion
}
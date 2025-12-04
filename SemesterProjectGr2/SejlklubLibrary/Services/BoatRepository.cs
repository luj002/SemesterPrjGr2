public class BoatRepository
{
    #region Instance field
    private Dictionary<int, Boat> _boats;
    #endregion

    #region Properties
    public int Count { get { return GetAll().Count; } }
    #endregion

    #region Constructor
    public BoatRepository()
    {
        _boats = new Dictionary<int, Boat>();
    }
    #endregion

    #region Methods
    public List<Boat> GetAll()
    {
        return _boats.Values.ToList();
    }

    public void AddBoat(Boat boat)
    {
        if (!_boats.TryAdd(boat.Id, boat))
        {
            throw new RepositoryException(RepositoryExceptionType.Add, "Boat with the given id already exists.");
        }
    }

    public Boat? GetBoatById(int id)
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

    public void Remove(int id)
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
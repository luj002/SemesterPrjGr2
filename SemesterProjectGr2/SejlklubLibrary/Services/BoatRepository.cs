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

    }
    #endregion

    #region Methods
    public List<Boat> GetAll()
    {
        return _boats.Values.ToList();
    }

    public void AddBoat(Boat boat)
    {
        _boats.Add(boat.Id, boat);
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
    }
    #endregion
}
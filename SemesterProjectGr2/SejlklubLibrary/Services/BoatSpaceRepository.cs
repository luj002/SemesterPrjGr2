
public class BoatSpaceRepository : IBoatSpaceRepository
{
    #region Instance fields
    private Dictionary<int, BoatSpace> _boatSpaces;
    #endregion

    #region Properties
    public int Count
    {
        get { return _boatSpaces.Count; }
    }
    #endregion

    #region Constructor
    public BoatSpaceRepository()
    {
        _boatSpaces = new Dictionary<int, BoatSpace>();
    }
    #endregion

    #region Methods
    public void Add(BoatSpace boatSpace)
    {
        if (!_boatSpaces.TryAdd(boatSpace.Number, boatSpace))
            throw new RepositoryException(RepositoryExceptionType.Add, "BoatSpace with that number already exists");
    }

    public List<BoatSpace> GetAll()
    {
        return _boatSpaces.Values.ToList();
    }

    public BoatSpace? GetBoatSpaceByNumber(int number)
    {
        return (_boatSpaces.ContainsKey(number)) ? _boatSpaces[number] : null;
    }

    public void Remove(int number)
    {
        _boatSpaces.Remove(number);
    }
    #endregion
}


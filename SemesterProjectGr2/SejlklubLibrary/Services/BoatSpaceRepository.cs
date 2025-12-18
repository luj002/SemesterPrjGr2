
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
    /// <summary>
    /// Adds a boat space to the repository
    /// </summary>
    /// <param name="boatSpace">The boat space to add</param>
    public void Add(BoatSpace boatSpace)
    {
        if (!_boatSpaces.TryAdd(boatSpace.Number, boatSpace))
            throw new RepositoryException(RepositoryExceptionType.Add, "BoatSpace with that number already exists");
    }

    /// <summary>
    /// Gets all boat spaces in the repository.
    /// </summary>
    /// <returns>List of all boat spaces</returns>
    public List<BoatSpace> GetAll()
    {
        return _boatSpaces.Values.ToList();
    }

    /// <summary>
    /// Gets a boat space by its number.
    /// </summary>
    /// <param name="number">The number of the boat space to get</param>
    /// <returns>The boat space with the given number or null if none was found</returns>
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


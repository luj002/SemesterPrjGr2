public class BookingRepository : IBookingRepository
{
    #region Instance fields
    private Dictionary<string, Booking> _nonArchivedBookings;
    private Dictionary<string, Booking> _archivedBookings;
    #endregion

    #region Properties
    public int Count
    {
        get
        {
            return _nonArchivedBookings.Count + _archivedBookings.Count;
        }
    }
    #endregion

    #region Constructor
    public BookingRepository()
    {
        _nonArchivedBookings = new Dictionary<string, Booking>();
        _archivedBookings = new Dictionary<string, Booking>();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Gets all bookings in the repository.
    /// </summary>
    /// <returns>List containing all the bookings in the repository</returns>
    public List<Booking> GetAll()
    {
        Dictionary<string, Booking> allBookings = new Dictionary<string, Booking>(_archivedBookings);
        foreach (var booking in _nonArchivedBookings)
        {
            allBookings[booking.Key] = booking.Value;
        }
        return allBookings.Values.ToList();
    }

    /// <summary>
    /// Gets all non-archived bookings in the repository.
    /// </summary>
    /// <returns>List of all non-archived bookings</returns>
    public List<Booking> GetAllNonArchived()
    {
        return _nonArchivedBookings.Values.ToList();
    }

    /// <summary>
    /// Gets all archived bookings in the repository
    /// </summary>
    /// <returns>List of all archived bookings</returns>
    public List<Booking> GetAllArchived()
    {
        return _archivedBookings.Values.ToList();
    }

    /// <summary>
    /// Archives a booking by moving it from the non-archived dictionary to the archived dictionary.
    /// </summary>
    /// <param name="id">Id of the booking to archive</param>
    public void Archive(string id)
    {
        if (_nonArchivedBookings.ContainsKey(id))
        {
            _archivedBookings[id] = _nonArchivedBookings[id];
            _nonArchivedBookings.Remove(id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Archive, "No booking found to archive.");
        }
    }

    /// <summary>
    /// Adds a booking to the repository if the booking isn't already in the repository
    /// </summary>
    /// <param name="givenBooking">The booking to add to the repository</param>
    public void Add(Booking givenBooking)
    {
        if (!_nonArchivedBookings.ContainsKey(givenBooking.Id) && !_archivedBookings.ContainsKey(givenBooking.Id))
        {
            _nonArchivedBookings[givenBooking.Id] = givenBooking;
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Add, "Given booking is already in the bookings dictionary.");
        }
    }

    /// <summary>
    /// Removes a booking from the repository
    /// </summary>
    /// <param name="id">Id of the booking to remove</param>
    public void Remove(string id)
    {
        if (_nonArchivedBookings[id] != null)
        {
            _nonArchivedBookings.Remove(id);
        }
        else if (_archivedBookings[id] != null)
        {
            _archivedBookings.Remove(id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Remove, "No booking found to remove.");
        }
    }

    /// <summary>
    /// Gets a booking by its id
    /// </summary>
    /// <param name="id">The id of the booking to return</param>
    /// <returns>The booking with the given Id</returns>
    public Booking? GetBookingById(string id)
    {
        if (_nonArchivedBookings.ContainsKey(id))
        {
            return _nonArchivedBookings[id];
        }
        else if (_archivedBookings.ContainsKey(id))
        {
            return _archivedBookings[id];
        }
        return null;
    }

    /// <summary>
    /// Sorts all bookings by start time using QuickSort algorithm.
    /// </summary>
    /// <returns>List containing all bookings sorted by their StartTime property</returns>
    public List<Booking> BookingsSortedByStartTime()
    {
        List<Booking> allBookings = GetAll();
        BookingStartTimeQuickSort.QuickSort(allBookings, 0, (allBookings.Count-1));
        return allBookings;
    }
    #endregion
}
public class BookingRepository : IBookingRepository
{
    private Dictionary<string, Booking> _nonArchivedBookings;
    private Dictionary<string, Booking> _archivedBookings;
    public int Count
    {
        get
        {
            return _nonArchivedBookings.Count + _archivedBookings.Count;
        }
    }

    public BookingRepository()
    {
        _nonArchivedBookings = new Dictionary<string, Booking>();
        _archivedBookings = new Dictionary<string, Booking>();
    }

    public List<Booking> GetAll()
    {
        Dictionary<string, Booking> allBookings = new Dictionary<string, Booking>(_archivedBookings);
        foreach (var booking in _nonArchivedBookings)
        {
            allBookings[booking.Key] = booking.Value;
        }
        return allBookings.Values.ToList();
    }

    public List<Booking> GetAllNonArchived()
    {
        return _nonArchivedBookings.Values.ToList();
    }
    public List<Booking> GetAllArchived()
    {
        return _archivedBookings.Values.ToList();
    }

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
}
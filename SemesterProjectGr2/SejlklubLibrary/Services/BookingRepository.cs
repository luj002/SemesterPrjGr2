public class BookingRepository : IBookingRepository
{
    private Dictionary<string, Booking> _bookings;
    private Dictionary<string, Booking> _archivedBookings;
    public int Count
    {
        get
        {
            return _bookings.Count + _archivedBookings.Count;
        }
    }

    public BookingRepository()
    {
        _bookings = new Dictionary<string, Booking>();
        _archivedBookings = new Dictionary<string, Booking>();
    }

    public List<Booking> GetAll()
    {
        Dictionary<string, Booking> allBookings = new Dictionary<string, Booking>(_archivedBookings);
        foreach (var booking in _bookings)
        {
            allBookings[booking.Key] = booking.Value;
        }
        return allBookings.Values.ToList();
    }

    public List<Booking> GetAllNonArchived()
    {
        return _bookings.Values.ToList();
    }
    public List<Booking> GetAllArchived()
    {
        return _archivedBookings.Values.ToList();
    }

    public void Archive(string id)
    {
        if (_bookings.ContainsKey(id))
        {
            _archivedBookings[id] = _bookings[id];
            _bookings.Remove(id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Update, "No booking found to archive.");
        }
    }

    public void Add(Booking givenBooking)
    {
        if (!_bookings.ContainsKey(givenBooking.Id) && !_archivedBookings.ContainsKey(givenBooking.Id))
        {
            _bookings[givenBooking.Id] = givenBooking;
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Add, "Given booking is already in the bookings dictionary.");
        }
    }

    public void Remove(string id)
    {
        if (_bookings[id] != null)
        {
            _bookings.Remove(id);
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
        if (_bookings.ContainsKey(id))
        {
            return _bookings[id];
        }
        else if (_archivedBookings.ContainsKey(id))
        {
            return _archivedBookings[id];
        }
        return null;
    }
}
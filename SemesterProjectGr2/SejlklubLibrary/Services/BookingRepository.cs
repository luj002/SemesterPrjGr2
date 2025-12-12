public class BookingRepository : IBookingRepository
{
    private Dictionary<string, Booking> _bookings;
    private Dictionary<string, Booking> _archivedBookings;
    public int Count
    {
        get
        {
            return _bookings.Count;
        }
    }

    public BookingRepository()
    {
        _bookings = new Dictionary<string, Booking>();
        _archivedBookings = new Dictionary<string, Booking>();
    }

    public List<Booking> GetAll()
    {
        return _bookings.Values.ToList();
    }

    public void Add(Booking givenBooking)
    {
        if (!_bookings.ContainsKey(givenBooking.Id))
        {
            _bookings[givenBooking.Id] = givenBooking;
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Add, "Given booking is already in the bookings dictionary.");
        }
    }

    public void ArchiveBooking(string id)
    {
        if (_bookings.ContainsKey(id))
        {
            Booking bookingToArchive = _bookings[id];
            _archivedBookings[id] = bookingToArchive;
            _bookings.Remove(id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Remove, "No booking found to Remove.");
        }
    }

    public void Remove(string id)
    {
        if (_bookings[id] != null)
        {
            _bookings.Remove(id);
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
        return null;
    }
}
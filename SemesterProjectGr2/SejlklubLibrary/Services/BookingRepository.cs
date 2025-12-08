public class BookingRepository : IBookingRepository
{
    private Dictionary<string, Booking> _bookings;
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
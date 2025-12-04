public class BookingRepository
{
    private Dictionary<int,Booking> _bookings = new Dictionary<int,Booking>();
    public int Count
    {
        get
        {
            return _bookings.Count;
        }
    }

    public BookingRepository()
    {

    }

    public List<Booking> GetAll()
    {
        return _bookings.Values.ToList();
    }

    public void AddBooking(Booking givenBooking)
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

    public void RemoveBooking(Booking givenBooking)
    {
        if (_bookings.ContainsValue(givenBooking))
        {
            _bookings.Remove(givenBooking.Id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Remove, "No booking found to remove.");
        }
    }

    public Booking? GetBookingByID(int id)
    {
        if (_bookings.ContainsKey(id))
        {
            return _bookings[id];
        }
        return null;
    }
}
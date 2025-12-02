public interface IBookingRepository
{
    int Count { get; }
    List<Booking> GetAll();
    void Add(Booking booking);
    Booking? GetBookingById(int id);
    void Remove(int id);
}


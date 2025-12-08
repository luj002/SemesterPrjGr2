public interface IBookingRepository
{
    int Count { get; }
    List<Booking> GetAll();
    void Add(Booking booking);
    Booking? GetBookingById(string id);
    void Remove(string id);
}


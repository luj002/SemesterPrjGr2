public interface IBookingRepository
{
    int Count { get; }
    List<Booking> GetAll();
    List<Booking> GetAllNonArchived();
    List<Booking> GetAllArchived();
    void Add(Booking booking);
    void Archive(string id);
    Booking? GetBookingById(string id);
    void Remove(string id);
}


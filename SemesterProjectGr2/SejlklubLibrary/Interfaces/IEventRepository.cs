public interface IEventRepository
{
    List<Event> GetAll();
    void AddEvent(Event givenEvent);
    void RemoveEvent(Event givenEvent);
    int Count { get; }
    Event? GetEventByID(string id);
}
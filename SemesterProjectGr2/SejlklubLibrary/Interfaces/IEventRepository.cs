public interface IEventRepository
{
    List<Event> GetAll();
    void AddEvent(Member givenMember);
    void RemoveEvent(Member givenMember);
    int Count { get; }
}
public class EventRepository : IEventRepository
{
    private Dictionary<int,Event> _events = new Dictionary<int,Event>();
    public int Count { 
        
        get
        {
            return _events.Count;
        }

    }

    public EventRepository()
    {}

    public List<Event> GetAll()
    {
        return _events.Values.ToList();
    }

    public Event? GetEventByID(int id)
    {
        if (_events.ContainsKey(id))
        {
            return _events[id];
        }

        return null;
    }

    public void AddEvent(Event givenEvent)
    {
        if (!_events.ContainsKey(givenEvent.Id))
        {
            _events[givenEvent.Id] = givenEvent;
        }

        else
        {
            throw new RepositoryException(RepositoryExceptionType.Create,"given event is already in the events dictionary");
        }
    }

    public void RemoveEvent(Event givenEvent)
    {
        if (_events.ContainsValue(givenEvent))
        {
            _events.Remove(givenEvent.Id);
        }
    }
}
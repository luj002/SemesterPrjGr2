public class EventRepository : IEventRepository
{
    private Dictionary<int,Event> _events;
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
        if (_events[id] != null)
        {
            return _events[id];
        }

        else
        {
            throw new Exception("invalid id given");
        }
    }

    public void AddEvent(Event givenEvent)
    {
        if (_events[givenEvent.Id] == null)
        {
            _events[givenEvent.Id] = givenEvent;
        }

        else
        {
            throw new Exception("invalid event given");
        }
    }

    public void RemoveEvent(Event givenEvent)
    {
        _events.Remove(givenEvent.Id);
    }
}
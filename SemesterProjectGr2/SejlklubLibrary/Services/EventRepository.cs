public class EventRepository : IEventRepository
{
    #region Instance field
    private Dictionary<string, Event> _events;
    #endregion

    #region Properties
    public int Count { 
        
        get
        {
            return _events.Count;
        }

    }
    #endregion

    #region Constructor
    public EventRepository()
    {
        _events = new Dictionary<string, Event>();
    }
    #endregion

    #region Methods
    public List<Event> GetAll()
    {
        return _events.Values.ToList();
    }

    public Event? GetEventByID(string id)
    {
        if (_events.ContainsKey(id))
        {
            return _events[id];
        }
        else
        {
            return null;
        }
    }

    public void AddEvent(Event givenEvent)
    {
        if (!_events.ContainsKey(givenEvent.Id))
        {
            _events[givenEvent.Id] = givenEvent;
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Add,"Given event is already in the events dictionary.");
        }
    }

    public void RemoveEvent(Event givenEvent)
    {
        if (_events.ContainsValue(givenEvent))
        {
            _events.Remove(givenEvent.Id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Remove, "No event found to remove.");
        }
    }
    #endregion
}
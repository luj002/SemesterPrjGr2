

public class AddEventController
{
    private IEventRepository _eventRepository;
    public Event eventToAdd { get; set; }

    public AddEventController(string title, string description, DateTime startTime, DateTime endTime, Adminstrator creator, IEventRepository eventRepository)
    {
        eventToAdd = new Event(title, description, startTime, endTime, creator);
        _eventRepository = eventRepository;
    }

    public void AddEvent()
    {
        try
        {
            _eventRepository.AddEvent(eventToAdd);
        }
        catch(RepositoryException e)
        {
            //todo error handling
        }
        
    }
}
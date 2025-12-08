

public class AddEventController
{
	//TODO
	//CODE FROM USERMENU: TO BE IMPLEMENDED AS IN ADDMEMBERCONTROLLER
	/*
	Console.WriteLine("Enter event name:");
	string eventName = Console.ReadLine();
	Console.WriteLine("Enter event description:");
	string eventDesc = Console.ReadLine();

	//TODO MAKE THIS ACTUALLY ENSURE VALID INPUT
	Console.WriteLine("Enter event start date with format YYYY-MM-DD HH/MM/SS");
	DateTime startTime = DateTime.Parse(Console.ReadLine());
	Console.WriteLine("Enter event end date with format YYYY-MM-DD HH/MM/SS");
	DateTime endTime = DateTime.Parse(Console.ReadLine());

	//AddEventController eventController = new AddEventController(eventName, eventDesc, startTime, endTime, (Adminstrator)currentUser, _eventRepository);
	eventController.AddEvent();
	*/
	private IEventRepository _eventRepository;
    public Event eventToAdd { get; set; }

    public AddEventController(IEventRepository eventRepository)
    {
        throw new NotImplementedException();
	}
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
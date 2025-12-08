

using System.Diagnostics.Metrics;

public class AddEventController
{
	private IEventRepository _eventRepository;
    public Event eventToAdd { get; set; }

    public AddEventController(IEventRepository eventRepository, Member maker)
    {
        if (maker is not Adminstrator)
        {
            //this should probably be a different exception type but that's solidly a later me problem
            throw new RepositoryException(RepositoryExceptionType.Add, "Only administrators may create events!");
        }

        _eventRepository = eventRepository;
        Create((Adminstrator)maker);

    }
	public AddEventController(string title, string description, DateTime startTime, DateTime endTime, Adminstrator creator, IEventRepository eventRepository)
    {
        eventToAdd = new Event(title, description, startTime, endTime, creator);
        _eventRepository = eventRepository;
    }

    public void Create(Adminstrator maker)
    {
        //TODO MAKE THIS MORE LIKE AddMemberController

        Console.WriteLine("Enter event name:");
        string eventName = Console.ReadLine()!;
        Console.WriteLine("Enter event description:");
        string eventDesc = Console.ReadLine()!;

        //TODO MAKE THIS ACTUALLY ENSURE VALID INPUT
        DateTime startTime = new DateTime();
        DateTime endTime = new DateTime();
        bool isValid = false;
        while (!isValid)
        {
            isValid = true;
            Console.WriteLine("Enter event start date with format YYYY-MM-DD HH:MM:SS");
            string input = Console.ReadLine()!;
            try
            {
                
                startTime = DateTime.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"That's not a valid date and time, please follow the format exactly: {e.Message}");
                isValid = false;
            }
        }
        isValid = false;
        while (!isValid)
        {
            isValid = true;
            Console.WriteLine("Enter event end date with format YYYY-MM-DD HH:MM:SS");
            string input = Console.ReadLine()!;
            try
            {
                endTime = DateTime.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"That's not a valid date and time, please follow the format exactly: {e.Message}");
                isValid = false;
            }
        }
        
        eventToAdd = new Event(eventName, eventDesc, startTime, endTime, maker);
    }

    public void AddEvent()
    {
        try
        {
            _eventRepository.AddEvent(eventToAdd);
        }
        catch(RepositoryException e)
        {
            Console.WriteLine(e.Message);
            //todo error handling
        }
        
    }
}
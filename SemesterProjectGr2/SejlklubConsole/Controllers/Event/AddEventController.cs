public class AddEventController
{
    #region Instance field
    private IEventRepository _eventRepository;
    #endregion

    #region Properties
    public Event eventToAdd { get; set; }
    #endregion

    #region Constructor
    public AddEventController(IEventRepository eventRepository, Member maker)
    {
        if (maker is not Administrator)
        {
            //this should probably be a different exception type but that's solidly a later me problem
            throw new RepositoryException(RepositoryExceptionType.Add, "Only administrators may create events!");
        }

        _eventRepository = eventRepository;
        Create((Administrator)maker);

    }
    #endregion

    #region Methods
    /// <summary>
    /// Creates a new event.
    /// </summary>
    /// <param name="maker">The administrator to credit as the creator.</param>
    public void Create(Administrator maker)
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

    /// <summary>
    /// Attempts to add the created event to the event repository, throwing an error if it fails to do so.
    /// </summary>
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
    #endregion
}
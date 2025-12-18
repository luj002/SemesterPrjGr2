

public class RemoveRegistrationController
{
    #region Instance field
    private IEventRepository _eventRepository;
    #endregion

    #region Properties
    public Member ThisMember;
    #endregion

    #region Constructor
    public RemoveRegistrationController(IEventRepository eventRepository, Member thisMember)
    {
        _eventRepository = eventRepository;
        ThisMember = thisMember;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Method to run the menu to unregister from an event
    /// </summary>
    public void Unregister()
    {
        List<Event> eventsRegistered = new List<Event>();
        foreach (Event e in _eventRepository.GetAll())
        {
            foreach (Member m in e.Attendees)
            {
                if(m == ThisMember)
                {
                    eventsRegistered.Add(e);
                }
            }
        }
        foreach (Event e in _eventRepository.GetAll())
        {
            Console.WriteLine(e);
        }
        Console.ReadKey();

        Console.WriteLine("Enter the ID of the event you would like to unregister from or Q to quit:");
        string input = Console.ReadLine();
        while(input != "q")
        {
            try{
                Event targetEvent = _eventRepository.GetEventByID(StringId.GetID(IdPrefix.EVENT, Int32.Parse(input)));
                foreach (Registration r in targetEvent.Registrations)
                {
                    if (r.Member == ThisMember)
                    {
                        targetEvent.Registrations.Remove(r);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("An error has occurred - check that you typed the ID number correctly.");
            }
            Console.WriteLine("Enter the ID of the event you would like to unregister from or Q to quit:");
            input = Console.ReadLine();
        }
    }
    #endregion
}
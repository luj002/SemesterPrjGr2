

public class AddRegistrationController
{
    #region Instance field
    private IEventRepository _eventRepository;
    #endregion

    #region Properties
    public Member ThisMember { get; set; }
    #endregion

    #region Constructor
    public AddRegistrationController(IEventRepository eventRepository, Member thisMember)
    {
        _eventRepository = eventRepository;
        ThisMember = thisMember;
    }
    #endregion

    #region Methods
    //todo make this more like RemoveRegistrationController if i can be bothered and have time
    /// <summary>
    /// Registers the user to an event.
    /// </summary>
    public void Register()
    {
        Event eventToRegister = null;
        bool proceed = false;
        ShowEventController showEventsController = new ShowEventController(_eventRepository);
        showEventsController.ShowAllEvents();
        while (!proceed)
        {
            proceed = true;
            Console.WriteLine("Enter the ID of the event you want to register for:");
            try{
                eventToRegister = _eventRepository.GetEventByID(StringId.GetID(IdPrefix.EVENT, Int32.Parse(Console.ReadLine())));
            }
            catch (Exception e)
            {
                proceed = false;
                Console.WriteLine("No event with that ID found, try again.");
            }
        }
        Console.WriteLine("Add a comment to your registration or leave blank:");
        string comment = Console.ReadLine();
        Registration regist = new Registration(ThisMember, eventToRegister, comment);
        eventToRegister.Registrations.Add(regist);
    }
    #endregion
}
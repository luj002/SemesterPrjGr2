

public class AddRegistrationController
{
    private IEventRepository _eventRepository;
    public Member ThisMember { get; set; }

    public AddRegistrationController(IEventRepository eventRepository, Member thisMember)
    {
        _eventRepository = eventRepository;
        ThisMember = thisMember;
    }

    //method to register for an event
    //todo make this more like RemoveRegistrationController if i can be bothered and have time
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
}
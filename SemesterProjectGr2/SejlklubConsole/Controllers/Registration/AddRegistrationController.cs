//todo make good

public class AddRegistrationController
{
    private IEventRepository _eventRepository;
    public Member Member { get; set; }

    public AddRegistrationController(IEventRepository eventRepository, Member member)
    {
        _eventRepository = eventRepository;
        Member = member;
    }

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
        Registration regist = new Registration(Member, eventToRegister, comment);
        eventToRegister.Registrations.Add(regist);
    }
}
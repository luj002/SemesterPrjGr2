public class UserMenu
{
    private List<string> _menuChoices;
    //for now just use menuChoices.Add() in PopulateMenu() to add stuff
    //todo find a better way to populate this list

    private IBlogEntryRepository _blogEntryRepository = new BlogEntryRepository();
    private IBoatRepository _boatRepository = new BoatRepository();
    private IBoatSpaceRepository _boatSpaceRepository = new BoatSpaceRepository();
    private IBookingRepository _bookingRepository = new BookingRepository();
    private IEventRepository _eventRepository = new EventRepository();
    private IMemberRepository _memberRepository = new MemberRepository();

    private string ReadChoice(List<string> choices)
    {
        Console.Clear();
        foreach (string s in choices)
        {
            Console.WriteLine(s);
        }
        string input = Console.ReadLine();
        return input.ToLower();
    }

    private void PopulateMenu()
    {
        _menuChoices.Add("1. Add Event");
    }

    public void ShowMenu()
    {
        //DEBUG STUFF, CHANGE THIS LATER
        Member currentUser = new Adminstrator("John Testman", "121 Test Road, Testville, Testlandia", "test@test.test", new DateTime(1984, 6, 22), MemberType.SENIOR);
        //END OF DEBUG STUFF

        string choice = ReadChoice(_menuChoices);

        while (choice != "q")
        {
            switch (choice)
            {
                //menu option handling goes here

                case "1":
                    if (currentUser is not Adminstrator)
                    {
                        Console.WriteLine("You need to be an administrator to add events!");
                        break;
                    }
                    Console.WriteLine("Enter event name:");
                    string eventName = Console.ReadLine();
                    Console.WriteLine("Enter event description:");
                    string eventDesc = Console.ReadLine();

                    //TODO MAKE THIS ACTUALLY ENSURE VALID INPUT
                    Console.WriteLine("Enter event start date with format YYYY-MM-DD HH/MM/SS");
                    DateTime startTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter event end date with format YYYY-MM-DD HH/MM/SS");
                    DateTime endTime = DateTime.Parse(Console.ReadLine());

                    AddEventController eventController = new AddEventController(eventName, eventDesc, startTime, endTime, (Adminstrator)currentUser, _eventRepository);
                    eventController.AddEvent();
                    break;
            }
        }
    }
}


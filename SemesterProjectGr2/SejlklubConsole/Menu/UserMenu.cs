public class UserMenu
{
	private List<string> _menuChoices = new List<string>();
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
        Console.Clear();
        return input.ToLower();
    }

    private void PopulateMenu()
    {
        _menuChoices.Add("1. Event menu");
        _menuChoices.Add("2. Member menu");
        _menuChoices.Add("3. Boat menu");
        _menuChoices.Add("4. Boat space menu");
        _menuChoices.Add("5. Blog menu");
        _menuChoices.Add("6. Booking menu");
        _menuChoices.Add("\nQ. Quit");
    }
	//DEBUG STUFF, CHANGE THIS LATER
	Member currentUser = new Adminstrator("John Testman", "121 Test Road, Testville, Testlandia", "test@test.test", new DateTime(1984, 6, 22), MemberType.SENIOR);
	//END OF DEBUG STUFF
	public void ShowMenu()
    {
        PopulateMenu();

        string choice = ReadChoice(_menuChoices);

        while (!choice.ToLower().StartsWith('q'))
        {
            switch (choice)
            {
                //menu option handling goes here
                case "1":
					ShowEventMenu();
                    break;
				case "2":
                    ShowMemberMenu();
                    break;
                case "3":
                    ShowBoatMenu();
                    break;
                case "4":
					ShowBoatSpaceMenu();
                    break;
                case "5":
                    ShowBlogMenu();
                    break;
                case "6":
                    ShowBookingMenu();
                    break;

			}
			choice = ReadChoice(_menuChoices);
        }
	}

	private void ShowBookingMenu()
	{
		throw new NotImplementedException();
	}

	private void ShowBlogMenu()
	{
		throw new NotImplementedException();
	}

	private void ShowBoatSpaceMenu()
	{
		throw new NotImplementedException();
	}

	private void ShowBoatMenu()
	{
		throw new NotImplementedException();
	}

	private void ShowEventMenu()
	{
		List<string> choices = new List<string> { "1. Add event", "2. Show events", "3. Update event", "4. Delete event", "B. Back" };
        string choice = ReadChoice(choices);
		while (choice != "b")
		{
			switch (choice)
			{
				case "1":
					AddEventController eventController = new AddEventController(_eventRepository);
                    eventController.AddEvent();
					break;
				case "2":
					//ShowEventController showEventsController = new ShowEventController(_eventRepository);
					//showEventsController.ShowAllEvents();
					break;
				case "3":
					//UpdateEventController updateEventController = new UpdateEventController(_EventRepository);
					//updateEventController.UpdateEvent();
					break;
				case "4":
					//DeleteEventController deleteEventController = new DeleteEventController(_EventRepository);
					//deleteEventController.DeleteEvent();
					break;
			}
			choice = ReadChoice(choices);
		}

        //TODO
        //TO BE IMPLEMENTED IN THE CONTROLLER JUST LIKE ADD MEMBER
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
	}

	private void ShowMemberMenu()
    {
        List<string> choices = new List<string> { "1. Add member", "2. Show members", "3. Update member", "4. Delete member", "B. Back" };
        string choice = ReadChoice(choices);
        while (choice != "b")
        {
            switch (choice)
            {
                case "1":
                    AddMemberController memberController = new AddMemberController(_memberRepository);
                    memberController.AddMember();
                    break;
                case "2":
                    ShowMemberController showMembersController = new ShowMemberController(_memberRepository);
                    showMembersController.ShowAllMembers();
                    break;
                case "3":
                    //UpdateMemberController updateMemberController = new UpdateMemberController(_memberRepository);
                    //updateMemberController.UpdateMember();
                    break;
                case "4":
                    //DeleteMemberController deleteMemberController = new DeleteMemberController(_memberRepository);
                    //deleteMemberController.DeleteMember();
                    break;
            }
            choice = ReadChoice(choices);
        }
    }
}


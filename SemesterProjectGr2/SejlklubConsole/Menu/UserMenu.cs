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
        string input = Console.ReadLine()!;
        Console.Clear();
        return input.ToLower();
    }

    private void PopulateMenu()
    {
        _menuChoices.Add("1. Event menu");
        _menuChoices.Add("2. Member menu");
        _menuChoices.Add("3. Boat menu");
        _menuChoices.Add("4. BoatSpace menu");
        _menuChoices.Add("5. BlogEntry menu");
        _menuChoices.Add("6. Booking menu");
        _menuChoices.Add("\nQ. Quit");
    }
	//DEBUG STUFF, CHANGE THIS LATER
	public static Member currentUser = new Adminstrator("John Testman", "121 Test Road, Testville, Testlandia", "test@test.test", new DateTime(1984, 6, 22), MemberType.SENIOR);
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
                    ShowBlogEntryMenu();
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
		List<string> choices = new List<string> { "1. Add booking", "2. Show bookings", "3. Update booking", "4. Remove booking", "\nB. Back" };
		string choice = ReadChoice(choices);
		while (choice != "b")
		{
			switch (choice)
			{
				case "1":
					AddBookingController bookingController = new AddBookingController(_bookingRepository);
					bookingController.AddBooking();
					break;
				case "2":
					ShowBookingController showBookingsController = new ShowBookingController(_bookingRepository);
					showBookingsController.ShowAllBookings();
					break;
				case "3":
					UpdateBookingController updateBookingController = new UpdateBookingController(_bookingRepository);
					updateBookingController.UpdateBooking();
					break;
				case "4":
					RemoveBookingController removeBookingController = new RemoveBookingController(_bookingRepository);
					removeBookingController.RemoveBooking();
					break;
			}
			choice = ReadChoice(choices);
		}
	}

	private void ShowBlogEntryMenu()
	{
		List<string> choices = new List<string> { "1. Add blogEntry", "2. Show blogEntrys", "3. Update blogEntry", "4. Remove blogEntry", "\nB. Back" };
		string choice = ReadChoice(choices);
		while (choice != "b")
		{
			switch (choice)
			{
				case "1":
					if (currentUser is not Adminstrator)
					{
						Console.WriteLine("Only administrators can add blog entries.");
						Console.ReadKey();
						break;
					}
					else
					{
						AddBlogEntryController blogEntryController = new AddBlogEntryController(_blogEntryRepository, (Adminstrator) currentUser);
						break;
					}
				case "2":
					ShowBlogEntryController showBlogEntrysController = new ShowBlogEntryController(_blogEntryRepository);
					showBlogEntrysController.ShowAllBlogEntries();
					break;
				case "3":
					UpdateBlogEntryController updateBlogEntryController = new UpdateBlogEntryController(_blogEntryRepository);
					updateBlogEntryController.UpdateBlogEntry();
					break;
				case "4":
					RemoveBlogEntryController removeBlogEntryController = new RemoveBlogEntryController(_blogEntryRepository);
					removeBlogEntryController.RemoveBlogEntry();
					break;
			}
			choice = ReadChoice(choices);
		}
	}

	private void ShowBoatSpaceMenu()
	{
		List<string> choices = new List<string> { "1. Add boatSpace", "2. Show boatSpaces", "3. Update boatSpace", "4. Remove boatSpace", "\nB. Back" };
		string choice = ReadChoice(choices);
		while (choice != "b")
		{
			switch (choice)
			{
				case "1":
					AddBoatSpaceController boatSpaceController = new AddBoatSpaceController(_boatSpaceRepository);
					boatSpaceController.AddBoatSpace();
					break;
				case "2":
					ShowBoatSpaceController showBoatSpacesController = new ShowBoatSpaceController(_boatSpaceRepository);
					showBoatSpacesController.ShowAllBoatSpaces();
					break;
				case "3":
					UpdateBoatSpaceController updateBoatSpaceController = new UpdateBoatSpaceController(_boatSpaceRepository);
				    updateBoatSpaceController.UpdateBoatSpace();
					break;
				case "4":
					RemoveBoatSpaceController removeBoatSpaceController = new RemoveBoatSpaceController(_boatSpaceRepository);
					removeBoatSpaceController.RemoveBoatSpace();
					break;
			}
			choice = ReadChoice(choices);
		}
	}

	private void ShowBoatMenu()
	{
		List<string> choices = new List<string> { "1. Add boat", "2. Show boats", "3. Update boat", "4. Remove boat", "\nB. Back" };
		string choice = ReadChoice(choices);
		while (choice != "b")
		{
			switch (choice)
			{
				case "1":
					AddBoatController boatController = new AddBoatController(_boatRepository);
					//boatController.AddBoat();
					break;
				case "2":
					ShowBoatController showBoatsController = new ShowBoatController(_boatRepository);
					showBoatsController.ShowAllBoats();
					break;
				case "3":
					UpdateBoatController updateBoatController = new UpdateBoatController(_boatRepository);
					updateBoatController.UpdateBoat();
					break;
				case "4":
					RemoveBoatController removeBoatController = new RemoveBoatController(_boatRepository);
					removeBoatController.RemoveBoat();
					break;
			}
			choice = ReadChoice(choices);
		}
	}

	private void ShowEventMenu()
	{
		List<string> choices = new List<string> { "1. Add event", "2. Show events", "3. Update event", "4. Remove event", "\nB. Back" };
        string choice = ReadChoice(choices);
		while (choice != "b")
		{
			switch (choice)
			{
				case "1":
					AddEventController eventController = new AddEventController(_eventRepository, currentUser);
                    eventController.AddEvent();
					break;
				case "2":
					ShowEventController showEventsController = new ShowEventController(_eventRepository);
					showEventsController.ShowAllEvents();
					break;
				case "3":
					UpdateEventController updateEventController = new UpdateEventController(_eventRepository);
					updateEventController.UpdateEvent();
					break;
				case "4":
					RemoveEventController removeEventController = new RemoveEventController(_eventRepository);
					removeEventController.RemoveEvent();
					break;
			}
			choice = ReadChoice(choices);
		}
	}

	private void ShowMemberMenu()
    {
        List<string> choices = new List<string> { "1. Add member", "2. Show members", "3. Update member", "4. Remove member", "\nB. Back" };
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
                    RemoveMemberController removeMemberController = new RemoveMemberController(_memberRepository);
                    removeMemberController.RemoveMember();
                    break;
            }
            choice = ReadChoice(choices);
        }
    }
}


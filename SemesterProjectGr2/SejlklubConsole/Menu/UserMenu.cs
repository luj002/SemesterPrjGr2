public class UserMenu
{
	public UserMenu(string memberId)
	{
        //in reality we'd probably fetch from a database here
        MockData.PopulateBlogEntries(_blogEntryRepository);
		MockData.PopulateMembers(_memberRepository);
		MockData.PopulateBoats(_boatRepository);
		MockData.PopulateBookings(_bookingRepository);
		MockData.PopulateBoatSpaces(_boatSpaceRepository);
		MockData.PopulateEvents(_eventRepository);

		currentUser = _memberRepository.GetMemberById(memberId);
    }

	private List<string> _menuChoices = new List<string>();
	//for now just use menuChoices.Add() in PopulateMenu() to add stuff
	//todo find a better way to populate this list

	public static Member currentUser;

    private IBlogEntryRepository _blogEntryRepository = new BlogEntryRepository();
    private IBoatRepository _boatRepository = new BoatRepository();
    private IBoatSpaceRepository _boatSpaceRepository = new BoatSpaceRepository();
    private IBookingRepository _bookingRepository = new BookingRepository();
    private IEventRepository _eventRepository = new EventRepository();
    private IMemberRepository _memberRepository = new MemberRepository();

    private void PopulateMenu()
    {
        _menuChoices.Add("1. Event menu");
        _menuChoices.Add("2. Member menu");
        _menuChoices.Add("3. Boat menu");
        _menuChoices.Add("4. BoatSpace menu");
        _menuChoices.Add("5. BlogEntry menu");
		_menuChoices.Add("6. Booking menu");
		_menuChoices.Add("7. Log menu");
		_menuChoices.Add("\nQ. Quit");
    }
	//DEBUG STUFF, CHANGE THIS LATER
	//public static Member currentUser = new Adminstrator("John Testman", "121 Test Road, Testville, Testlandia", "test@test.test", new DateTime(1984, 6, 22), MemberType.SENIOR);
	//END OF DEBUG STUFF

	public void ShowMenu()
    {
        PopulateMenu();

        char choice = Helpers.ReadChoiceKey(_menuChoices);

        while (choice != 'q')
        {
            switch (choice)
            {
                //menu option handling goes here
                case '1':
					ShowEventMenu();
                    break;
				case '2':
                    ShowMemberMenu();
                    break;
                case '3':
                    ShowBoatMenu();
                    break;
                case '4':
					ShowBoatSpaceMenu();
                    break;
                case '5':
                    ShowBlogEntryMenu();
                    break;
                case '6':
                    ShowBookingMenu();
                    break;
				case '7':
					ShowLogMenu();
					break;

			}
			choice = Helpers.ReadChoiceKey(_menuChoices);
        }
	}

	public void ShowLogMenu()
	{
		//Pick boat
		IBoatRepository boatRep = _boatRepository;
		Boat? chosenBoat;

        while (true)
        {
            Console.Clear();

            ShowBoatController SBC = new ShowBoatController(boatRep);
            string callType = "log";
            SBC.ShowAllBoats(callType);

            Console.WriteLine("Q. Cancel");
            Console.WriteLine();

            Console.WriteLine("You have to pick a boat to view its log history.");
            Console.Write("Pick boat by id number: ");
            string input = Console.ReadLine();
            int chosenNumber;

            if (int.TryParse(input, out chosenNumber) == true)
            {
                string boatID = "#BOAT_" + chosenNumber.ToString("0000");
                chosenBoat = boatRep.GetBoatById(boatID);

				if (chosenBoat == null)
				{
					continue;
				}

                break;
            }

            else if (input == "q")
            {
                return;
            }
        }

        //Pick action (add, show, remove, update)
        IBoatLogEntryRepository _logRepository = new BoatLogEntryRepository(chosenBoat);
        List<string> actions = new List<string> {"1. Add log","2. Show logs","3. Remove log","4. Update log"};

		while (true)
		{
            Console.Clear();

            Console.WriteLine($"Editing boat: {chosenBoat.Id}");
            Console.WriteLine();

			foreach (string action in actions)
			{
                Console.WriteLine(action);
			}

            Console.WriteLine();
            Console.WriteLine("Q. Cancel");
            Console.WriteLine();

            Console.Write("Your choice: ");
            string input = Console.ReadLine().ToLower();

			switch (input)
			{
				case "1":

                    //Add BoatLog to boat
                    AddBoatLogController ABLC = new AddBoatLogController(_logRepository,chosenBoat);
					ABLC.AddLog();
                    break;

				case "2":

					//Show BoatLogs for boat
					ShowBoatLogController SBLC = new ShowBoatLogController(_logRepository);
					string callType = "display";
					SBLC.ShowLogs(callType);
					break;

				case "3":

					//Remove BoatLog from boat
					RemoveBoatLogController RBLC = new RemoveBoatLogController(_logRepository);
					RBLC.RemoveLog();
					break;

				case "4":

					//Update BoatLog for boat
					UpdateBoatLogController UBLC = new UpdateBoatLogController(_logRepository,chosenBoat);
					UBLC.UpdateLog();
					break;

				case "q":

					//Exit BoatLog menu
					return;

            }
        }
    }

	private void ShowBookingMenu()
	{
		List<string> choices = new List<string> { "1. Add booking", "2. Show bookings", "3. Update booking", "4. Remove booking", "\nQ. Back" };
		char choice = Helpers.ReadChoiceKey(choices);
		while (choice != 'q')
		{
			switch (choice)
			{
				case '1':
					AddBookingController bookingController = new AddBookingController(_bookingRepository, _boatRepository, _memberRepository);
					break;
				case '2':
					ShowBookingController showBookingsController = new ShowBookingController(_bookingRepository, _boatRepository, _memberRepository);
					showBookingsController.ShowBookings();
					break;
				case '3':
					UpdateBookingController updateBookingController = new UpdateBookingController(_bookingRepository, _memberRepository, _boatRepository);
					updateBookingController.UpdateBooking();
					break;
				case '4':
					RemoveBookingController removeBookingController = new RemoveBookingController(_bookingRepository);
					removeBookingController.RemoveBooking();
					break;
			}
			choice = Helpers.ReadChoiceKey(choices);
		}
	}

	private void ShowBlogEntryMenu()
	{
		List<string> choices = new List<string> { "1. Add blogEntry", "2. Show blogEntrys", "3. Update blogEntry", "4. Remove blogEntry", "\nQ. Back" };
		char choice = Helpers.ReadChoiceKey(choices);
		while (choice != 'q')
		{
			switch (choice)
			{
				case '1':
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
				case '2':
					ShowBlogEntryController showBlogEntrysController = new ShowBlogEntryController(_blogEntryRepository);
					showBlogEntrysController.ShowAllBlogEntries();
					break;
				case '3':
                    if (currentUser is not Adminstrator)
                    {
                        Console.WriteLine("Only administrators can update blog entries.");
                        Console.ReadKey();
                        break;
                    }
                    else
					{
                        UpdateBlogEntryController updateBlogEntryController = new UpdateBlogEntryController(_blogEntryRepository);
                        updateBlogEntryController.UpdateBlogEntry();
                        break;
                    }
				case '4':
					if (currentUser is not Adminstrator)
					{
						Console.WriteLine("Only administrators can remove blog entries.");
						Console.ReadKey();
						break;
					}
					else
					{
                        RemoveBlogEntryController removeBlogEntryController = new RemoveBlogEntryController(_blogEntryRepository);
                        removeBlogEntryController.RemoveBlogEntry();
                        break;
                    }
			}
			choice = Helpers.ReadChoiceKey(choices);
		}
	}

	private void ShowBoatSpaceMenu()
	{
		List<string> choices = new List<string> { "1. Add boatSpace", "2. Show boatSpaces", "3. Update boatSpace", "4. Remove boatSpace", "5. Assign boat to boatSpace", "\nQ. Back" };
		char choice = Helpers.ReadChoiceKey(choices);
		while (choice != 'q')
		{
			switch (choice)
			{
				case '1':
					AddBoatSpaceController addBoatSpaceController = new AddBoatSpaceController(_boatSpaceRepository);
					addBoatSpaceController.Create();
                    break;
				case '2':
					ShowBoatSpaceController showBoatSpacesController = new ShowBoatSpaceController(_boatSpaceRepository);
					showBoatSpacesController.ShowAllBoatSpaces();
					break;
				case '3':
					UpdateBoatSpaceController updateBoatSpaceController = new UpdateBoatSpaceController(_boatSpaceRepository);
				    updateBoatSpaceController.UpdateBoatSpace();
					break;
				case '4':
					RemoveBoatSpaceController removeBoatSpaceController = new RemoveBoatSpaceController(_boatSpaceRepository);
					removeBoatSpaceController.RemoveBoatSpace();
					break;
				case '5':
					AssignToBoatSpaceController assignToBoatSpaceController = new AssignToBoatSpaceController(_boatSpaceRepository, _boatRepository);
					assignToBoatSpaceController.Assign();
					break;
			}
			choice = Helpers.ReadChoiceKey(choices);
		}
	}

	private void ShowBoatMenu()
	{
		List<string> choices = new List<string> { "1. Add boat", "2. Show boats", "3. Update boat", "4. Remove boat", "\nQ. Back" };
		char choice = Helpers.ReadChoiceKey(choices);
		while (choice != 'q')
		{
			switch (choice)
			{
				case '1':
					AddBoatController boatController = new AddBoatController(_boatRepository);
					bool shouldAdd = boatController.ShouldAdd;
					if (shouldAdd == true)
					{
                        boatController.AddBoat();
                    }
					break;
				case '2':
					ShowBoatController showBoatsController = new ShowBoatController(_boatRepository);
					string callType = "display";
					showBoatsController.ShowAllBoats(callType);
					break;
				case '3':
					UpdateBoatController updateBoatController = new UpdateBoatController(_boatRepository);
					break;
				case '4':
					RemoveBoatController removeBoatController = new RemoveBoatController(_boatRepository);
					removeBoatController.RemoveBoat();
					break;
			}
			choice = Helpers.ReadChoiceKey(choices);
		}
	}

	private void ShowEventMenu()
	{
		List<string> choices = new List<string> { "1. Add event", "2. Show events", "3. Update event", "4. Remove event", "5. Register for event", "6. Unregister for an event", "\nQ. Back" };
        char choice = Helpers.ReadChoiceKey(choices);
		while (choice != 'q')
		{
			switch (choice)
			{
				case '1':
					AddEventController eventController = new AddEventController(_eventRepository, currentUser);
                    eventController.AddEvent();
					break;
				case '2':
					ShowEventController showEventsController = new ShowEventController(_eventRepository);
					showEventsController.ShowAllEvents();
					break;
				case '3':
					UpdateEventController updateEventController = new UpdateEventController(_eventRepository, currentUser);
					updateEventController.UpdateEvent();
					break;
				case '4':
					RemoveEventController removeEventController = new RemoveEventController(_eventRepository, currentUser);
					removeEventController.RemoveEvent();
					break;
				case '5':
					AddRegistrationController addRegistrationController = new AddRegistrationController(_eventRepository, currentUser);
					addRegistrationController.Register();
					break;
				case '6':
					RemoveRegistrationController removeRegistrationController = new RemoveRegistrationController(_eventRepository, currentUser);
					removeRegistrationController.Unregister();
					break;
			}
			choice = Helpers.ReadChoiceKey(choices);
		}
	}

	private void ShowMemberMenu()
    {
        List<string> choices = new List<string> { "1. Add member", "2. Show members", "3. Update member", "4. Remove member", "\nQ. Back" };
        char choice = Helpers.ReadChoiceKey(choices);
        while (choice != 'q')
        {
            switch (choice)
            {
                case '1':
                    AddMemberController memberController = new AddMemberController(_memberRepository);
                    break;
                case '2':
                    ShowMemberController showMembersController = new ShowMemberController(_memberRepository);
                    showMembersController.ShowAllMembers();
                    break;
                case '3':
                    UpdateMemberController updateMemberController = new UpdateMemberController(_memberRepository);
                    updateMemberController.UpdateMember();
                    break;
                case '4':
                    RemoveMemberController removeMemberController = new RemoveMemberController(_memberRepository);
                    removeMemberController.RemoveMember();
                    break;
            }
            choice = Helpers.ReadChoiceKey(choices);
        }
    }
}


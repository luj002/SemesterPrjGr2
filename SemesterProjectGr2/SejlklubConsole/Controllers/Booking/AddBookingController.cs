
public class AddBookingController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
	private IBoatRepository _boatRepository;
	private IMemberRepository _memberRepository;
    private Booking _booking;
    #endregion

    #region Constructor
	public AddBookingController(IBookingRepository bookingRepository)
	{
		// TODO FIX!
		// MADE TO SATISFY USERMENU
	}
    public AddBookingController(IBookingRepository bookingRepository, IBoatRepository boatRepository, IMemberRepository memberRepository)
	{
		_bookingRepository = bookingRepository;
		Create();
    }
    #endregion

    #region Methods
    private void Create()
	{
        List<string> choices = new List<string> {
            "1. Member", 
			"2. Boat",
			"3. Sailing area",
			"4. Destination",
            "5. Start time",
            "6. End time",
            "\nC. Confirm",
			"Q. Cancel (Discard Booking)"
        };

		Member? member = null;
		Boat? boat = null;
		string sailingArea = "";
		string destination = "";
		DateTime startTime = DateTime.MinValue;
		DateTime endTime = DateTime.MinValue;

		string theChoice = Helpers.ReadChoice(choices);

		while (theChoice != "c" && theChoice != "q")
		{
			switch (theChoice)
			{
				case "1":
					// Select member
					member = MemberHelpers.SelectMember(_memberRepository);
					break;
				case "2":
                    // Select boat
					boat = BoatHelpers.SelectBoat(_boatRepository);
					break;
				case "3":
					// Sailing area
					Console.Write("Enter sailing area: ");
                    sailingArea = Console.ReadLine()!;
					break;
				case "4":
                    // Destination
					Console.Write("Enter destination (optional): ");
					destination = Console.ReadLine()!;
					break;
				case "5":
                    // Start time
					Console.Write("Enter start time (yyyy-MM-dd HH:mm): ");
					startTime = DateTime.Parse(Console.ReadLine()!);
					break;
				case "6":
                    // End time
					Console.Write("Enter end time (yyyy-MM-dd HH:mm): ");
					endTime = DateTime.Parse(Console.ReadLine()!);
					break;
				default:
					Console.WriteLine("Invalid choice. Press any button to try again.");
					Console.ReadKey();
					break;
            }
			theChoice = Helpers.ReadChoice(choices);
        }

        if (theChoice == "c")
		{
            _booking = new Booking(member, boat!, sailingArea, endTime, startTime, destination);
            AddBooking();
        }


    }



    private void AddBooking()
	{
        Console.WriteLine(_booking);
        bool AddConfirmed = Helpers.YesOrNo("Confirm booking?");
        if (AddConfirmed)
            _bookingRepository.Add(_booking);
    }
    #endregion
}

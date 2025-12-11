
public class AddBookingController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    private IBoatRepository _boatRepository;
    private IMemberRepository _memberRepository;
    private Booking _booking;
    private string _statusText;
    private bool _validBooking;
    #endregion

    #region Constructor
    public AddBookingController(IBookingRepository bookingRepository, IBoatRepository boatRepository, IMemberRepository memberRepository)
    {
        _validBooking = false;
        _statusText = "";
        _bookingRepository = bookingRepository;
        _boatRepository = boatRepository;
        _memberRepository = memberRepository;
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
            $"",
            "C. Confirm",
            "Q. Cancel (Discard Booking)"
        };

        Member? member = null;
        Boat? boat = null;
        string sailingArea = "";
        string destination = "";
        DateTime startTime = DateTime.MinValue;
        DateTime endTime = DateTime.MinValue;

        string theChoice = Helpers.ReadChoice(choices);

        while ((theChoice != "c" && theChoice != "q") || !_validBooking)
        {
            switch (theChoice)
            {
                case "1":
                    // Select member
                    member = MemberHelpers.SelectMember(_memberRepository);

                    if (member != null)
                    {
                        choices[0] = $"1. Member - {member.Id} {member.Name}";
                    }
                    break;
                case "2":
                    // Select boat
                    boat = BoatHelpers.SelectBoat(_boatRepository);
                    if (boat != null)
                    {
                        choices[1] = $"2. Boat - {boat.Id} {boat.Nickname} {boat.ModelName}";
                    }
                    break;
                case "3":
                    // Sailing area
                    Console.Write("Enter sailing area: ");
                    sailingArea = Console.ReadLine()!;

                    choices[2] = $"3. Sailing area - {sailingArea}";
                    break;
                case "4":
                    // Destination
                    Console.Write("Enter destination (optional): ");
                    destination = Console.ReadLine()!;
                    if (destination.Length == 0)
                        destination = "N/A";

                    choices[3] = $"4. Destination - {destination}";
                    break;
                case "5":
                    // Start time
                    startTime = Helpers.DateTimeFromReadLine("Start time", DateTime.Now, DateTime.Now.AddYears(1), true);

                    choices[4] = $"5. Start time - {startTime.ToShortDateString()} {startTime.ToShortTimeString()}";
                    break;
                case "6":
                    // End time
                    endTime = Helpers.DateTimeFromReadLine("End time", startTime, startTime.AddDays(2), true);

                    choices[5] = $"6. End time - {endTime.ToShortDateString()} {endTime.ToShortTimeString()}";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any button to try again.");
                    Console.ReadKey();
                    break;
            }
            // Validate booking

            _validBooking = BookingHelpers.ValidateBooking(_bookingRepository.GetAll(), boat!, startTime, endTime);
            choices[6] = _validBooking ? "Booking is valid." : "Booking is not valid";


            theChoice = Helpers.ReadChoice(choices);

        }

        if (theChoice == "c")
        {
            _booking = new Booking(member!, boat!, sailingArea, endTime, startTime, destination);
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

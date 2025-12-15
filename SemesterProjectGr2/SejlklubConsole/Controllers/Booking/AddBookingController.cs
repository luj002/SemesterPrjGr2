
using System.Security;

public class AddBookingController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    private IBoatRepository _boatRepository;
    private IMemberRepository _memberRepository;
    private Booking _booking;
    private bool _validBooking;
    #endregion

    #region Constructor
    public AddBookingController(IBookingRepository bookingRepository, IBoatRepository boatRepository, IMemberRepository memberRepository)
    {
        _validBooking = false;
        _bookingRepository = bookingRepository;
        _boatRepository = boatRepository;
        _memberRepository = memberRepository;
        Create();
    }
    #endregion

    #region Methods
    private void Create()
    {
        Member? member = null;
        Boat? boat = null;
        string sailingArea = "";
        string destination = "";
        DateTime startTime = DateTime.MinValue;
        DateTime endTime = DateTime.MinValue;

        string bookingStatus = BookingRepositoryHelpers.ValidateBooking(_bookingRepository.GetAll(), member, boat, startTime, endTime);
        _validBooking = bookingStatus.Length == 0;
        bookingStatus = "\nBooking status:\n" + (_validBooking ? "Booking is valid" : bookingStatus);

        List<string> choices = new List<string> {
            "1. Member",
            "2. Boat",
            "3. Sailing area",
            "4. Destination",
            "5. Start time",
            "6. End time",
            $"{bookingStatus}",
            "C. Confirm",
            "Q. Cancel (Discard Booking)"
        };

        string theChoice = Helpers.ReadChoice(choices);

        while ((theChoice != "c" || !_validBooking) && theChoice != "q")
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
                    DateTime? startTimeInput = Helpers.DateTimeFromReadLine("Start time", DateTime.Now, DateTime.Now.AddYears(5), true);
                    if (startTimeInput != null)
                    {
                        startTime = (DateTime)startTimeInput;

                        choices[4] = $"5. Start time - {startTime.ToString("yyyy/MM/dd HH:mm:ss")}";
                    }
                    break;
                case "6":
                    // End time
                    DateTime? endTimeInput = Helpers.DateTimeFromReadLine("End time", startTime, startTime.AddDays(7), true);
                    if (endTimeInput != null)
                    {
                        endTime = (DateTime)endTimeInput;

                        choices[5] = $"6. End time - {endTime.ToString("yyyy/MM/dd HH:mm:ss")}";
                    }
                    break;
                default:
                    break;
            }

            // Validate booking
            bookingStatus = BookingRepositoryHelpers.ValidateBooking(_bookingRepository.GetAll(), member, boat, startTime, endTime);
            _validBooking = bookingStatus.Length == 0;
            bookingStatus = "\nBooking status:\n" + (_validBooking ? "Booking is valid" : bookingStatus);

            choices[6] = bookingStatus;

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
        bool AddConfirmed = Helpers.YesOrNo("Confirm booking?") ?? false;
        if (AddConfirmed)
            _bookingRepository.Add(_booking);
    }
    #endregion
}

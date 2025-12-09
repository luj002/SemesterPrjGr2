
public class UpdateBookingController
{
    private IBookingRepository _bookingRepository;
    private IMemberRepository _memberRepository;
    private IBoatRepository _boatRepository;
    private Booking? _booking;

    public UpdateBookingController(IBookingRepository bookingRepository, IMemberRepository memberRepository, IBoatRepository boatRepository)
    {
        _bookingRepository = bookingRepository;
        _booking = BookingHelpers.SelectBooking(_bookingRepository);
    }

    public void UpdateBooking()
    {
        if (_booking == null)
        {
            Console.WriteLine("No booking selected. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Member member = _booking.Member;
        Boat boat = _booking.Boat;
        string sailingArea = _booking.SailingArea;
        string destination = _booking.Destination ?? "N/A";
        DateTime startTime = _booking.StartTime;
        DateTime endTime = _booking.EndTime;

        List<string> choices = new List<string> {
            $"1. Member - {member.Id} {member.Name}",
            $"2. Boat - {boat.Id} {boat.Nickname} {boat.ModelName}",
            $"3. Sailing area - {sailingArea}",
            $"4. Destination - {destination}",
            $"5. Start time - {startTime.ToShortDateString()} {startTime.ToShortTimeString()}",
            $"6. End time - {endTime.ToShortDateString()} {endTime.ToShortTimeString()}",
            "\nC. Confirm",
            "Q. Cancel (Discard Booking)"
        };

        string theChoice = Helpers.ReadChoice(choices);

        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Console.WriteLine("Select Member:");
                    member = MemberHelpers.SelectMember(_memberRepository) ?? member;

                    choices[0] = $"1. Member - {member.Id} {member.Name}";
                    break;
                case "2":
                    Console.WriteLine("Select Boat:");
                    boat = BoatHelpers.SelectBoat(_boatRepository) ?? boat;

                    choices[1] = $"2. Boat - {boat.Id} {boat.Nickname} {boat.ModelName}";
                    break;
                case "3":
                    Console.WriteLine("Enter Sailing area");
                    sailingArea = Console.ReadLine();

                    choices[2] = $"3. Sailing area - {sailingArea}";
                    break;
                case "4":
                    Console.WriteLine("Enter Destination (leave blank for N/A)");
                    destination = Console.ReadLine();
                    if (destination.Length == 0) destination = "N/A";

                    choices[3] = $"4. Destination - {destination}";
                    break;
                case "5":
                    startTime = Helpers.DateTimeFromReadLine("Start time:", DateTime.Now, endTime, true);

                    choices[4] = $"5. Start time - {startTime.ToShortDateString()} {startTime.ToShortTimeString()}";
                    break;
                case "6":
                    endTime = Helpers.DateTimeFromReadLine("End time:", startTime, startTime.AddDays(3));

                    choices[5] = $"6. End time - {endTime.ToShortDateString()} {endTime.ToShortTimeString()}";
                    break;
                case "c":
                    _booking.Member = member;
                    _booking.Boat = boat;
                    _booking.SailingArea = sailingArea;
                    _booking.Destination = destination.Length == 0 ? "N/A" : destination;
                    _booking.StartTime = startTime;
                    _booking.EndTime = endTime;
                    Console.WriteLine("Booking updated. Press any key to continue.");
                    Console.ReadKey();
                    return;
            }
        }
    }
}

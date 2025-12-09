
public class ShowBookingController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    private IBoatRepository _boatRepository;
    private IMemberRepository _memberRepository;
    #endregion

    #region Constructor
    public ShowBookingController(IBookingRepository bookingRepository, IBoatRepository boatRepository, IMemberRepository memberRepository)
    {
        _bookingRepository = bookingRepository;
        _boatRepository = boatRepository;
        _memberRepository = memberRepository;
    }
    #endregion


    #region Methods
    /// <summary>
    /// Menu for showing bookings based on different filtering option.
    /// </summary>
    public void ShowBookings()
    {
        List<string> choices = new List<string>
        {
            "1. Show all bookings",
            "2. Show Active booking",
            "3. Show bookings for boat",
            "4. Show bookings for member",
            "\nQ. Back to previous menu"
        };

        string theChoice = Helpers.ReadChoice(choices);

        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    ShowAllBookings();
                    break;
                case "2":
                    ShowActiveBookings();
                    break;
                case "3":
                    ShowBookingsForBoat();
                    break;
                case "4":
                    ShowBookingsForMember();
                    break;
                default:

                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
    }
    /// <summary>
    /// Prints all bookings to the console.
    /// </summary>
    public void ShowAllBookings()
    {
        Console.WriteLine("All bookings: ");
        foreach (Booking booking in _bookingRepository.GetAll())
        {
            Console.WriteLine(booking);
        }
        Console.ReadKey();
    }

    /// <summary>
    /// Prints all active bookings to the console.
    /// </summary>
    private void ShowActiveBookings()
    {
        Console.WriteLine("All active bookings:");
        foreach (Booking booking in _bookingRepository.GetAll())
        {
            if (booking.IsActive)
            {
                Console.WriteLine(booking);
            }
        }

        Console.ReadKey();
    }

    /// <summary>
    /// Prints all bookings for a selected boat to the console.
    /// </summary>
    private void ShowBookingsForBoat()
    {
        Boat? boat = BoatHelpers.SelectBoat(_boatRepository);
        if (boat == null)
        {
            Console.WriteLine("No boat selected. Press any key to continue.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine($"Bookings for boat {boat.Id} {boat.Nickname} {boat.ModelName}: ");
        foreach (Booking booking in _bookingRepository.GetAll())
        {
            if (booking.Boat.Id == boat.Id)
            {
                Console.WriteLine(booking);
            }
        }
        Console.ReadKey();
    }

    /// <summary>
    /// Prints all bookings for a selected member to the console.
    /// </summary>
    private void ShowBookingsForMember()
    {
        Member? member = MemberHelpers.SelectMember(_memberRepository);
        if (member == null)
        {
            Console.WriteLine("No member selected. Press any key to continue.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine($"Bookings for member {member.Id} {member.Name}: ");
        foreach (Booking booking in _bookingRepository.GetAll())
        {
            if (booking.Member.Id == member.Id)
            {
                Console.WriteLine(booking);
            }
        }
        Console.ReadKey();
    }

    


    #endregion
}

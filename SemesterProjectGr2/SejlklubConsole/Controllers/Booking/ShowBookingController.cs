
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
            "5. Activate/Finalize booking",
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
                case "5":
                    BookingActivation();
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
        List<Booking> activeBookings = BookingHelpers.GetActiveBookings(_bookingRepository.GetAllNonArchived());
        
        foreach (Booking booking in activeBookings)
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

        List<Booking> bookingsForBoat = BookingHelpers.GetBookingsByBoat(_bookingRepository.GetAll(), boat);
        foreach (Booking booking in bookingsForBoat)
        {
            Console.WriteLine(booking);
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
        
        List<Booking> bookingsForMember = BookingHelpers.GetBookingsByMember(_bookingRepository.GetAll(), member);
        foreach (Booking booking in bookingsForMember)
        {
            Console.WriteLine(booking);
        }
        Console.ReadKey();
    }

    private void BookingActivation()
    {
        List<string> choices = new List<string>
        {
            "1. Activate booking",
            "2. Finalize booking",
            "\nQ. Back to previous menu"
        };

        string theChoice = Helpers.ReadChoice(choices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Booking? bookingToActivate = BookingHelpers.SelectBooking(_bookingRepository);
                    if (bookingToActivate == null)
                    {
                        Console.WriteLine("No booking selected. Press any key to go back.");
                        Console.ReadKey();
                        break;
                    }
                    BookingActiveController bookingActiveController = new BookingActiveController(_bookingRepository, bookingToActivate);
                    bookingActiveController.ActivateBooking();
                    break;
                case "2":
                    Booking? bookingToFinalize = BookingHelpers.SelectBooking(_bookingRepository, BookingHelpers.GetActiveBookings(_bookingRepository.GetAll()));
                    if (bookingToFinalize == null)
                    {
                        Console.WriteLine("No booking selected. Press any key to go back.");
                        Console.ReadKey();
                        break;
                    }
                    BookingActiveController bookingFinalizeController = new BookingActiveController(_bookingRepository, bookingToFinalize);
                    bookingFinalizeController.FinalizeBooking();
                    break;
                default:
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }


        

    }


    #endregion
}

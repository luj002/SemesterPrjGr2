
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
            "5. Show booking statistics",
            "6. Activate/Finalize booking",
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
                    BookingStatisticsMenu();
                    break;
                case "6":
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

    /// <summary>
    /// Menu for activating or finalizing a booking.
    /// </summary>
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
                        break;
                    }
                    BookingActiveController bookingActiveController = new BookingActiveController(_bookingRepository, bookingToActivate);
                    bookingActiveController.ActivateBooking();
                    break;
                case "2":
                    Booking? bookingToFinalize = BookingHelpers.SelectBooking(_bookingRepository, BookingHelpers.GetActiveBookings(_bookingRepository.GetAll()));
                    if (bookingToFinalize == null)
                    {
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

    /// <summary>
    /// Menu for showing booking statistics.
    /// </summary>
    private void BookingStatisticsMenu()
    {
        List<string> choices = new List<string>
        {
            "1. Show booking statistics for boat",
            "2. Show booking statistics for member",
            "\nQ. Back to previous menu"
        };
        string theChoice = Helpers.ReadChoice(choices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    // Show booking statistics for boat
                    BoatStatisticsMenu();
                    break;
                case "2":
                    // Show booking statistics for member
                    MemberStatisticsMenu();
                    break;
                default:
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
    }

    /// <summary>
    /// Menu for showing boat statistics
    /// </summary>
    private void BoatStatisticsMenu()
    {
        Boat? mostBookedBoat = BookingHelpers.GetBoatWithMostBookings(_bookingRepository.GetAll());
        Boat? longestBookingTimeBoat = BookingHelpers.GetBoatWithLongestBookingTime(_bookingRepository.GetAll());

        int mostBookedCount = mostBookedBoat != null ? BookingHelpers.GetBookingsByBoat(_bookingRepository.GetAll(), mostBookedBoat).Count : 0;
        TimeSpan longestBookingTime = longestBookingTimeBoat != null ? BookingHelpers.TotalTimeBookedForBoat(_bookingRepository.GetAll(), longestBookingTimeBoat) : TimeSpan.Zero;

        List<string> choices = new List<string>
        {
            "1. Show boat statistics for boat (Search by id)",
            "2. Show boat statistics for all boats",
            $"\nMost booked boat ({mostBookedCount} bookings) - {mostBookedBoat.Id} {mostBookedBoat.Nickname}",
            $"Boat with longest booking time ({longestBookingTime.Hours} hours) - {longestBookingTimeBoat.Id} {longestBookingTimeBoat.Nickname}",
            "\nQ. Back to previous menu"
        };
        string theChoice = Helpers.ReadChoice(choices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    // Show boat statistics for boat
                    Boat? boat = BoatHelpers.SelectBoat(_boatRepository);
                    if (boat == null)
                    {
                        Console.WriteLine("No boat selected. Press any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine(BookingHelpers.BookingStatisticForBoatString(_bookingRepository.GetAll(), boat));
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    break;
                case "2":
                    // Show boat statistics for all boats
                    foreach (Boat b in _boatRepository.GetAll())
                    {
                        Console.WriteLine(BookingHelpers.BookingStatisticForBoatString(_bookingRepository.GetAll(), b));
                        Console.WriteLine("---------------------------------------------------");
                    }
                    Console.WriteLine("End of boat statistics. Press any key to go back.");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
    }

    /// <summary>
    /// Menu for showing member statistics
    /// </summary>
    private void MemberStatisticsMenu()
    {
        Member? memberMostBookings = BookingHelpers.GetMemberWithMostBookings(_bookingRepository.GetAll());
        Member? memberLongestBookingTime = BookingHelpers.GetMemberWithLongestBookingTime(_bookingRepository.GetAll());

        int mostBookingsCount = BookingHelpers.GetBookingsByMember(_bookingRepository.GetAll(), memberMostBookings).Count;
        TimeSpan longestBookingTime = BookingHelpers.TotalTimeBookedForMember(_bookingRepository.GetAll(), memberLongestBookingTime);

        List<string> choices = new List<string>
        {
            "1. Show member statistics for member (Search by id)",
            "2. Show member statistics for all members",
            $"\nMember with most bookings ({mostBookingsCount} bookings) - {memberMostBookings.Id} {memberMostBookings.Name}",
            $"Member with longest booking time ({longestBookingTime.Hours} hours) - {memberLongestBookingTime.Id} {memberLongestBookingTime.Name}",
            "\nQ. Back to previous menu"
        };
        string theChoice = Helpers.ReadChoice(choices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    // Show member statistics for member
                    Member? member = MemberHelpers.SelectMember(_memberRepository);
                    if (member == null)
                    {
                        Console.WriteLine("No member selected. Press any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine(BookingHelpers.MemberStatisticsString(_bookingRepository.GetAll(), member));
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    break;
                case "2":
                    // Show member statistics for all members
                    foreach (Member m in _memberRepository.GetAll())
                    {
                        Console.WriteLine(BookingHelpers.MemberStatisticsString(_bookingRepository.GetAll(), m));
                        Console.WriteLine("---------------------------------------------------");
                    }
                    Console.WriteLine("End of member statistics. Press any key to go back.");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }
    }

    #endregion
}

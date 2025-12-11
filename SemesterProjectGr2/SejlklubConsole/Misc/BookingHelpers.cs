public class BookingHelpers
{
    /// <summary>
    /// Finds booking by ID from user input.
    /// </summary>
    /// <param name="bookingRepository">Repository to search from</param>
    /// <returns>The booking with the given ID</returns>
    public static Booking SelectBooking(IBookingRepository bookingRepository)
    {
        bool validInput = false;
        Booking? selectedBooking = null;
        while (!validInput)
        {
            foreach (Booking booking in bookingRepository.GetAll())
            {
                Console.WriteLine($"{booking.Id} - {booking.Member}");
            }
            Console.Write("Enter Booking ID: ");
            try
            {
                int input = int.Parse(Console.ReadLine()!);
                selectedBooking = bookingRepository.GetBookingById(StringId.GetID(IdPrefix.BOOK, input));
                if (selectedBooking != null)
                {
                    validInput = true;
                }
                else
                {
                    throw new ArgumentException("Invalid Booking ID. Please try again.");
                }
            }
            catch (ArgumentException aex)
            {
                Console.Clear();
                Console.WriteLine(aex.Message);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Input was not in the correct format. Please enter a valid Booking ID.");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedBooking!;

    }

    /// <summary>
    /// Gets all bookings for a specific boat from a list of bookings.
    /// </summary>
    /// <param name="bookingList">The list of bookings to get bookings from</param>
    /// <param name="boat">The boat to get bookings for</param>
    /// <returns>List of bookings that use the boat from the given list</returns>
    public static List<Booking> GetBookingsByBoat(List<Booking> bookingList, Boat boat)
    {
        List<Booking> matchingBookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.Boat.Id == boat.Id)
            {
                matchingBookings.Add(booking);
            }
        }
        return matchingBookings;
    }

    /// <summary>
    /// Gets all bookings for a specific member from a list of bookings.
    /// </summary>
    /// <param name="bookingList">The list of bookings to get bookings from</param>
    /// <param name="member">The member to get bookings for</param>
    /// <returns>List of bookings made by the member from the given list</returns>
    public static List<Booking > GetBookingsByMember(List<Booking> bookingList, Member member)
    {
        List<Booking> matchingBookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.Member.Id == member.Id)
            {
                matchingBookings.Add(booking);
            }
        }
        return matchingBookings;
    }

    /// <summary>
    /// Gets all active bookings from a list of bookings.
    /// </summary>
    /// <param name="bookingList">The list of bookings to get bookings from</param>
    /// <returns>List of bookings that are active from the given list</returns>
    public static List<Booking> GetActiveBookings(List<Booking> bookingList)
    {
        List<Booking> activeBookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.IsActive)
            {
                activeBookings.Add(booking);
            }
        }
        return activeBookings;
    }

    /// <summary>
    /// Gets all booking in the specified time interval.
    /// </summary>
    /// <param name="bookingList">List of bookings to get bookings from</param>
    /// <param name="start">Start time of interval</param>
    /// <param name="end">End time of interval</param>
    /// <returns></returns>
    public static List<Booking> GetBookingsInTimeInterval(List<Booking> bookingList,DateTime start, DateTime end)
    {
        List<Booking> bookings = new List<Booking>();
        foreach (Booking booking in bookingList)
        {
            if (booking.StartTime <= end && booking.EndTime >= start)
                bookings.Add(booking);
        }
        return bookings;
    }

    /// <summary>
    /// Validates that the specified booking does not conflict with existing bookings for the same boat within the given
    /// time interval.
    /// </summary>
    /// <param name="bookingsList">The list of existing bookings to check for potential conflicts.</param>
    /// <param name="booking">The booking to validate against the existing bookings.</param>
    /// <exception cref="ArgumentException">Thrown if the boat in <paramref name="booking"/> is already booked for the specified time period.</exception>
    public static bool ValidateBooking(List<Booking> bookingsList, Boat boat, DateTime startTime, DateTime endTime)
    {

        List<Booking> bookings = new List<Booking>();

        bookings = GetBookingsInTimeInterval(bookingsList, startTime, endTime);
        foreach (Booking b in bookings)
        {
            if (b.Boat.Id == boat.Id)
                return false;
        }

        return true;
    }
}
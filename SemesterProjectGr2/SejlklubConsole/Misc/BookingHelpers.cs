public static class BookingHelpers
{
    /// <summary>
    /// Finds booking by ID from user input.
    /// </summary>
    /// <param name="bookingRepository">Repository to search from</param>
    /// <param name="bookings">Optional list of bookings to select from</param>
    /// <returns>The booking with the given ID</returns>
    public static Booking? SelectBooking(IBookingRepository bookingRepository, List<Booking>? bookings = null)
    {
        bool validInput = false;
        Booking? selectedBooking = null;
        bookings ??= bookingRepository.GetAll();

        while (!validInput)
        {
            BookingRepositoryHelpers.PrintBookings(bookings);
            Console.Write("Enter Booking ID (or Q to cancel): ");
            try
            {
                string stringInput = Console.ReadLine().ToLower();

                if (stringInput.Length == 0 || stringInput[0] == 'q')
                    return null;

                int input = int.Parse(stringInput);
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
}
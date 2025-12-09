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
                selectedBooking = bookingRepository.GetBookingById("#BOOK" + input);
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
                Console.WriteLine(aex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input was not in the correct format. Please enter a valid Booking ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedBooking!;

    }
}
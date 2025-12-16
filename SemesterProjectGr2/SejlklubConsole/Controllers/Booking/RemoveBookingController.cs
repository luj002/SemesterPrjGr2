
public class RemoveBookingController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    private Booking? _booking;
    #endregion

    #region Constructor
    public RemoveBookingController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
        _booking = BookingHelpers.SelectBooking(_bookingRepository);
    }
    #endregion

    #region Methods
    public void RemoveBooking()
    {
        if (_booking == null)
        {
            Console.WriteLine("No booking selected. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Booking to delete:\n{_booking}\n");

        bool confirm = Helpers.YesOrNo("Are you sure you want to remove this booking?") ?? false;

        if (confirm)
        {
            _bookingRepository.Remove(_booking.Id);
            Console.WriteLine("Booking removed successfully. Press any key to continue.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Booking removal canceled. Press any key to continue.");
            Console.ReadKey();
        }
    }
    #endregion
}

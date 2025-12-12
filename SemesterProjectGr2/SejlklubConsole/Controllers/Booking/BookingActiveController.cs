public class BookingActiveController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    private Booking _booking;
    #endregion
    #region Constructor
    public BookingActiveController(IBookingRepository bookingRepository, Booking booking)
    {
        _bookingRepository = bookingRepository;
        _booking = booking;
    }
    #endregion

    #region Methods
    public void ActivateBooking()
    {
        bool activate = Helpers.YesOrNoKey($"Do you want to activate {_booking.Id}?");
        if (activate)
        {
            _booking.IsActive = true;
            //_bookingRepository.Update(_booking);
            Console.WriteLine($"Booking {_booking.Id} is now active.");
        }
        else
        {
            Console.WriteLine($"Booking {_booking.Id} remains inactive.");
        }
        Console.ReadKey();
    }

    #endregion
}
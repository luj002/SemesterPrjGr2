
public class RemoveBookingController
{
	#region Instance fields
	private IBookingRepository _bookingRepository;
    private Booking _booking;
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

	}
    #endregion
}

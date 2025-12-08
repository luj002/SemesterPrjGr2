
public class AddBookingController
{
	private IBookingRepository _bookingRepository;
	private Booking _booking;
	
	public AddBookingController(IBookingRepository bookingRepository)
	{
		_bookingRepository = bookingRepository;
    }

	private Booking Booking { get; set; }

    public void AddBooking()
	{
		throw new NotImplementedException();
	}
}

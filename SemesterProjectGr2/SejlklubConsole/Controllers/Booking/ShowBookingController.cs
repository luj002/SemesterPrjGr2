
public class ShowBookingController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    #endregion

    #region Constructor
    public ShowBookingController(IBookingRepository bookingRepository)
	{
        _bookingRepository = bookingRepository;
	}
    #endregion


    #region
    /// <summary>
    /// Prints all bookings to the console.
    /// </summary>
    public void ShowAllBookings()
	{
		foreach (Booking booking in _bookingRepository.GetAll())
        {
            Console.WriteLine(booking);
        }
        Console.ReadKey();
	}
    #endregion
}

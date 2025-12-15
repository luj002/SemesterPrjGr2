public class BookingActiveController
{
    #region Instance fields
    private IBookingRepository _bookingRepository;
    private Booking _booking;
    #endregion

    #region Properties
    public Booking Booking
    {
        get { return _booking; }
    }
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
        if (_booking.IsActive)
        {
            Console.WriteLine($"Booking {_booking.Id} is already active.");
            Console.ReadKey();
            return;
        }

        if (_bookingRepository.GetAllArchived().Contains(_booking))
        {
            Console.WriteLine($"Booking {_booking.Id} is archived and cannot be activated.");
            Console.ReadKey();
            return;
        }

        bool activate = Helpers.YesOrNo($"Do you want to activate {_booking.Id}?") ?? false;
        if (activate)
        {
            _booking.IsActive = true;
            Console.WriteLine($"Booking {_booking.Id} is now active.");
        }
        else
        {
            Console.WriteLine($"Booking {_booking.Id} remains inactive.");
        }
        Console.ReadKey();
    }

    public void FinalizeBooking()
    {
        if (!_booking.IsActive)
        {
            Console.WriteLine($"Booking {_booking.Id} is not active and cannot be finalized.");
            Console.ReadKey();
            return;
        }

        bool finalize = Helpers.YesOrNo($"Do you want to finalize {_booking.Id}?") ?? false;
        if (finalize)
        {
            _booking.IsActive = false;
            _bookingRepository.Archive(_booking.Id);
            Console.WriteLine($"Booking {_booking.Id} is now finalized.");
        }
        else
        {
            Console.WriteLine($"Booking {_booking.Id} remains unfinalized.");
        }
        Console.ReadKey();
    }

    #endregion
}
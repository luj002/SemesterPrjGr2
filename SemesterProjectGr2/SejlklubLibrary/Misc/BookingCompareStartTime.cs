public class BookingCompareStartTime : IComparer<Booking>
{
    public int Compare(Booking? x, Booking? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return DateTime.Compare(x.StartTime, y.StartTime);
    }
}
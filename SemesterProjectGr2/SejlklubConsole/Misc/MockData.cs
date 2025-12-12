public static class MockData
{
    public static Adminstrator Adminstrator = new Adminstrator("Alice Admin", "123 Admin St, Admin City, Adminland", "alice@admin.dk", new DateTime(1990, 1, 1), MemberType.SENIOR);
    private static List<BlogEntry> blogEntries = new List<BlogEntry>()
    {
        new BlogEntry("Welcome to our Sailing Club!", "We are excited to have", Adminstrator),
        new BlogEntry("Upcoming Events", "Don't miss our annual regatta", Adminstrator),
        new BlogEntry("New Boat Arrivals", "Check out the latest additions to our fleet", Adminstrator)
    };

    private static List<Member> members = new List<Member>()
    {
        Adminstrator,
        new Member("Bob Boater", "456 Boat Ln, Boattown, Boatia", "bob@email.dk", new DateTime(1985, 5, 15), MemberType.SENIOR),
        new Member("Cathy Cruiser", "789 Cruise Rd, Cruisecity, Cruiseland", "cathy@email.dk", new DateTime(1992, 8, 22), MemberType.JUNIOR),
        new Member("Derek Dinghy", "101 Dinghy St, Dinghytown, Dinghyland", "derek@email.dk", new DateTime(2000, 3, 10), MemberType.JUNIOR)
    };

    private static List<Boat> boats = new List<Boat>()
    {
        new Boat("B001", BoatType.Sailboat, 1, 1, 2000, "Sea Breeze"),
        new Boat("B002", BoatType.Motorboat, 2, 0, 2015, "Wave Rider"),
        new Boat("B003", BoatType.Kayak, 1, 0, 2018, "River Runner")
    };

    private static List<Booking> bookings = new List<Booking>()
    {
        new Booking(members[1], boats[0], "Coastal Waters", new DateTime(2026, 1, 11, 9, 0, 0), new DateTime(2026, 1, 11, 15, 0, 0), "N/A"),
        new Booking(members[2], boats[1], "Lakeside", new DateTime(2026, 1, 28, 10, 0, 0), new DateTime(2026, 1, 28, 18, 0, 0), "N/A"),
        new Booking(members[3], boats[2], "River Trail", new DateTime(2026, 1, 14, 8, 0, 0), new DateTime(2026, 1, 14, 19, 0, 0), "N/A")
    };

    private static List<BoatSpace> boatSpaces = new List<BoatSpace>()
    {
        new BoatSpace(1, null),
        new BoatSpace(2, null),
        new BoatSpace(3, null)
    };

    public static void PopulateBlogEntries(IBlogEntryRepository blogEntryRepository)
    {
        foreach (var entry in blogEntries)
        {
            blogEntryRepository.Add(entry);
        }
    }
    public static void PopulateMembers(IMemberRepository memberRepository)
    {
        foreach (var member in members)
        {
            memberRepository.Add(member);
        }
    }
    public static void PopulateBoats(IBoatRepository boatRepository)
    {
        foreach (var boat in boats)
        {
            boatRepository.Add(boat);
        }
    }
    public static void PopulateBookings(IBookingRepository bookingRepository)
    {
        foreach (var booking in bookings)
        {
            bookingRepository.Add(booking);
        }
    }

    public static void PopulateBoatSpaces(IBoatSpaceRepository boatSpaceRepository)
    {
        foreach (var boatSpace in boatSpaces)
        {
            boatSpaceRepository.Add(boatSpace);
        }
    }
}
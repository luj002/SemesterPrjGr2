public static class MockData
{
    public static Administrator Adminstrator = new Administrator("Alice Admin", "123 Admin St, Admin City, Adminland", "alice@admin.dk", new DateTime(1990, 1, 1), MemberType.SENIOR, "ThisPasswordIsSecure");
    private static List<BlogEntry> blogEntries = new List<BlogEntry>()
    {
        new BlogEntry("Welcome to our Sailing Club!", "We are excited to have", Adminstrator),
        new BlogEntry("Upcoming Events", "Don't miss our annual regatta", Adminstrator),
        new BlogEntry("New Boat Arrivals", "Check out the latest additions to our fleet", Adminstrator)
    };

    private static List<Member> members = new List<Member>()
    {
        Adminstrator,
        new Member("Bob Boater", "456 Boat Ln, Boattown, Boatia", "bob@email.dk", new DateTime(1985, 5, 15), MemberType.SENIOR, "mynamebob"),
        new Member("Cathy Cruiser", "789 Cruise Rd, Cruisecity, Cruiseland", "cathy@email.dk", new DateTime(1992, 8, 22), MemberType.JUNIOR, "CruiseCityRulez!!"),
        new Member("Derek Dinghy", "101 Dinghy St, Dinghytown, Dinghyland", "derek@email.dk", new DateTime(2000, 3, 10), MemberType.JUNIOR, "mewheniboat")
    };

    private static List<Boat> boats = new List<Boat>()
    {
        new Boat("B001", BoatType.Sailboat, 1, 1, 2000, "Sea Breeze"),
        new Boat("B002", BoatType.Motorboat, 2, 0, 2015, "Wave Rider"),
        new Boat("B003", BoatType.Kayak, 1, 0, 2018, "River Runner")
    };

    private static List<Booking> bookings = new List<Booking>()
    {
        new Booking(members[1], boats[0], "Coastal Waters", new DateTime(2026, 1, 11, 15, 0, 0), new DateTime(2026, 1, 11, 9, 0, 0), "N/A"),
        new Booking(members[1], boats[0], "Coastal Waters", new DateTime(2026, 3, 11, 15, 0, 0), new DateTime(2026, 3, 11, 9, 0, 0), "N/A"),
        new Booking(members[2], boats[1], "Lakeside",new DateTime(2026, 1, 28, 18, 0, 0), new DateTime(2026, 1, 28, 10, 0, 0), "N/A"),
        new Booking(members[3], boats[2], "River Trail", new DateTime(2026, 1, 14, 19, 0, 0), new DateTime(2026, 1, 14, 8, 0, 0), "N/A")
    };

    private static List<BoatSpace> boatSpaces = new List<BoatSpace>()
    {
        new BoatSpace(1, null),
        new BoatSpace(2, null),
        new BoatSpace(3, null)
    };

    //TODO RENAME THESE (we cannot fucking turn this in before renaming these)
    private static List<Event> events = new List<Event>()
    {
        new Event("Hanging with Saddam", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", new DateTime(2026, 1, 20, 10, 00, 00), new DateTime(2026, 1, 20, 15, 00, 00), Adminstrator),
        new Event("Illegal speed boat racing tournament", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", new DateTime(2026, 2, 17, 12, 00, 00), new DateTime(2026, 2, 19, 12, 00, 00), Adminstrator),
        new Event("Normal christmas lunch (NOT A CULT MEETING)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", new DateTime(2026, 6, 06, 12, 00, 00), new DateTime(2026, 6, 06, 16, 30, 00), Adminstrator)
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

    public static void PopulateEvents(IEventRepository eventRepository)
    {
        foreach (var schmevent in events)
        {
            eventRepository.AddEvent(schmevent);
        }
    }
}
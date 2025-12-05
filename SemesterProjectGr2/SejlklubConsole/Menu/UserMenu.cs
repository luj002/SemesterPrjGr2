public class UserMenu
{
    private List<string> menuChoices;
    //for now just use menuChoices.Add(); to populate with menu options
    //todo find a better way to populate this list

    private IBlogEntryRepository blogEntryRepository = new BlogEntryRepository();
    private IBoatRepository boatRepository = new BoatRepository();
    private IBoatSpaceRepository boatSpaceRepository = new BoatSpaceRepository();
    private IBookingRepository bookingRepository = new BookingRepository();
    private IEventRepository eventRepository = new EventRepository();
    private IMemberRepository memberRepository = new MemberRepository();

    private string ReadChoice(List<string> choices)
    {
        Console.Clear();
        foreach (string s in choices)
        {
            Console.WriteLine(s);
        }
        string input = Console.ReadLine();
        return input.ToLower();
    }

    public void ShowMenu()
    {
        string choice = ReadChoice(menuChoices);

        while (choice != "q")
        {
            switch (choice)
            {
                //menu option handling goes here
            }
        }
    }
}


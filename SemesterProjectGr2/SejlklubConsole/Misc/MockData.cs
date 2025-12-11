public static class MockData
{
	public static Adminstrator Adminstrator = new Adminstrator("Alice Admin", "123 Admin St, Admin City, Adminland", "alice@admin.dk", new DateTime(1990, 1, 1), MemberType.SENIOR);
	private static List<BlogEntry> blogEntries = new List<BlogEntry>()
	{
		new BlogEntry("Welcome to our Sailing Club!", "We are excited to have", Adminstrator),
		new BlogEntry("Upcoming Events", "Don't miss our annual regatta", Adminstrator),
		new BlogEntry("New Boat Arrivals", "Check out the latest additions to our fleet", Adminstrator)
	};
	public static void PopulateBlogEntries(IBlogEntryRepository blogEntryRepository)
	{
		foreach (var entry in blogEntries)
		{
			blogEntryRepository.Add(entry);
		}
	}
}
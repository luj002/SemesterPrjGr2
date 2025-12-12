public class ShowBlogEntryController
{
	private IBlogEntryRepository _blogEntryRepository;
	public ShowBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
	}

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    public void ShowAllBlogEntries()
	{
		foreach (BlogEntry blogEntry in _blogEntryRepository.GetAll())
		{
			Console.WriteLine(blogEntry+"\n");
		}
		Console.WriteLine("Press any key to go back...");
		Console.ReadKey();
	}
}

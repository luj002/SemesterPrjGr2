public class ShowBlogEntryController
{
	private IBlogEntryRepository _blogEntryRepository;
	public ShowBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
	}

    /// <summary>
    /// Prints all blog entries in the repository to the console.
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

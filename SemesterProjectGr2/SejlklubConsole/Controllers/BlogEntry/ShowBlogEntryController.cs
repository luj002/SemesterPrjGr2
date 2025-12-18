public class ShowBlogEntryController
{
    #region Instance field
    private IBlogEntryRepository _blogEntryRepository;
    #endregion

    #region Constructor
    public ShowBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
    }
    #endregion

    #region Methods

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
    #endregion
}

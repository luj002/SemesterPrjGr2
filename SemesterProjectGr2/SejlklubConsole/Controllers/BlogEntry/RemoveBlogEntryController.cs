public class RemoveBlogEntryController
{
	#region Instance Fields
	private IBlogEntryRepository _blogEntryRepository;
	#endregion

	#region Constructors
	public RemoveBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
		//BlogEntry = Helpers.SelectBlogEntry(_blogEntryRepository);
	}
	#endregion

	#region Properties
	public BlogEntry BlogEntry { get; set; }
	#endregion

	#region Methods
	public void RemoveBlogEntry()
	{
		Console.WriteLine("BlogEntry to delete:");
		Console.WriteLine(BlogEntry);
		Console.WriteLine();

		bool confirm = Helpers.YesOrNo("Are you sure you want to remove this blogEntry?");

		if (confirm)
			_blogEntryRepository.Remove(BlogEntry.Id);
	}
	#endregion
}



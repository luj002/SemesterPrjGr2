
using System.Reflection.Metadata.Ecma335;

public class RemoveBlogEntryController
{
	#region Instance Fields
	private IBlogEntryRepository _blogEntryRepository;
	private BlogEntry? _blogEntry;
	#endregion

	#region Constructors
	public RemoveBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
		_blogEntry = SelectBlogEntry(_blogEntryRepository);
	}
	#endregion


	#region Methods
	/// <summary>
	/// TO FILL OUT!!!!!
	/// </summary>
	public void RemoveBlogEntry()
	{
		if (_blogEntry == null)
			return;
		Console.Clear();
		Console.WriteLine($"BlogEntry to delete:\n{_blogEntry}\n");

		bool confirm = Helpers.YesOrNoKey("Are you sure you want to remove this blogEntry?");

		if (confirm)
		{
			_blogEntryRepository.Remove(_blogEntry.Id);
			Console.Clear();
			Console.WriteLine("BlogEntry removed successfully. Press any key to continue");
			Console.ReadKey();
		}
		else
		{
			Console.Clear();
			Console.WriteLine("BlogEntry removal cancelled. Press any key to continue");
			Console.ReadKey();
		}
	}

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    /// <param name="blogEntryRepository">TO FILL OUT!!!!!</param>
    /// <returns>TO FILL OUT!!!!!</returns>
    private static BlogEntry? SelectBlogEntry(IBlogEntryRepository blogEntryRepository)
	{
		bool validInput = false;
		BlogEntry? selectedBlogEntry = null;
		while (!validInput)
		{
			foreach (BlogEntry blogEntry in blogEntryRepository.GetAll())
			{
				Console.WriteLine($"{blogEntry.Id} - {blogEntry.Title} - {blogEntry.Content}");
			}
			try
			{
				int input = Helpers.IntFromReadLine("Write the number of the blogentry ID (or 0 to cancel)",0,blogEntryRepository.Count);
				if (input == 0)
					return null;
				selectedBlogEntry = blogEntryRepository.GetBlogEntryById(StringId.GetID(IdPrefix.BLOGENTRY, input));
				if (selectedBlogEntry != null)
				{
					validInput = true;
				}
				else
				{
					throw new ArgumentException("Invalid BlogEntry ID. Please try again.");
				}
			}
			catch (ArgumentException aex)
			{
				Console.WriteLine(aex.Message);
			}

		}
		return selectedBlogEntry!;

	}
	#endregion
}



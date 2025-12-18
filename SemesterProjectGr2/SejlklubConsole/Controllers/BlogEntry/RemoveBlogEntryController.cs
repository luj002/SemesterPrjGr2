
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
	/// Removes the blog entry from the blog entry repository.
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
    /// Prompts the user to select a blog entry.
    /// </summary>
    /// <param name="blogEntryRepository">The repository to select from.</param>
    /// <returns>The selected blog entry, or null if none was found.</returns>
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
				int? input = Helpers.IntFromReadLine("Write the number of the blogentry ID",0,blogEntryRepository.Count);
				if (input == null)
					return null;
				selectedBlogEntry = blogEntryRepository.GetBlogEntryById(StringId.GetID(IdPrefix.BLOGENTRY, (int)input));
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



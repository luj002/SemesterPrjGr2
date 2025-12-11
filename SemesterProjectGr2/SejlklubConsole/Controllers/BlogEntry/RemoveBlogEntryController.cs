
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
	public void RemoveBlogEntry()
	{
		if (_blogEntry == null)
			return;

		Console.WriteLine($"BlogEntry to delete:\n{_blogEntry}\n");

		bool confirm = Helpers.YesOrNo("Are you sure you want to remove this blogEntry?");

		if (confirm)
		{
			_blogEntryRepository.Remove(_blogEntry.Id);
			Console.WriteLine("BlogEntry removed successfully. Press any key to continue");
			Console.ReadKey();
		}
		else
		{
			Console.WriteLine("BlogEntry removal cancelled. Press any key to continue");
			Console.ReadKey();
		}
	}
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
			Console.Write("Enter BlogEntry ID (or Q to cancel): ");
			try
			{
				string stringInput = Console.ReadLine().ToLower();

				if (stringInput.Length == 0 || stringInput[0] == 'q')
					return null;

				int intInput = int.Parse(stringInput);
				selectedBlogEntry = blogEntryRepository.GetBlogEntryById("#MEMB" + intInput);
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
			catch (FormatException)
			{
				Console.WriteLine("Input was not in the correct format. Please enter a valid BlogEntry ID.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An unexpected error occurred: {ex.Message}");
			}

		}
		return selectedBlogEntry!;

	}
	#endregion
}



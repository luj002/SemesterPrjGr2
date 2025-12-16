public class UpdateBlogEntryController
{
	#region Instance Fields
	private IBlogEntryRepository _blogEntryRepository;
	private BlogEntry? _blogEntry;
	#endregion

	#region Constructors
	public UpdateBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
		_blogEntry = SelectBlogEntry(_blogEntryRepository);
	}
	#endregion

	#region Properties
	#endregion

	#region Methods
	/// <summary>
	/// Updates the blogEntry's information, from ReadLine inputs.
	/// </summary>
	public void UpdateBlogEntry()
	{
		if (_blogEntry == null)
		{
			Console.WriteLine("No blogEntry selected. Press any key to continue.");
			Console.ReadKey();
			return;
		}

		string title = _blogEntry.Title;
		string content = _blogEntry.Content;

		List<string> choices = new List<string>
		{
			$"1. Title - {title}",
			$"2. Content - {content}",
			"\nC. Confirm changes",
			"Q. Cancel changes"
		};

		char theChoice = Helpers.ReadChoiceKey(choices);

		while (theChoice != 'c' && theChoice != 'q')
		{
			switch (theChoice)
			{
				case '1':
					Console.Write("Enter title: ");
					title = Console.ReadLine()!;

					choices[0] = $"1. Name - {title}";
					break;
				case '2':
					Console.Write("Enter content: ");
					content = Console.ReadLine()!;

					choices[1] = $"2. Address - {content}";
					break;
				default:
					break;
			}
			theChoice = Helpers.ReadChoiceKey(choices);
		}

		if (theChoice == 'c')
		{
			_blogEntry.Title = title;
			_blogEntry.Content = content;
			Console.WriteLine("BlogEntry updated successfully. Press any key to continue.");
			Console.ReadKey();
		}
		else
		{
			bool confirm = Helpers.YesOrNo("Discard changes?") ?? false;
			if (confirm)
			{
				Console.WriteLine("Changes discarded. Press any key to continue.");
				Console.ReadKey();
			}
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
				int? input = Helpers.IntFromReadLine("Write the number of the blogentry ID",0,blogEntryRepository.Count);
				if (input == null)
					return null;
				selectedBlogEntry = blogEntryRepository.GetBlogEntryById(StringId.GetID(IdPrefix.BLOGENTRY, (int) input));
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



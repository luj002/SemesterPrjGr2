public class AddBlogEntryController
{
	private static Dictionary<string, BlogEntry> _blogEntries = new();
	#region Instance fields
	private IBlogEntryRepository _blogEntryRepository;
	private Administrator _author;
	#endregion

	#region Constructor
	public AddBlogEntryController(IBlogEntryRepository blogEntryRepository, Administrator author)
	{
		_blogEntryRepository = blogEntryRepository;
		if (!_blogEntries.ContainsKey(author.Id)) _blogEntries[author.Id] = new BlogEntry("", "", author);
		_author = author;
		Create();
	}
    #endregion

    #region Methods
    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    private void Create()
	{
		List<string> blogEntryInfoFields = new List<string> { $"1. Title: {_blogEntries[_author.Id].Title}", $"2. Content{_blogEntries[_author.Id].Content}", "\nB. Back (don't save)", "D. Cancel and save as draft", "S. Save and create"};
		string title = _blogEntries[_author.Id].Title;
		string content = _blogEntries[_author.Id].Content;

		char theChoice = Helpers.ReadChoiceKey(blogEntryInfoFields);

		while (true)
		{
			switch (theChoice)
			{
				case '1':
					Console.Write("Enter title: ");
					title = Console.ReadLine()!;

					blogEntryInfoFields[0] = $"1. Title: {title}";
					break;
				case '2':
					Console.Write("Enter content: ");
					content = Console.ReadLine()!;

					blogEntryInfoFields[1] = $"2. Content: {content}";
					break;
				case 'b':
					_blogEntries[_author.Id].Title = "";
					_blogEntries[_author.Id].Content = "";
					return;
				case 'd':
					_blogEntries[_author.Id].Title = title;
					_blogEntries[_author.Id].Content = content;
					return;
				case 's':
					_blogEntries[_author.Id].Title = title;
					_blogEntries[_author.Id].Content = content;
					AddBlogEntry();
					return;
				default:
					Console.WriteLine("Not a valid choice");
					Console.ReadKey();
					break;
			}
			theChoice = Helpers.ReadChoiceKey(blogEntryInfoFields);
		}
	}

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    public void AddBlogEntry()
	{
		Console.WriteLine(_blogEntries[_author.Id]);
		bool AddConfirmed = Helpers.YesOrNoKey("Add this blogEntry?");
		if (AddConfirmed)
			_blogEntryRepository.Add(_blogEntries[_author.Id]);
    }
	#endregion
}


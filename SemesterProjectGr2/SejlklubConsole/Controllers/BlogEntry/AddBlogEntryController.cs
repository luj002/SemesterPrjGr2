public class AddBlogEntryController
{
	private static Dictionary<string, BlogEntry> _blogEntries = new();
	#region Instance fields
	private IBlogEntryRepository _blogEntryRepository;
	private Adminstrator _author;
	#endregion

	#region Constructor
	public AddBlogEntryController(IBlogEntryRepository blogEntryRepository, Adminstrator author)
	{
		_blogEntryRepository = blogEntryRepository;
		if (!_blogEntries.ContainsKey(author.Id)) _blogEntries[author.Id] = new BlogEntry("", "", author);
		_author = author;
		Create();
	}
	#endregion

	#region Methods
	private void Create()
	{
		List<string> blogEntryInfoFields = new List<string> { $"1. Title: {_blogEntries[_author.Id].Title}", $"2. Content\n{_blogEntries[_author.Id].Content}", "\nB. Back (don't save)", "D. Cancel and save as draft", "S. Save and create"};
		string title = _blogEntries[_author.Id].Title;
		string content = _blogEntries[_author.Id].Content;

		string theChoice = ReadChoice(blogEntryInfoFields);

		while (true)
		{
			switch (theChoice.ToLower())
			{
				case "1":
					Console.Write("Enter title: ");
					title = Console.ReadLine()!;

					blogEntryInfoFields[0] = $"1. Title - {title}";
					break;
				case "2":
					Console.Write("Enter content: ");
					content = Console.ReadLine()!;

					blogEntryInfoFields[1] = $"2. Content:\n{content}";
					break;
				case "b":
					_blogEntries[_author.Id].Title = "";
					_blogEntries[_author.Id].Content = "";
					return;
				case "d":
					_blogEntries[_author.Id].Title = title;
					_blogEntries[_author.Id].Content = content;
					return;
				case "s":
					_blogEntries[_author.Id].Title = title;
					_blogEntries[_author.Id].Content = content;
					AddBlogEntry();
					return;
				default:
					Console.WriteLine("Not a valid choice");
					break;
			}
			theChoice = ReadChoice(blogEntryInfoFields);
		}
	}

	private string ReadChoice(List<string> choices)
	{
		Console.Clear();
		foreach (string s in choices)
		{
			Console.WriteLine(s);
		}
		Console.Write("\nYour choice: ");
		string choice = Console.ReadLine()!;
		Console.Clear();

		return choice.ToLower();

	}

	private bool YesOrNo(string question)
	{
		string input = "";
		bool choiceFinalized = false;
		while (!choiceFinalized)
		{
			Console.Write($"{question} [ y / n ]: ");
			try
			{
				input = Console.ReadLine()!.ToLower();
				if (input[0] != 'y' && input[0] != 'n')
					throw new ArgumentException($"Input was not 'y' or 'n'");
				choiceFinalized = true;
			}
			catch (ArgumentException aex)
			{
				Console.WriteLine(aex.Message);
			}
			catch (Exception)
			{
				Console.WriteLine("Input was not valid");
			}
		}
		return input[0] == 'y';
	}

	public void AddBlogEntry()
	{
		Console.WriteLine(_blogEntries[_author.Id]);
		bool AddConfirmed = YesOrNo("Add this blogEntry?");
		if (AddConfirmed)
			_blogEntryRepository.Add(_blogEntries[_author.Id]);
	}
	#endregion
}


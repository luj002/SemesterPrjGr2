public class AddBlogEntryController
{
	#region Instance fields
	private BlogEntry _blogEntry;
	private IBlogEntryRepository _blogEntryRepository;
	#endregion

	#region Properties
	public BlogEntry BlogEntry
	{
		get { return _blogEntry; }
	}
	#endregion

	#region Constructor
	public AddBlogEntryController(IBlogEntryRepository blogEntryRepository)
	{
		_blogEntryRepository = blogEntryRepository;
		_blogEntry = Create();
	}
	#endregion

	#region Methods
	private BlogEntry Create()
	{
		List<string> blogEntryInfoFields = new List<string> { "1. Title", "2. Content", "3. Email", "4. Date of birth", "5. BlogEntry type", "B. Back" };
		string name = "";
		string address = "";
		string email = "";
		DateTime dateOfBirth = new DateTime(0);
		//BlogEntryType blogEntryType = BlogEntryType.SENIOR;

		string theChoice = ReadChoice(blogEntryInfoFields);

		while (theChoice != "b")
		{
			switch (theChoice)
			{
				case "1":
					Console.Write("Enter name: ");
					name = Console.ReadLine();

					blogEntryInfoFields[0] = $"1. Name - {name}";
					break;
				case "2":
					Console.Write("Enter address: ");
					address = Console.ReadLine();

					blogEntryInfoFields[1] = $"2. Address - {address}";
					break;
				case "3":
					Console.Write("Enter email: ");
					email = Console.ReadLine();

					blogEntryInfoFields[2] = $"3. Email - {email}";
					break;
				case "4":
					Console.WriteLine("Enter date of birth");
					int birthYear = IntFromReadLine("Year:", 1900, DateTime.Now.Year);
					int birthMonth = IntFromReadLine("Month:", 1, 12);
					int daysInBirthMonth = DateTime.DaysInMonth(birthYear, birthMonth);
					int birthDay = IntFromReadLine("Date:", 1, daysInBirthMonth);

					dateOfBirth = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);

					blogEntryInfoFields[3] = $"4. Date of birth - {dateOfBirth.ToShortDateString()}";
					break;
				case "5":
					//blogEntryType = blogEntryTypeFromReadLine();

					//blogEntryInfoFields[4] = $"5. BlogEntry type - {blogEntryType}";
					break;
				default:
					Console.WriteLine("Choose 1..5 or b to go back");
					break;
			}
			theChoice = ReadChoice(blogEntryInfoFields);
		}
		return null;
		//return new BlogEntry(name, address, email, dateOfBirth, blogEntryType);
	}

	private string ReadChoice(List<string> choices)
	{
		Console.Clear();
		foreach (string s in choices)
		{
			Console.WriteLine(s);
		}
		Console.Write("\nYour choice: ");
		string choice = Console.ReadLine();
		Console.Clear();

		return choice.ToLower();

	}

	/// <summary>
	/// Handles input of integers.
	/// </summary>
	/// <param name="inputDescription">Description for what will be assigned with the input</param>
	/// <param name="min">Minimum value for input</param>
	/// <param name="max">Maximum value for input</param>
	/// <returns>Int from ReadLine input in specified range</returns>
	private int IntFromReadLine(string inputDescription, int min, int max)
	{
		int input = 0;
		bool validInput = false;
		while (!validInput)
		{
			Console.Write($"{inputDescription} ");
			try
			{
				input = int.Parse(Console.ReadLine());

				if (input < min)
					throw new ArgumentException($"Input must be at least {min}");

				if (input > max)
					throw new ArgumentException($"Input must be less than {max}");

				validInput = true;
			}
			catch (ArgumentException aex)
			{
				Console.Clear();
				Console.WriteLine(aex.Message);
			}
			catch (Exception)
			{
				Console.Clear();
				Console.WriteLine($"Input must be an integer");
			}
		}
		return input;
	}

	/*
	private BlogEntryType blogEntryTypeFromReadLine()
	{
		BlogEntryType type = BlogEntryType.SENIOR; // Type will be overwritten
		BlogEntryType[] blogEntryTypes = Enum.GetValues<BlogEntryType>();

		Console.WriteLine("BlogEntry types:");

		foreach (BlogEntryType blogEntryTypeEnum in blogEntryTypes)
		{
			Console.WriteLine($"{(int) blogEntryTypeEnum + 1}. {blogEntryTypeEnum}");
		}

		int input = IntFromReadLine("\nSelect blogEntry type by number:", 1, blogEntryTypes.Length);

		type = blogEntryTypes[input - 1];

		return type;
	}
	*/

	private bool YesOrNo(string question)
	{
		string input = "";
		bool choiceFinalized = false;
		while (!choiceFinalized)
		{
			Console.Write($"{question} [ y / n ]: ");
			try
			{
				input = Console.ReadLine().ToLower();
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
		Console.WriteLine(BlogEntry);
		bool AddConfirmed = YesOrNo("Add this blogEntry?");
		if (AddConfirmed)
			_blogEntryRepository.Add(BlogEntry);
	}
	#endregion
}


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
		_blogEntry = BlogEntryHelpers.SelectBlogEntry(_blogEntryRepository);
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

		string name = _blogEntry.Name;
		string address = _blogEntry.Address;
		string email = _blogEntry.Email;
		DateTime dateOfBirth = _blogEntry.DateOfBirth;
		BlogEntryType blogEntryType = _blogEntry.Type;

		List<string> choices = new List<string>
		{
			$"1. Name - {name}",
			$"2. Address - {address}",
			$"3. Email - {email}",
			$"4. Date of birth - {dateOfBirth.ToShortDateString()}",
			$"5. BlogEntry type - {blogEntryType}",
			"\nC. Confirm changes",
			"Q. Cancel changes"
		};

		string theChoice = Helpers.ReadChoice(choices);

		while (theChoice != "c" && theChoice != "q")
		{
			switch (theChoice)
			{
				case "1":
					Console.Write("Enter name: ");
					name = Console.ReadLine()!;

					choices[0] = $"1. Name - {name}";
					break;
				case "2":
					Console.Write("Enter address: ");
					address = Console.ReadLine()!;

					choices[1] = $"2. Address - {address}";
					break;
				case "3":
					Console.Write("Enter email: ");
					email = Console.ReadLine()!;

					choices[2] = $"3. Email - {email}";
					break;
				case "4":
					Console.WriteLine("Enter date of birth");
					int birthYear = Helpers.IntFromReadLine("Year:", 1900, DateTime.Now.Year);
					int birthMonth = Helpers.IntFromReadLine("Month:", 1, 12);
					int daysInBirthMonth = DateTime.DaysInMonth(birthYear, birthMonth);
					int birthDay = Helpers.IntFromReadLine("Date:", 1, daysInBirthMonth);

					dateOfBirth = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);

					choices[3] = $"4. Date of birth - {dateOfBirth.ToShortDateString()}";
					break;
				case "5":
					blogEntryType = BlogEntryHelpers.blogEntryTypeFromReadLine();

					choices[4] = $"5. BlogEntry type - {blogEntryType}";
					break;
				default:
					break;
			}
			theChoice = Helpers.ReadChoice(choices);
		}

		if (theChoice == "c")
		{
			_blogEntry.Name = name;
			_blogEntry.Address = address;
			_blogEntry.Email = email;
			_blogEntry.DateOfBirth = dateOfBirth;
			_blogEntry.Type = blogEntryType;
			Console.WriteLine("BlogEntry updated successfully. Press any key to continue.");
			Console.ReadKey();
		}
		else
		{
			bool confirm = Helpers.YesOrNo("Discard changes?");
			if (confirm)
			{
				Console.WriteLine("Changes discarded. Press any key to continue.");
				Console.ReadKey();
			}
		}
	}
	#endregion
}



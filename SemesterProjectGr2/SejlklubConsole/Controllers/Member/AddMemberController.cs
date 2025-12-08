using System.Runtime.InteropServices;

public class AddMemberController
{
    #region Instance fields
    private Member _member;
    private IMemberRepository _memberRepository;
    #endregion

    #region Properties
    public Member Member
    {
        get { return _member; }
    }
    #endregion

    #region Constructor
    public AddMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        _member = Create();
    }
    #endregion

    #region Methods
    private Member Create()
    {
        List<string> memberInfoFields = new List<string> { "1. Name", "2. Address", "3. Email", "4. Date of birth", "5. Member type", "B. Back" };
        string name = "";
        string address = "";
        string email = "";
        DateTime dateOfBirth = new DateTime(0);
        MemberType memberType = MemberType.SENIOR;

        string theChoice = ReadChoice(memberInfoFields);

        while (theChoice != "b")
        {
            switch (theChoice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();

                    memberInfoFields[0] = $"Name - {name}";
                    break;
                case "2":
                    Console.Write("Enter address: ");
                    address = Console.ReadLine();

                    memberInfoFields[1] = $"Address - {address}";
                    break;
                case "3":
                    Console.Write("Enter email: ");
                    email = Console.ReadLine();

                    memberInfoFields[2] = $"Email - {email}";
                    break;
                case "4":
                    Console.WriteLine("Enter date of birth");
                    int birthYear = IntFromReadLine("Year:", 1900, DateTime.Now.Year);
                    int birthMonth = IntFromReadLine("Month:", 1, 12);
                    int daysInBirthMonth = DateTime.DaysInMonth(birthYear, birthMonth);
                    int birthDay = IntFromReadLine("Date:", 1, daysInBirthMonth);

                    dateOfBirth = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);

                    memberInfoFields[3] = $"Date of birth - {dateOfBirth.ToShortDateString()}";
                    break;
                case "5":
                    memberType = memberTypeFromReadLine();

                    memberInfoFields[4] = $"Member type - {memberType}";
                    break;
                default:
                    Console.WriteLine("Choose 1..5 or b to go back");
                    break;
            }
            theChoice = ReadChoice(memberInfoFields);
        }

        return new Member(name, address, email, dateOfBirth, memberType);
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

    private MemberType memberTypeFromReadLine()
    {
        MemberType type = MemberType.SENIOR; // Type will be overwritten
        MemberType[] memberTypes = Enum.GetValues<MemberType>();

        Console.WriteLine("Member types:");

        foreach (MemberType memberTypeEnum in memberTypes)
        {
            Console.WriteLine($"{(int)memberTypeEnum + 1}. {memberTypeEnum}");
        }

        int input = IntFromReadLine("\nSelect member type by number:", 1, memberTypes.Length);

        type = memberTypes[input - 1];

        return type;
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

    public void AddMember()
    {
        Console.WriteLine(Member);
        bool AddConfirmed = YesOrNo("Add this member?");
        if (AddConfirmed)
            _memberRepository.Add(Member);
    }
    #endregion
}


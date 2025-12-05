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
        string[] memberInfoFields = ["Name", "Address", "Email", "Date of birth", "Member type"];
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
                    int birthYear = IntFromReadLine("Year:", 1900, 2026);
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

    private string ReadChoice(string[] choices)
    {
        Console.Clear();
        for (int i = 0; i < choices.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {choices[i]}");
        }
        Console.WriteLine("B. Back");
        Console.Write("\nYour choice: ");
        string choice = Console.ReadLine();
        Console.Clear();

        return choice.ToLower();

    }

    /// <summary>
    /// Handles input of integers.
    /// </summary>
    /// <param name="displayedText">Description for what will be assigned with the input</param>
    /// <param name="min">Minimum value for input</param>
    /// <param name="max">Maximum value for input</param>
    /// <returns>Int from ReadLine input in specified range</returns>
    private int IntFromReadLine(string displayedText, int min, int max)
    {
        int input = 0;
        bool validInput = false;
        while (!validInput)
        {
            Console.Write($"{displayedText} ");
            try
            {
                input = int.Parse(Console.ReadLine());

                if (input < min)
                    throw new ArgumentException($"{displayedText} must be at least {min}");

                if (input > max)
                    throw new ArgumentException($"{displayedText} must be less than {max}");

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
                Console.WriteLine($"{displayedText} must be an integer");
            }
        }
        return input;
    }

    private MemberType memberTypeFromReadLine()
    {
        MemberType type = MemberType.SENIOR; // Type will be overwritten
        MemberType[] memberTypes = Enum.GetValues<MemberType>();

        string memberTypeString = "Member types:\n";

        foreach (MemberType memberTypeEnum in memberTypes)
        {
            memberTypeString += $"{(int)memberTypeEnum + 1}. {memberTypeEnum}\n";
        }

        memberTypeString += "\nSelect member type by number:";

        int input = IntFromReadLine(memberTypeString, 1, memberTypes.Length);

        type = memberTypes[input - 1];

        return type;
    }

    public void AddMember()
    {
        _memberRepository.Add(Member);
    }
    #endregion
}


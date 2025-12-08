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
    /// <summary>
    /// Creates a Member object from ReadLine inputs
    /// </summary>
    /// <returns>returns the created Member object</returns>
    private Member Create()
    {
        List<string> choices = new List<string> { 
            "1. Name", "2. Address", 
            "3. Email", 
            "4. Date of birth", 
            "5. Member type", 
            "\nC. Confirm"
        };
        string name = "";
        string address = "";
        string email = "";
        DateTime dateOfBirth = new DateTime(0);
        MemberType memberType = MemberType.SENIOR;

        string theChoice = MemberHelpers.ReadChoice(choices);

        while (theChoice != "c")
        {
            switch (theChoice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();

                    choices[0] = $"1. Name - {name}";
                    break;
                case "2":
                    Console.Write("Enter address: ");
                    address = Console.ReadLine();

                    choices[1] = $"2. Address - {address}";
                    break;
                case "3":
                    Console.Write("Enter email: ");
                    email = Console.ReadLine();

                    choices[2] = $"3. Email - {email}";
                    break;
                case "4":
                    Console.WriteLine("Enter date of birth");
                    int birthYear = MemberHelpers.IntFromReadLine("Year:", 1900, DateTime.Now.Year);
                    int birthMonth = MemberHelpers.IntFromReadLine("Month:", 1, 12);
                    int daysInBirthMonth = DateTime.DaysInMonth(birthYear, birthMonth);
                    int birthDay = MemberHelpers.IntFromReadLine("Date:", 1, daysInBirthMonth);

                    dateOfBirth = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);

                    choices[3] = $"4. Date of birth - {dateOfBirth.ToShortDateString()}";
                    break;
                case "5":
                    memberType = MemberHelpers.memberTypeFromReadLine();

                    choices[4] = $"5. Member type - {memberType}";
                    break;
                default:
                    break;
            }
            theChoice = MemberHelpers.ReadChoice(choices);
        }

        return new Member(name, address, email, dateOfBirth, memberType);
    }

    /// <summary>
    /// Adds the created member to the repository after confirmation
    /// </summary>
    public void AddMember()
    {
        Console.WriteLine(Member);
        bool AddConfirmed = MemberHelpers.YesOrNo("Add this member?");
        if (AddConfirmed)
            _memberRepository.Add(Member);
    }
    #endregion
}


using System.Runtime.InteropServices;

public class AddMemberController
{
    #region Instance fields
    private Member _member;
    private IMemberRepository _memberRepository;
    #endregion

    #region Constructor
    public AddMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        Create();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Creates a Member object from ReadLine inputs.
    /// </summary>
    /// <returns>returns the created Member object.</returns>
    private void Create()
    {
        List<string> choices = new List<string> {
            "1. Name",
            "2. Address",
            "3. Email",
            "4. Date of birth",
            "5. Member type",
            "\nC. Confirm",
            "Q. Cancel (Discard Member)"
        };
        string name = "";
        string address = "";
        string email = "";
        DateTime dateOfBirth = new DateTime(0);
        MemberType memberType = MemberType.SENIOR;

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
                    DateTime? dateOfBirthInput = Helpers.DateTimeFromReadLine("Enter date of birth", new DateTime(1900, 1, 1), DateTime.Now);
                    if (dateOfBirthInput != null)
                    {
                        dateOfBirth = (DateTime)dateOfBirthInput;

                        choices[3] = $"4. Date of birth - {dateOfBirth.ToShortDateString()}";
                    }
                    break;
                case "5":
                    MemberType? memberTypeInput = MemberHelpers.memberTypeFromReadLine();
                    if (memberTypeInput != null)
                    {
                        memberType = (MemberType)memberTypeInput;

                        choices[4] = $"5. Member type - {memberType}";
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any button to try again.");
                    Console.ReadKey();
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }



        if (theChoice == "c")
        {
            _member = new Member(name, address, email, dateOfBirth, memberType);
            AddMember();
        }
    }

    /// <summary>
    /// Adds the created member to the repository after confirmation.
    /// </summary>
    private void AddMember()
    {
        Console.WriteLine(_member);
        bool AddConfirmed = Helpers.YesOrNo("Add this member?") ?? false;
        if (AddConfirmed)
            _memberRepository.Add(_member);
    }
    #endregion
}


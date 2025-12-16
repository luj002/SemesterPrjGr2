public class UpdateMemberController
{
    #region Instance Fields
    private IMemberRepository _memberRepository;
    private Member? _member;
    #endregion

    #region Constructors
    public UpdateMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        _member = MemberHelpers.SelectMember(_memberRepository);
    }
    #endregion

    #region Properties
    #endregion

    #region Methods
    /// <summary>
    /// Updates the member's information, from ReadLine inputs.
    /// </summary>
    public void UpdateMember()
    {
        if (_member == null)
        {
            Console.WriteLine("No member selected. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        string name = _member.Name;
        string address = _member.Address;
        string email = _member.Email;
        DateTime dateOfBirth = _member.DateOfBirth;
        MemberType memberType = _member.Type;

        List<string> choices = new List<string>
        {
            $"1. Name - {name}",
            $"2. Address - {address}",
            $"3. Email - {email}",
            $"4. Date of birth - {dateOfBirth.ToShortDateString()}",
            $"5. Member type - {memberType}",
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
                    DateTime? dateOfBirthInput = Helpers.DateTimeFromReadLine("Enter date of birth", new DateTime(1900, 1, 1), DateTime.Now);
                    if (dateOfBirthInput != null)
                    {
                        dateOfBirth = (DateTime)dateOfBirthInput;

                        choices[3] = $"4. Date of birth - {dateOfBirth.ToShortDateString()}";
                    }
                    break;
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
                    break;
            }
            theChoice = Helpers.ReadChoice(choices);
        }

        if (theChoice == "c")
        {
            _member.Name = name;
            _member.Address = address;
            _member.Email = email;
            _member.DateOfBirth = dateOfBirth;
            _member.Type = memberType;
            Console.WriteLine("Member updated successfully. Press any key to continue.");
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
    #endregion
}



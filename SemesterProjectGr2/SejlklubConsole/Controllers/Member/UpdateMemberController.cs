using System.Net;
using System.Reflection;
using System.Xml.Linq;

public class UpdateMemberController
{
    #region Instance Fields
    private IMemberRepository _memberRepository;
    #endregion

    #region Constructors
    public UpdateMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        Member = Helpers.SelectMember(_memberRepository);
    }
    #endregion

    #region Properties
    public Member Member { get; set; }
    #endregion

    #region Methods
    public void UpdateMember()
    {
        string name = Member.Name;
        string address = Member.Address;
        string email = Member.Email;
        DateTime dateOfBirth = Member.DateOfBirth;
        MemberType memberType = Member.Type;

        List<string> memberInfoFields = new List<string>
        {
            $"1. Name - {name}",
            $"2. Address - {address}",
            $"3. Email - {email}",
            $"4. Date of birth - {dateOfBirth.ToShortDateString()}",
            $"5. Member type - {memberType}"
        };

        string theChoice = Helpers.ReadChoice(memberInfoFields);


        while (theChoice != "b")
        {
            switch (theChoice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();

                    memberInfoFields[0] = $"1. Name - {name}";
                    break;
                case "2":
                    Console.Write("Enter address: ");
                    address = Console.ReadLine();

                    memberInfoFields[1] = $"2. Address - {address}";
                    break;
                case "3":
                    Console.Write("Enter email: ");
                    email = Console.ReadLine();

                    memberInfoFields[2] = $"3. Email - {email}";
                    break;
                case "4":
                    Console.WriteLine("Enter date of birth");
                    int birthYear = Helpers.IntFromReadLine("Year:", 1900, DateTime.Now.Year);
                    int birthMonth = Helpers.IntFromReadLine("Month:", 1, 12);
                    int daysInBirthMonth = DateTime.DaysInMonth(birthYear, birthMonth);
                    int birthDay = Helpers.IntFromReadLine("Date:", 1, daysInBirthMonth);

                    dateOfBirth = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);

                    memberInfoFields[3] = $"4. Date of birth - {dateOfBirth.ToShortDateString()}";
                    break;
                case "5":
                    memberType = Helpers.memberTypeFromReadLine();

                    memberInfoFields[4] = $"5. Member type - {memberType}";
                    break;
                default:
                    Console.WriteLine("Choose 1..5 or b to go back");
                    break;
            }
            theChoice = Helpers.ReadChoice(memberInfoFields);
        }

        bool confirm = Helpers.YesOrNo("Save changes to member?");

        if (confirm)
        {
            Member.Name = name;
            Member.Address = address;
            Member.Email = email;
            Member.DateOfBirth = dateOfBirth;
            Member.Type = memberType;
            Console.WriteLine("Member updated successfully.");
        }
        else
        {
            Console.WriteLine("Changes discarded.");
        }
    }
    #endregion
}



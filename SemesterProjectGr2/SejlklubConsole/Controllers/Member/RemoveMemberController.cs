
public class RemoveMemberController
{
    #region Instance Fields
    private IMemberRepository _memberRepository;
    #endregion

    #region Constructors
    public RemoveMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        Member = SelectMember();
    }
    #endregion

    #region Properties
    public Member Member { get; set; }
    #endregion

    #region Methods
    private Member SelectMember()
    {
        bool validInput = false;
        Member? selectedMember = null;
        while (!validInput)
        {
            foreach (Member member in _memberRepository.GetAll())
            {
                Console.WriteLine($"{member.Id} - {member.Name} - {member.Email}");
            }
            Console.Write("Enter Member ID to remove: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                selectedMember = _memberRepository.GetMemberById(input);
                if (selectedMember != null)
                {
                    validInput = true;
                }
                else
                {
                    throw new ArgumentException("Invalid Member ID. Please try again.");
                }
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Input was not in the correct format. Please enter a valid Member ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedMember!;

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
    public void RemoveMember()
    {
        Console.WriteLine("Member to delete:");
        Console.WriteLine(Member);
        Console.WriteLine();

        bool confirm = YesOrNo("Are you sure you want to remove this member?");

        if (confirm)
            _memberRepository.Remove(Member.Id);
    }
    #endregion
}



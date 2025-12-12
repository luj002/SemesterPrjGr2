
public class RemoveMemberController
{
    #region Instance Fields
    private IMemberRepository _memberRepository;
    private Member? _member;
    #endregion

    #region Constructors
    public RemoveMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        _member = MemberHelpers.SelectMember(_memberRepository);
    }
    #endregion


    #region Methods
    /// <summary>
    /// Removes the selected member after confirmation.
    /// </summary>
    public void RemoveMember()
    {
        if (_member == null)
            return;

        Console.WriteLine($"Member to delete:\n{_member}\n");

        bool confirm = Helpers.YesOrNo("Are you sure you want to remove this member?");

        if (confirm)
        {
            _memberRepository.Remove(_member.Id);
            Console.WriteLine("Member removed successfully. Press any key to continue");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Member removal cancelled. Press any key to continue");
            Console.ReadKey();
        }
    }
    #endregion
}




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
    public void RemoveMember()
    {
        if (_member == null)
            return;

        Console.WriteLine("Member to delete:");
        Console.WriteLine(_member);
        Console.WriteLine();

        bool confirm = Helpers.YesOrNo("Are you sure you want to remove this member?");

        if (confirm)
            _memberRepository.Remove(_member.Id);
    }
    #endregion
}



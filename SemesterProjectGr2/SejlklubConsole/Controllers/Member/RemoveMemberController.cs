
public class RemoveMemberController
{
    #region Instance Fields
    private IMemberRepository _memberRepository;
    #endregion

    #region Constructors
    public RemoveMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        Member = MemberHelpers.SelectMember(_memberRepository);
    }
    #endregion

    #region Properties
    public Member Member { get; set; }
    #endregion

    #region Methods
    public void RemoveMember()
    {
        Console.WriteLine("Member to delete:");
        Console.WriteLine(Member);
        Console.WriteLine();

        bool confirm = MemberHelpers.YesOrNo("Are you sure you want to remove this member?");

        if (confirm)
            _memberRepository.Remove(Member.Id);
    }
    #endregion
}



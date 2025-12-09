public class ShowMemberController
{
    #region Instance Fields
    private IMemberRepository _memberRepository;
    #endregion

    #region Constructors
    public ShowMemberController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Prints all members to the console.
    /// </summary>
    public void ShowAllMembers()
    {
        foreach (Member member in _memberRepository.GetAll())
        {
            Console.WriteLine(member);
        }
        Console.ReadKey();
    }
    #endregion
}



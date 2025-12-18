//most insecure login ever but cryptography and such is severely out of scope for this project

public class LoginMenu
{
    #region Instance field
    private IMemberRepository _memberRepository = new MemberRepository();
    private string _email;
    private string _password;
    private int _toReturn;
    #endregion

    #region Constructor
    public LoginMenu()
    {
        //in reality we'd probably fetch from a database here
        MockData.PopulateMembers(_memberRepository);
    }
    #endregion

    #region Methods
    public string Login()
    {
        while (true)
        {
            Console.WriteLine("DEBUG ADMIN LOGIN INFO:");
            Console.WriteLine("Email: alice@admin.dk");
            Console.WriteLine("Password: ThisPasswordIsSecure");
            Console.WriteLine();

            Console.WriteLine("Please enter your email:");
            _email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            _password = Console.ReadLine();

            foreach (Member m in _memberRepository.GetAll())
            {
                if (m.Email==_email&&m.CheckPassword(_password))
                {
                    return m.Id;
                }
            }

            Console.WriteLine("Your email or password was incorrect! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    #endregion
}
public class Member
{
    #region Instance field
    private string _password;
    #endregion

    #region Properties
    public string Id { get; }
	public string Name { get; set; }
	public string Address { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
	public MemberType Type { get; set; }
    #endregion

    #region Constructor
    public Member(string name, string address, string email, DateTime dateOfBirth, MemberType type, string password)
    {
        Id = StringId.Next(IdPrefix.MEMBER);
        Name = name;
        Address = address;
        Email = email;
        DateOfBirth = dateOfBirth;
        Type = type;
        _password = password;
    }
    #endregion

    #region Methods
    //DEEPLY UNSAFE WAY TO CHECK PASSWORDS!!!
    public bool CheckPassword(string input)
	{
		if (input == _password)
		{
			return true;
		} 
		else
		{ 
			return false; 
		}
	}
     public override string ToString()
	{
		return $"Member {Id}: {Name}, Address: {Address}, Email: {Email}, DOB: {DateOfBirth.ToShortDateString()}, Type: {Type}";
	}
    #endregion
}
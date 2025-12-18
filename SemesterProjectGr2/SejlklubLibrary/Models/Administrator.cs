public class Administrator : Member
{
    #region Constructor
    public Administrator(string name, string address, string email, DateTime dateOfBirth, MemberType type, string password)
		: base(name, address, email, dateOfBirth, type, password)
	{
    }
    #endregion

    #region Methods
    public override string ToString()
	{
		return $"Administrator {Id}: {Name}, Address: {Address}, Email: {Email}, DOB: {DateOfBirth.ToShortDateString()}, Type: {Type}";
	}
    #endregion
}
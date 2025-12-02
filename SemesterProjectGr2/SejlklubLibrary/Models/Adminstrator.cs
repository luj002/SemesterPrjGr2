public class Adminstrator : Member
{
	public Adminstrator(string name, string address, string email, DateTime dateOfBirth, MemberType type)
		: base(name, address, email, dateOfBirth, type)
	{
	}
	public override string ToString()
	{
		return $"Administrator {Id}: {Name}, Address: {Address}, Email: {Email}, DOB: {DateOfBirth.ToShortDateString()}, Type: {Type}";
	}
}
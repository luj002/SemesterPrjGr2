public class Member
{
	private static int _nextId = 0;
	public int Id { get; }
	public string Name { get; set; }
	public string Address { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
	public MemberType Type { get; set; }
	public Member(string name, string address, string email, DateTime dateOfBirth, MemberType type)
	{
		Id = _nextId++;
		Name = name;
		Address = address;
		Email = email;
		DateOfBirth = dateOfBirth;
		Type = type;
	}
	public override string ToString()
	{
		return $"Member {Id}: {Name}, Address: {Address}, Email: {Email}, DOB: {DateOfBirth.ToShortDateString()}, Type: {Type}";
	}
}
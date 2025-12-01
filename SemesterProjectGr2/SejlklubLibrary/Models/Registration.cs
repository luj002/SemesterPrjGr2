public class Registration {
	private static int _nextId = 0;
	public int Id { get; }
	public Member Member { get; }
	public string? Comment { get; set; }
	public DateTime RegistrationDate { get; }
	public Event Event { get; }
	public Registration(Member member, Event e, string? comment = null)
	{
		Id = _nextId++;
		Member = member;
		RegistrationDate = DateTime.Now;
		Event = e;
		Comment = comment;
	}
	public override string ToString()
	{
		return $"Registration {Id}: Member: {Member.Name}, Event: {Event.Title}, Date: {RegistrationDate}, Comment: {Comment ?? "N/A"}";
	}
}
public class Registration {
	private static int _nextId = 0;
	public string Id { get; }
	public Member Member { get; }
	public string? Comment { get; set; }
	public DateTime RegistrationDate { get; }
	public Event Event { get; }
	public Registration(Member member, Event e, string? comment = null)
	{
		Id = StringId.Next(IdPrefix.REGISTRATION);
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
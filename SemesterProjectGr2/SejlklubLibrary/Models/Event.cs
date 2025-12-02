public class Event
{
	private static int _nextId = 0;
	public int Id { get; }
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public Adminstrator Creator { get; }
	public List<Registration> Registrations { get; }
	public List<Member> Attendees
	{
		get
		{
			List<Member> attendees = new List<Member>();
			foreach (var registration in Registrations)
			{
				attendees.Add(registration.Member);
			}
			return attendees;
		}
	}
	public Event(string title, string description, DateTime startTime, DateTime endTime, Adminstrator creator)
	{
		Id = _nextId++;
		Title = title;
		Description = description;
		StartTime = startTime;
		EndTime = endTime;
		Registrations = new List<Registration>();
		Creator = creator;
	}
	public override string ToString()
	{
		return $"Event {Id}: {Title}, Description: {Description}, Start: {StartTime}, End: {EndTime}, Creator: {Creator.Name}, Registrations: {Registrations.Count}";
	}
	public void ChangeInformation(ProjectEnums.EventChangeType ECT, string changeString)
	{
        Lua.print("changing information...");
	}
}
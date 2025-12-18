public class Event
{
    #region Properties
    public string Id { get; }
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public Administrator Creator { get; }
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
    #endregion

    #region Constructor
    public Event(string title, string description, DateTime startTime, DateTime endTime, Administrator creator)
	{
		Id = StringId.Next(IdPrefix.EVENT);
		Title = title;
		Description = description;
		StartTime = startTime;
		EndTime = endTime;
		Registrations = new List<Registration>();
		Creator = creator;
    }
    #endregion

    #region Methods
    public override string ToString()
	{
		return $"Event {Id}: {Title}, Description: {Description}, Start: {StartTime}, End: {EndTime}, Creator: {Creator.Name}, Registrations: {Registrations.Count}";
	}
    #endregion
}
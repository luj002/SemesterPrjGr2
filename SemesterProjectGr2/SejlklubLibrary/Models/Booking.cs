public class Booking
{
	public string Id { get; }
	public Member Member { get; set; }
    public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public string SailingArea { get; set; }
	public string? Destination { get; set; }
	public bool IsActive { get; set; }
	public Boat Boat { get; set; }
	public Booking(Member member, Boat boat, string sailingArea, DateTime endTime, DateTime? startTime = null, string? destination = null)
	{
		Id = StringId.Next("BOOK");
		Member = member;
		Boat = boat;
		StartTime = startTime ?? DateTime.Now;
		EndTime = endTime;
		SailingArea = sailingArea;
		Destination = destination;
		IsActive = false;
	}
	public override string ToString()
	{
		return $"Booking {Id}: From {StartTime} to {EndTime}, Area: {SailingArea}, Destination: {Destination ?? "N/A"}, Active: {IsActive}";
	}
}
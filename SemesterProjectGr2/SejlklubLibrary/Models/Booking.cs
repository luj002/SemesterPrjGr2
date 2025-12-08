public class Booking
{
	private static int _nextId = 0;
	public int Id { get; }
	public Member Member { get; set; }
    public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public string SailingArea { get; set; }
	public string? Destination { get; set; }
	public bool IsActive { get; set; }
	public Boat Boat { get; set; }
	public Booking(Member member, Boat boat, string sailingArea, DateTime endTime, DateTime? startTime = null, string? destination = null)
	{
		Id = _nextId++;
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
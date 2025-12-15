public class BoatLogEntry
{
	public DateTime Timestamp { get; set; }
	public string Description { get; set; }
	public BoatLogEntry(string description, DateTime? timeStamp = null)
	{
		Timestamp = timeStamp ?? DateTime.Now;
		Description = description;
	}
	public override string ToString()
	{
		return $"{Timestamp}: {Description}";
	}
}
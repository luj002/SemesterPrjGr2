public class BoatLogEntry
{
	public DateTime Timestamp { get; }
	public string Description { get; }
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
public class BoatLogEntryRepository
{
	public Boat Boat { get; }
    public int Count
    {
        get
        {
            return Entries.Count;
        }
    }
    public List<BoatLogEntry> Entries { get; }
	public DateTime? LatestEntryTime
	{
		get
		{
			if (Entries.Count == 0)
			{
				return null;
			}
			DateTime latest = Entries[0].Timestamp;
			foreach (var entry in Entries)
			{
				if (entry.Timestamp > latest)
				{
					latest = entry.Timestamp;
				}
			}
			return latest;
		}
	}
	public BoatLogEntryRepository(Boat boat)
	{
		Boat = boat;
		Entries = new List<BoatLogEntry>();
	}
	public void AddEntry(BoatLogEntry entry)
	{
		Entries.Add(entry);
	}
	public override string ToString()
	{
		return $"Boat Log for {Boat.ModelName}:\n" + string.Join("\n", Entries);
	}
}
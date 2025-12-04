public interface IBoatLogEntryRepository
{
    Boat Boat { get; }
    int Count { get; }
    List<BoatLogEntry> Entries { get; }
    DateTime? LatestEntryTime { get; }
    void AddEntry(BoatLogEntry entry);
}

public class BoatLogEntry
{
    #region Properties
    public DateTime Timestamp { get; set; }
	public string Description { get; set; }
    #endregion

    #region Constructor
    public BoatLogEntry(string description, DateTime? timeStamp = null)
	{
		Timestamp = timeStamp ?? DateTime.Now;
		Description = description;
    }
    #endregion

    #region Methods
    public override string ToString()
	{
		return $"{Timestamp}: {Description}";
	}
    #endregion
}
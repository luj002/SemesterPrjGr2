using System.Numerics;

public class Boat
{
    #region Properties
    public string Id { get; }
	public string ModelName { get; }
	public BoatType Type { get; }
	public string? Nickname { get; set; }
	public string? SailNumber { get; set; }
	public string? Motor { get; set; }
	public double Length { get; set; }
	public double Width { get; set; }
	public double Draft { get; set; }
	public string BuildYear { get; }
	public BoatLogEntryRepository Log { get; }
	public int? AssignedSpace { get; set; }
    #endregion

    #region Constructor
    public Boat(string modelName, BoatType type, double length, double width, double draft, string buildYear, string? nickname = null, string? sailNumber = null, string? motor = null)
	{
		Id = StringId.Next(IdPrefix.BOAT);
		ModelName = modelName;
		Type = type;
		Length = length;
		Width = width;
		Draft = draft;
		BuildYear = buildYear;
		Nickname = nickname;
		SailNumber = sailNumber;
		Motor = motor;
		Log = new BoatLogEntryRepository(this);
    }
    #endregion

    #region Methods
    public override string ToString()
	{
		return $"Model Name: {ModelName}, ({Type}), Length: {Length}m, Width: {Width}m, Draft: {Draft}m, Built: {BuildYear}, Nickname: {Nickname ?? "N/A"}, Sail Number: {SailNumber ?? "N/A"}, Motor: {Motor ?? "N/A"}, Boat space: {AssignedSpace.ToString() ?? "N/A"}";
	}
    #endregion
}

using SejlklubLibrary.Models;
using System.Numerics;

public class Boat
{
	private static int _nextId = 0;
	public int Id { get; }
	public string ModelName { get; }
	public BoatType Type { get; }
	public string? Nickname { get; set; }
	public string? SailNumber { get; set; }
	public string? Motor { get; set; }
	public double Length { get; set; }
	public double Width { get; set; }
	public double Draft { get; set; }
	public string BuildYear { get; }
	public BoatLog Log { get; }
	public Boat(string modelName, BoatType type, double length, double width, double draft, string buildYear, string? nickname = null, string? sailNumber = null, string? motor = null)
	{
		Id = _nextId++;
		ModelName = modelName;
		Type = type;
		Length = length;
		Width = width;
		Draft = draft;
		BuildYear = buildYear;
		Nickname = nickname;
		SailNumber = sailNumber;
		Motor = motor;
		Log = new BoatLog();
	}
	public override string ToString()
	{
		return $"{ModelName} ({Type}), Length: {Length}m, Width: {Width}m, Draft: {Draft}m, Built: {BuildYear}, Nickname: {Nickname ?? "N/A"}, Sail Number: {SailNumber ?? "N/A"}, Motor: {Motor ?? "N/A"}";
	}
}
public enum BoatType
{
	Sailboat,
	Motorboat,
	Canoe,
	Kayak
}
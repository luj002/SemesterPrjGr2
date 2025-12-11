public static class StringId
{
	private static Dictionary<IdPrefix, int> _counters = new();
	public static string Next(IdPrefix prefix)
	{
		if (!_counters.ContainsKey(prefix))
		{
			_counters[prefix] = 0;
		}
		_counters[prefix]++;
		return GetID(prefix, _counters[prefix]);
	}
	public static string GetIdPrefix(IdPrefix prefix)
	{
		return "#"+prefix.ToString().Substring(0,4)+"_";
	}
	public static string GetID(IdPrefix prefix, int id)
	{
		return $"{GetIdPrefix(prefix)}{id:D4}";
	}
}
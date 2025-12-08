public static class StringId
{
	private static Dictionary<string, int> _counters = new Dictionary<string, int>();
	public static string Next(string prefix)
	{
		if (!_counters.ContainsKey(prefix))
		{
			_counters[prefix] = 0;
		}
		_counters[prefix]++;
		return $"#{prefix}{_counters[prefix]}";
	}
}
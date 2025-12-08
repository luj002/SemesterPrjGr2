public class ShowEventController
{
	IEventRepository _eventRepository;

	public ShowEventController(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;
	}

	internal void ShowAllEvents()
	{
		foreach (Event e in _eventRepository.GetAll())
		{
			Console.WriteLine(e);
		}
		Console.ReadKey();
	}
}

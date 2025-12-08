public class RemoveEventController
{
	private IEventRepository _eventRepository;
	private ShowEventController _showEventController;

	public RemoveEventController(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;
        _showEventController = new ShowEventController(eventRepository);
    }

	public void RemoveEvent()
	{
		
		Console.WriteLine("List of all events:");
		_showEventController.ShowAllEvents();
		Console.WriteLine("Enter the ID of the event you wish to remove:");
		try
		{
			_eventRepository.RemoveEvent(_eventRepository.GetEventByID(Int32.Parse(Console.ReadLine())));
		}
		catch (Exception e)
		{
			Console.WriteLine("No event found!");
		}
	}
}

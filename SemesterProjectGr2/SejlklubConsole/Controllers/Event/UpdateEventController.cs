public class UpdateEventController
{
	private IEventRepository _eventRepository;
	private ShowEventController _showEventController;

	public UpdateEventController(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;
		_showEventController = new ShowEventController(eventRepository);
	}

	public void UpdateEvent()
	{
		Console.WriteLine("List of all events:");
		_showEventController.ShowAllEvents();
		Console.WriteLine("Enter the ID of the event you wish to update:");
		try
		{
            Event toBeEdited = _eventRepository.GetEventByID(Int32.Parse(Console.ReadLine()));
        }
		catch (Exception e)
		{
			Console.WriteLine("Something went wrong, please try again.");
		}
		//todo actually finish editing event stuff
	}
}

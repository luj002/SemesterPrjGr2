public class RemoveEventController
{
	private IEventRepository _eventRepository;
	private ShowEventController _showEventController;

	public RemoveEventController(IEventRepository eventRepository, Member remover)
	{
        if (remover is not Administrator)
        {
            //this should probably be a different exception type but that's solidly a later me problem
            throw new RepositoryException(RepositoryExceptionType.Add, "Only administrators may remove events!");
        }

        _eventRepository = eventRepository;
        _showEventController = new ShowEventController(eventRepository);
    }

    /// <summary>
    /// TO FILL OUT!!!!!
    /// </summary>
    public void RemoveEvent()
	{
		
		Console.WriteLine("List of all events:");
		_showEventController.ShowAllEvents();
		Console.WriteLine("Enter the ID of the event you wish to remove:");
		try
		{
			_eventRepository.RemoveEvent(_eventRepository.GetEventByID("#EVEN"+Int32.Parse(Console.ReadLine()!)));
		}
		catch (Exception e)
		{
			Console.WriteLine($"No event found!: {e.Message}");
		}
	}
}

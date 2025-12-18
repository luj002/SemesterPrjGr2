public class ShowEventController
{
    #region Instance field
    IEventRepository _eventRepository;
    #endregion

    #region Constructor
    public ShowEventController(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Prints all events in the event repository to the console.
    /// </summary>
    public void ShowAllEvents()
	{
		foreach (Event e in _eventRepository.GetAll())
		{
			Console.WriteLine(e);
		}
		Console.ReadKey();
	}
    #endregion
}

using System.Net;
using System.Reflection;
using System.Xml.Linq;

//go go gadget spaghetticode

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
		Event toBeEdited = null;
		string theChoice = "";

		Console.WriteLine("List of all events:");
		_showEventController.ShowAllEvents();
		Console.WriteLine("Enter the ID of the event you wish to update:");
		try
		{
            toBeEdited = _eventRepository.GetEventByID("#EVEN"+Int32.Parse(Console.ReadLine()!));
        }
		catch (Exception e)
		{
			Console.WriteLine($"Something went wrong, please try again: {e.Message}");
			theChoice = "q";
		}

		if (toBeEdited == null)
		{
			theChoice = "q";
		}

		//go go gadget bodge job placeholders that'll never get used!
		List<string> choices = new List<string>();
		string title = "";
		string desc = "";
		DateTime startTime = new DateTime();
		DateTime endTime = new DateTime();

		if(theChoice != "q")
		{
            title = toBeEdited.Title;
            desc = toBeEdited.Description;
            startTime = toBeEdited.StartTime;
            endTime = toBeEdited.EndTime;

            choices = new List<string>
        {
            $"1. Title - {title}",
            $"2. Description - {desc}",
            $"3. Start time - {startTime.ToShortDateString()} {startTime.ToShortTimeString()}",
            $"4. End time - {endTime.ToShortDateString()} {endTime.ToShortTimeString()}",
            "\nC. Confirm changes",
            "Q. Cancel changes"
        };

            theChoice = Helpers.ReadChoice(choices);

		}

        while (theChoice != "q" && theChoice != "p")
		{
			switch (theChoice)
			{
				case "1":
					Console.WriteLine("Enter new title:");
					title = Console.ReadLine()!;

					choices[0] = $"1. Title - {title} (Edited)";
					break;
				case "2":
					Console.WriteLine("Enter new description:");
					desc = Console.ReadLine()!;

					choices[1] = $"2. Description - {desc} (Edited)";
					break;
				case "3":
					bool isValid3 = false;
					while (!isValid3)
					{
						isValid3 = true;
						Console.WriteLine("Enter new start date and time with format YYYY-MM-DD HH:MM:SS");
                        string input = Console.ReadLine()!;
                        try
                        {
                            startTime = DateTime.Parse(input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"That's not a valid date and time, please follow the format exactly: {e.Message}");
                            isValid3 = false;
                        }
                    }
					choices[2] = $"3. Start time - {startTime.ToShortDateString()} {startTime.ToShortTimeString()} (Edited)";
					break;
				case "4":
                    bool isValid4 = false;
                    while (!isValid4)
                    {
                        isValid4 = true;
                        Console.WriteLine("Enter new end date and time with format YYYY-MM-DD HH:MM:SS");
                        string input = Console.ReadLine()!;
                        try
                        {
                            endTime = DateTime.Parse(input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"That's not a valid date and time, please follow the format exactly: {e.Message}");
                            isValid4 = false;
                        }
                    }
                    choices[3] = $"4. End time - {endTime.ToShortDateString()} {endTime.ToShortTimeString()} (Edited)";
                    break;
				default:
					break;
			}
			theChoice = Helpers.ReadChoice(choices);
		}
	}
}

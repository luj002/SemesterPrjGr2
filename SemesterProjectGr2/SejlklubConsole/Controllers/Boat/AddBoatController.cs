public class AddBoatController
{
    public Boat BoatInstance { get; set; }
    private IBoatRepository _boatRep;

    public AddBoatController(IBoatRepository boatRep)
    {
        _boatRep = boatRep;
    }
    
    public void Add(string modelName, BoatType type, double length, double width, double draft, string buildYear, string nickname, string sailNumber, string motor)
    {
        BoatInstance = new Boat(modelName,type,length,width,draft,buildYear,nickname,sailNumber,motor);
        _boatRep.Add(BoatInstance);
    }

    private string ReadChoice(List<string> choices)
    {
        Console.Clear();

        foreach (string s in choices)
        {
            Console.WriteLine(s);
        }

        Console.Write("\nYour choice: ");
        string choice = Console.ReadLine();
        Console.Clear();

        return choice.ToLower();
    }

    public void Create()
    {
        List<string> boatChoices = new List<string> { "1. ", "2. Address", "3. Email", "4. Date of birth", "5. Member type", "B. Back" };
        string input = ReadChoice(boatChoices);

        while (input != "b")
        {
            switch (input)
            {
                case "1":
                    Lua.print("aaaaah");
                    break;
            }
        }
    }
}
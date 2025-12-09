
public class RemoveBoatSpaceController
{
    #region Instance Fields
    private IBoatSpaceRepository _boatSpaceRepository;
    #endregion

    #region Constructors
    public RemoveBoatSpaceController(IBoatSpaceRepository boatSpaceRepository)
    {
        _boatSpaceRepository = boatSpaceRepository;
        BoatSpace = BoatSpaceHelpers.SelectBoatSpace(_boatSpaceRepository);
    }
    #endregion

    #region Properties
    public BoatSpace BoatSpace { get; set; }
    #endregion

    #region Methods
    private bool YesOrNo(string question)
    {
        string input = "";
        bool choiceFinalized = false;
        while (!choiceFinalized)
        {
            Console.Write($"{question} [ y / n ]: ");
            try
            {
                input = Console.ReadLine()!.ToLower();
                if (input[0] != 'y' && input[0] != 'n')
                    throw new ArgumentException($"Input was not 'y' or 'n'");
                choiceFinalized = true;
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Input was not valid");
            }
        }
        return input[0] == 'y';
    }
    public void RemoveBoatSpace()
    {
        Console.WriteLine("Boat space to delete:");
        Console.WriteLine(BoatSpace);
        Console.WriteLine();

        bool confirm = YesOrNo("Are you sure you want to remove this boat space?");

        if (confirm)
            _boatSpaceRepository.Remove(BoatSpace.Number);
    }
    #endregion
}




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
    /// <summary>
    /// Removes the boat space from the repository.
    /// </summary>
    public void RemoveBoatSpace()
    {
        if (BoatSpace == null)
        {
            return;
        }
        Console.WriteLine("Boat space to delete:");
        Console.WriteLine(BoatSpace);
        Console.WriteLine();

        bool confirm = Helpers.YesOrNo("Are you sure you want to remove this boat space?");

        if (confirm)
            _boatSpaceRepository.Remove(BoatSpace.Number);
    }
    #endregion
}



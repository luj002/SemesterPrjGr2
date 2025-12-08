public class ShowBoatSpaceController
{
    #region Instance Fields
    private IBoatSpaceRepository _boatSpaceRepository;
    #endregion

    #region Constructors
    public ShowBoatSpaceController(IBoatSpaceRepository boatSpaceRepository)
    {
        _boatSpaceRepository = boatSpaceRepository;
    }
    #endregion

    #region Properties

    #endregion

    #region Methods
    public void ShowAllBoatSpaces()
    {
        foreach (BoatSpace boatSpace in _boatSpaceRepository.GetAll())
        {
            Console.WriteLine(boatSpace);
        }
    }
    #endregion
}



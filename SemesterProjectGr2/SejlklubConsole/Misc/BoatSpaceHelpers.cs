public static class BoatSpaceHelpers
{
    /// <summary>
    /// Finds boat space by number from user input.
    /// </summary>
    /// <param name="boatSpaceRepository">Repository to search from.</param>
    /// <returns>The boat space with the given number.</returns>
    public static BoatSpace? SelectBoatSpace(IBoatSpaceRepository boatSpaceRepository)
    {
        bool validInput = false;
        BoatSpace? selectedBoatSpace = null;
        while (!validInput)
        {
            foreach (BoatSpace boatSpace in boatSpaceRepository.GetAll())
            {
                Console.WriteLine($"{boatSpace.Number}");
            }
            Console.Write("Enter boat space number, or press q to cancel: ");
            try
            {
                string inputString = Console.ReadLine().ToLower();
                if (inputString == "" || inputString == "q")
                {
                    return null;
                }
                else
                {
                    int inputInt = int.Parse(inputString);
                    selectedBoatSpace = boatSpaceRepository.GetBoatSpaceByNumber(inputInt);
                    if (selectedBoatSpace != null)
                    {
                        validInput = true;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid boat space number. Please try again.");
                    }
                }
                
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Input was not in the correct format. Please enter a valid boat space number: {fex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedBoatSpace!;

    }
}


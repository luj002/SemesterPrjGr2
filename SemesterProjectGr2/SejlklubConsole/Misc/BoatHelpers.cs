public class BoatHelpers
{
    /// <summary>
    /// Finds boat by number from user input.
    /// </summary>
    /// <param name="boatRepository">Repository to search from.</param>
    /// <returns>The boat with the given ID.</returns>
    public static Boat SelectBoat(IBoatRepository boatRepository)
    {
        bool validInput = false;
        Boat? selectedBoat = null;
        while (!validInput)
        {
            foreach (Boat boat in boatRepository.GetAll())
            {
                Console.WriteLine($"{boat.Id} - {boat.Nickname} - {boat.ModelName}");
            }
            Console.Write("Enter Boat ID: ");
            try
            {
                int input = int.Parse(Console.ReadLine()!);
                selectedBoat = boatRepository.GetBoatById(StringId.GetID(IdPrefix.BOAT, input));
                if (selectedBoat != null)
                {
                    validInput = true;
                }
                else
                {
                    throw new ArgumentException("Invalid boat ID. Please try again.");
                }
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input was not in the correct format. Please enter a valid boat ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedBoat!;

    }
}

public class BoatHelpers
{
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
            Console.Write("Enter Member ID to remove: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                selectedBoat = boatRepository.GetBoatById(input);
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

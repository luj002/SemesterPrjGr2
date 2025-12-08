public class Helpers
{
    /// <summary>
    /// Handles input of integers.
    /// </summary>
    /// <param name="inputDescription">Description for what will be assigned with the input</param>
    /// <param name="min">Minimum value for input</param>
    /// <param name="max">Maximum value for input</param>
    /// <returns>Int from ReadLine input in specified range</returns>
    public static int IntFromReadLine(string inputDescription, int min, int max)
    {
        int input = 0;
        bool validInput = false;
        while (!validInput)
        {
            Console.Write($"{inputDescription} ");
            try
            {
                input = int.Parse(Console.ReadLine()!);

                if (input < min)
                    throw new ArgumentException($"Input must be at least {min}");

                if (input > max)
                    throw new ArgumentException($"Input must be less than {max}");

                validInput = true;
            }
            catch (ArgumentException aex)
            {
                Console.Clear();
                Console.WriteLine(aex.Message);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Input must be an integer");
            }
        }
        return input;
    }

    /// <summary>
    /// Prints choices to console and reads user input.
    /// </summary>
    /// <param name="choices">List of strings of choices</param>
    /// <returns>The user input</returns>
    public static string ReadChoice(List<string> choices)
    {
        Console.Clear();
        foreach (string s in choices)
        {
            Console.WriteLine(s);
        }
        Console.Write("\nYour choice: ");
        string choice = Console.ReadLine()!;
        Console.Clear();

        return choice.ToLower();

    }
    /// <summary>
    /// Reads yes or no input from console.
    /// </summary>
    /// <param name="question">The question being displayed in console</param>
    /// <returns>true if input from console starts with Y/y, false if input from console starts with N/n</returns>
    public static bool YesOrNo(string question)
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


}

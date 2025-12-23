using System.Collections;

public static class Helpers
{
    /// <summary>
    /// Handles input of integers.
    /// </summary>
    /// <param name="inputDescription">Description for what will be assigned with the input.</param>
    /// <param name="min">Minimum value for input.</param>
    /// <param name="max">Maximum value for input.</param>
    /// <returns>Int from ReadLine input in specified range.</returns>
    public static int? IntFromReadLine(string inputDescription, int min, int max)
    {
        int input = 0;
        bool validInput = false;
        while (!validInput)
        {
            Console.Write($"{inputDescription} (or Q to cancel): ");
            try
            {
                string inputString = Console.ReadLine().ToLower();
                if (inputString == "q")
                    return null;

                input = int.Parse(inputString);

                if (input < min)
                    throw new ArgumentException($"Input must be at least {min}");

                if (input > max)
                    throw new ArgumentException($"Input must be at most {max}");

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
    /// <param name="choices">List of strings of choices.</param>
    /// <returns>The user input.</returns>
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
    /// Prints choices to console and reads next key pressed.
    /// </summary>
    /// <param name="choices">List of strings of choices.</param>
    /// <returns>The user input.</returns>
    public static char ReadChoiceKey(List<string> choices)
    {
        Console.Clear();
        foreach (string s in choices)
        {
            Console.WriteLine(s);
        }
        Console.Write("\nYour choice: ");
        char choice = Console.ReadKey().KeyChar;
        Console.Clear();

        return choice;

    }
    /// <summary>
    /// Reads yes or no input from console.
    /// </summary>
    /// <param name="question">The question being displayed in console.</param>
    /// <returns>True if input from console starts with Y/y, false if input from console starts with N/n.</returns>
    public static bool? YesOrNo(string question)
    {
        string input = "";
        bool choiceFinalized = false;
        while (!choiceFinalized)
        {
            Console.Write($"{question} [ y / n ] (Q to cancel): ");
            try
            {
                input = Console.ReadLine()!.ToLower();
                if (input == "q")
                    return null;

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

    /// <summary>
    /// Reads yes or no input from next key.
    /// </summary>
    /// <param name="question">The question being displayed in console.</param>
    /// <returns>True if input from console starts with Y/y, false if input from console starts with N/n.</returns>
    public static bool YesOrNoKey(string question)
    {
        char? input = null;
        bool choiceFinalized = false;
        while (!choiceFinalized)
        {
            Console.Clear();
            Console.Write($"{question} [ y / n ]: ");
            try
            {
                input = Console.ReadKey().KeyChar;
                if (input != 'y' && input != 'n')
                    throw new ArgumentException($"Input was not 'y' or 'n'");
                choiceFinalized = true;
            }
            catch (ArgumentException aex)
            {
                Console.Clear();
                Console.WriteLine(aex.Message);
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Input was not valid");
                Console.ReadKey();
            }
        }
        return input == 'y';
    }

    /// <summary>
    /// Prints a string representation of a list.
    /// </summary>
    /// <param name="givenTable">The list to print.</param>
    public static void PrintEnumerable(IEnumerable givenTable)
    {
        Console.WriteLine("{" + string.Join(", ", givenTable.Cast<object>()) + "}");
    }


    /// <summary>
    /// Gets a DateTime from ReadLine input within specified range.
    /// </summary>
    /// <param name="inputDescription">Description for the input</param>
    /// <param name="min">Minimum DateTime to allow</param>
    /// <param name="max">Maximum DateTime to allow</param>
    /// <param name="timeIncluded">Whether or not to include time of the day</param>
    /// <returns>A DateTime object corresponding to the given ReadLine inputs</returns>
    public static DateTime? DateTimeFromReadLine(string inputDescription, DateTime min, DateTime max, bool timeIncluded = false)
    {
        DateTime time = DateTime.MinValue;
        bool validInput = false;
        while (!validInput)
        {
            Console.Write($"{inputDescription}: ");
            try
            {
                int year = 0;

                if (min.Year == max.Year)
                {
                    year = min.Year;
                }
                else
                {
                    int? yearInput = IntFromReadLine($"Year ({min.Year} - {max.Year})", min.Year, max.Year);
                    if (yearInput == null)
                        return null;
                    year = (int)yearInput;
                }

                int minMonth = (year == min.Year) ? min.Month : 1;
                int maxMonth = (year == max.Year) ? max.Month : 12;

                int month = 0;

                if ((min.Year == max.Year) && (min.Month == max.Month))
                {
                    month = min.Month;
                }
                else
                {
                    int? monthInput = IntFromReadLine($"Month ({minMonth} - {maxMonth})", minMonth, maxMonth);
                    if (monthInput == null)
                        return null;
                    month = (int)monthInput;
                }

                int minDay = (year == min.Year && month == min.Month) ? min.Day : 1;
                int maxDay = (year == max.Year && month == max.Month) ? max.Day : DateTime.DaysInMonth(year, month);

                int day = 0;

                if ((min.Year == max.Year) && (min.Month == max.Month) && (min.Day == max.Day))
                {
                    day = min.Day;
                }
                else
                {
                    int? dayInput = IntFromReadLine($"Day ({minDay} - {maxDay})", minDay, maxDay);
                    if (dayInput == null)
                        return null;
                    day = (int)dayInput;
                }

                if (timeIncluded)
                {
                    int? hourInput = IntFromReadLine("Hour (0 - 23):", 0, 23);
                    if (hourInput == null)
                        return null;

                    int? minuteInput = IntFromReadLine("Minute (0 - 59):", 0, 59);
                    if (minuteInput == null)
                        return null;
                    time = new DateTime(year, month, day, (int)hourInput, (int)minuteInput, 0);
                }
                else
                {
                    time = new DateTime(year, month, day);
                }

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

        return time;
    }
}

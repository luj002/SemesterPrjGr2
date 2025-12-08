public class Helpers
{
    /// <summary>
    /// Finds member by ID from user input.
    /// </summary>
    /// <param name="memberRepository">Repository to search from</param>
    /// <returns>The member with the given ID</returns>
    public static Member SelectMember(IMemberRepository memberRepository)
    {
        bool validInput = false;
        Member? selectedMember = null;
        while (!validInput)
        {
            foreach (Member member in memberRepository.GetAll())
            {
                Console.WriteLine($"{member.Id} - {member.Name} - {member.Email}");
            }
            Console.Write("Enter Member ID to remove: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                selectedMember = memberRepository.GetMemberById(input);
                if (selectedMember != null)
                {
                    validInput = true;
                }
                else
                {
                    throw new ArgumentException("Invalid Member ID. Please try again.");
                }
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Input was not in the correct format. Please enter a valid Member ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedMember!;

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
        string choice = Console.ReadLine();
        Console.Clear();

        return choice.ToLower();

    }
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
                input = int.Parse(Console.ReadLine());

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
    /// Reads member type from console input.
    /// </summary>
    /// <returns>Member type for corresponding input</returns>
    public static MemberType memberTypeFromReadLine()
    {
        MemberType type = MemberType.SENIOR; // Type will be overwritten
        MemberType[] memberTypes = Enum.GetValues<MemberType>();

        Console.WriteLine("Member types:");

        foreach (MemberType memberTypeEnum in memberTypes)
        {
            Console.WriteLine($"{(int)memberTypeEnum + 1}. {memberTypeEnum}");
        }

        int input = IntFromReadLine("\nSelect member type by number:", 1, memberTypes.Length);

        type = memberTypes[input - 1];

        return type;
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
                input = Console.ReadLine().ToLower();
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


public class MemberHelpers
{
    /// <summary>
    /// Finds member by ID from user input.
    /// </summary>
    /// <param name="memberRepository">Repository to search from.</param>
    /// <returns>The member with the given ID.</returns>
    public static Member? SelectMember(IMemberRepository memberRepository)
    {
        bool validInput = false;
        Member? selectedMember = null;
        while (!validInput)
        {
            foreach (Member member in memberRepository.GetAll())
            {
                Console.WriteLine($"{member.Id} - {member.Name} - {member.Email}");
            }
            Console.Write("Enter Member ID (or Q to cancel): ");
            try
            {
                string stringInput = Console.ReadLine().ToLower();

                if (stringInput.Length == 0 || stringInput[0] == 'q')
                    return null;

                int input = int.Parse(stringInput);
                selectedMember = memberRepository.GetMemberById(StringId.GetID(IdPrefix.MEMBER, input));
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
                Console.Clear();
                Console.WriteLine(aex.Message);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Input was not in the correct format. Please enter a valid Member ID.");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        return selectedMember!;

    }

    /// <summary>
    /// Reads member type from console input.
    /// </summary>
    /// <returns>Member type for corresponding input.</returns>
    public static MemberType memberTypeFromReadLine()
    {
        MemberType type = MemberType.SENIOR; // Type will be overwritten
        MemberType[] memberTypes = Enum.GetValues<MemberType>();

        Console.WriteLine("Member types:");

        foreach (MemberType memberTypeEnum in memberTypes)
        {
            Console.WriteLine($"{(int)memberTypeEnum + 1}. {memberTypeEnum}");
        }

        int input = Helpers.IntFromReadLine("\nSelect member type by number:", 1, memberTypes.Length);

        type = memberTypes[input - 1];

        return type;
    }
}


public static class MemberSort
{
    public static void BubbleSortByAge(List<Member> members)
    {
        int n = members.Count;
        for (int i = 0; i < n - 1; i++)
        {
            // Only goes to n-i-1 because the last i elements are already sorted
            for (int j = 0; j < n - i - 1; j++)
            {
                if (members[j].DateOfBirth > members[j + 1].DateOfBirth)
                {
                    // Swap members[j] and members[j + 1]
                    var temp = members[j];
                    members[j] = members[j + 1];
                    members[j + 1] = temp;
                }
            }
        }
    }


    // Made by Christian outside the scope of 1st semester curriculum 
    public static void BubbleSortWithComparer(List<Member> members, IComparer<Member> comparer)
    {
        int n = members.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (comparer.Compare(members[j], members[j + 1]) > 0)
                {
                    // Swap members[j] and members[j + 1]
                    var temp = members[j];
                    members[j] = members[j + 1];
                    members[j + 1] = temp;
                }
            }
        }
    }
}
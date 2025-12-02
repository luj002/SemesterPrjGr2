using System.Globalization;

public class Lua
{

    public static async Task wait(double givenNumber)
    {

        await Task.Delay((int)(givenNumber * 1000));

    }

    public static void print(params object[] givenObjects)
    {

        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

        foreach (var givenObject in givenObjects)
        {

            if ((givenObject is System.Collections.IEnumerable) == true && (givenObject is string) == false)
            {

                var givenTable = ((System.Collections.IEnumerable)givenObject).Cast<object>().ToList();
                bool isFirstIndex = true;
                int lengthOfTable = givenTable.Count;
                int maxIndex = lengthOfTable - 1;

                for (int index = 0; index < lengthOfTable; index++)
                {

                    var locatedObject = givenTable[index];

                    if (isFirstIndex == true)
                    {

                        Console.Write("{");
                        isFirstIndex = false;

                    }

                    else if (isFirstIndex == false)
                    {

                        Console.Write(", ");

                    }

                    Console.Write(locatedObject);

                    if (index == maxIndex)
                    {

                        Console.Write("}");

                    }

                }

            }

            else
            {

                Console.Write(givenObject);

            }

        }

        Console.WriteLine("");

    }

}
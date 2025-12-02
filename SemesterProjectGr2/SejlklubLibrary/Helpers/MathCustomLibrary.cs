public class MathCustom
{

    public static double random(double min, double max, string intOrDecimal)
    {

        Random RNG = new Random();

        if (intOrDecimal == "int")
        {

            return RNG.Next((int)min, (int)max + 1);

        }

        else if (intOrDecimal == "decimal")
        {

            return RNG.NextDouble() * (max - min) + min;

        }

        else
        {

            return 0;

        }

    }

    public static long factorial(int givenNumber, long sum)
    {

        bool isFirstIteration = false;

        if (sum == 0)
        {

            isFirstIteration = true;
            sum = givenNumber;

        }

        if (givenNumber != 0)
        {

            if (isFirstIteration == false)
            {

                sum *= givenNumber;

            }

            givenNumber -= 1;
            return factorial(givenNumber, sum);

        }

        else if (givenNumber == 0)
        {

            return sum;

        }

        else
        {

            return sum;

        }

    }

}
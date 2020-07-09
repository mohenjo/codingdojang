using System.Numerics;


namespace CD251
{
    public static class Factorial
    {
        public static BigInteger factorial(BigInteger aNumber)
        {
            BigInteger result = 1;

            for (BigInteger i = 1; i <= aNumber; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}

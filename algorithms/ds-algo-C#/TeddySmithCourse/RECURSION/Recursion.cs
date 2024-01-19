namespace TeddySmithCourse.RECURSION
{
    internal class Recursion
    {
        // factorial
        // RECURSION
        public int RecursionFactorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            return num * RecursionFactorial(num - 1);
        }

        // factorial
        // with no RECURSION but Iterative
        public int IterativeFactorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            int factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
    }
}

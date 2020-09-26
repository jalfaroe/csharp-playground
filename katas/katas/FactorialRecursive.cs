namespace katas
{
    public class FactorialRecursive
    {
        /// <summary>
        ///     The factorial of a positive integer n, is the product of all positive integers less than or equal to n.
        ///     Examples
        ///     GetFactorial(0) == 1
        ///     GetFactorial(1) == 1
        ///     GetFactorial(2) == 2
        ///     GetFactorial(3) == 6
        ///     GetFactorial(4) == 24
        /// </summary>
        public long GetFactorial(int n) => (n <= 1) ? 1 : GetFactorial(n - 1) * n;
    }
}
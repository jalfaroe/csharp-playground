using System;

namespace DataStructures.ArraySorting
{
    /// <summary>
    ///     Bubble Sort:
    ///     1. For each item
    ///     2. Compare to next
    ///     3. Swap if greater
    ///     4. Continue to end
    ///     5. Repeat until no swaps are performed
    /// </summary>
    public class BubbleSort<T> where T : IComparable
    {
        /*
         * Iterates over the array, swapping out of order items,
         * This process is repeated util no swaps are performed.
         */
        public T[] Sort(T[] data)
        {
            bool again;

            do
            {
                again = false;
                for (var i = 1; i < data.Length; i++)
                    if (GreaterThan(data, i - 1, i))
                    {
                        Swap(data, i - 1, i);
                        again = true;
                    }
            } while (again);

            return data;
        }

        private static bool GreaterThan(T[] data, int left, int right) => data[left].CompareTo(data[right]) > 0;

        private static void Swap(T[] data, int left, int right)
        {
            var temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }
    }
}
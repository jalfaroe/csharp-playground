using System;

namespace DataStructures.ArraySorting
{
    /// <summary>
    ///     Iterates over the array, if the values are out of order, the algorithm
    ///     walks the value backward in the array until the proper insertion point is found.
    ///     The algorithm is completed when it reaches the end of the array.
    /// </summary>
    public class InsertionSort<T> where T : IComparable
    {
        public T[] Sort(T[] data)
        {
            for (var i = 1; i < data.Length; i++)
            {
                if (LessThan(data, i, i - 1))
                {
                    for (var p = i; p > 0; p--)
                    {
                        if (LessThan(data, p, p - 1))
                            Swap(data, p, p - 1);
                        else
                            break;
                    }
                }
            }

            return data;
        }

        protected bool LessThan(T[] data, int left, int right) => data[left].CompareTo(data[right]) < 0;

        private static void Swap(T[] data, int left, int right)
        {
            var temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }
    }
}
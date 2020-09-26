using System;

namespace katas
{
    /// <summary>
    ///     Find the index position of a given value from an already ordered array.
    /// </summary>
    public class SearchInOrderedArray
    {
        /// <summary>
        ///     Dichotomy Binary Search
        ///
        /// 1. Initialize the lowest index low=0, the highest index high=array.length-1.
        /// 2. Find the middle index mid=(low+high)/2.
        /// 3. Compare the array[mid] with searchValue If the array[mid]==searchValue return mid index,
        ///    If array[mid]>searchValue that the searchValue will be found between low and mid-1.
        /// 4. And so on. Repeat step 3 until you find searchValue or low>=high to terminate the loop.
        /// </summary>
        public int BinarySearch(int[] array, int searchValue)
        {
            var low = 0;
            var high = array.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (array[mid] == searchValue)
                    return mid;

                if (array[mid] < searchValue)
                    low = mid + 1;
                else high = mid - 1;
            }

            return -1;
        }

        public int SearchWithNetFramework(int[] array, int searchValue)
        {
            if (array == null) array = new int[0];

            return Array.BinarySearch(array, 0, array.Length, searchValue);
        }
    }
}
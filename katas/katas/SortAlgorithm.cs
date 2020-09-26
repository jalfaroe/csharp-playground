using System;

namespace katas
{
    public class SortAlgorithm
    {
        /// <summary>
        ///     Compare arrays[j] with arrays[j + 1], if arrays[j] > arrays[j + 1] are exchanged.
        ///     Remaining elements repeat this process, until sorting is completed.
        /// </summary>
        public void Bubble(int[] arrays)
        {
            for (var i = 0; i < arrays.Length - 1; i++)
            for (var j = 0; j < arrays.Length - i - 1; j++)
                //swap
                if (arrays[j] > arrays[j + 1])
                {
                    var flag = arrays[j];
                    arrays[j] = arrays[j + 1];
                    arrays[j + 1] = flag;
                }
        }

        /// <summary>
        ///     It utilizes a divide-and-conquer strategy to quickly sort data items by
        ///     dividing a large array into two smaller arrays.
        /// </summary>
        public void QuickSort(int[] array)
        {
            if (array.Length > 0) QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int low, int high)
        {
            if (low > high) return;

            var i = low;
            var j = high;
            var threshold = array[low];

            // Alternately scanned from both ends of the list
            while (i < j)
            {
                // Find the first position less than threshold from right to left
                while (i < j && array[j] > threshold) j--;

                // Replace the low with a smaller number than the threshold
                if (i < j) array[i++] = array[j];

                // Find the first position greater than threshold from left to right 
                while (i < j && array[i] <= threshold) i++;

                //Replace the high with a number larger than the threshold
                if (i < j) array[j--] = array[i];
            }

            array[i] = threshold;
            QuickSort(array, low, i - 1); // left quickSort
            QuickSort(array, i + 1, high); // right quickSort
        }

        public void SortWithNetFramework(int[] array)
        {
            if (array == null) array = new int[0];

            Array.Sort(array);
        }
    }
}
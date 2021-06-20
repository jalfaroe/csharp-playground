using System;

namespace DataStructures.ArraySorting
{
    /// <summary>
    /// Quick Sort
    /// 1. Pivot: Pick the pivot value in the array.
    /// 2. Partition: Reorder the elements around the pivot point into two unsorted partitions.
    /// 3. Repeat for each partition.
    /// </summary>
    public class QuickSort<T> where T : IComparable
    {
        readonly Random _pivotRng = new Random();

        public T[] Sort(T[] items)
        {
            return quicksort(items, 0, items.Length - 1);
        }

        private T[] quicksort(T[] items, int left, int right)
        {
            if (left < right)
            {
                // Picking a random pivot value
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = partition(items, left, right, pivotIndex);

                // Reordering the values into partitions around the pivot
                quicksort(items, left, newPivot - 1);
                quicksort(items, newPivot + 1, right);
            }

            return items;
        }

        /// <summary>
        /// The partition method works by walking over the partition and moving the
        /// values around the pivot point by swapping the values based on whether they
        /// are greater than or less than the pivot value.
        /// </summary>
        private int partition(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0) // Less Than
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }

        private static void Swap(T[] data, int left, int right)
        {
            var temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }
    }
}
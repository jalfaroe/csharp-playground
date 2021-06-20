namespace DataStructures.ArraySearching
{
    public class ArraySearch
    {
        /// <summary>
        ///     Scan the array, from start to end, comparing each array item against the value being sought.
        ///     O(n) Algorithmic Complexity.
        /// </summary>
        public bool LinearSearch(int[] data, int value)
        {
            foreach (var item in data)
                if (item == value)
                    return true;

            return false;
        }

        /// <summary>
        ///     Starting with a SORTED ARRAY, check the middle array value. If the value is a match, then the value has been found.
        ///     If the value is greater than the sought value, repeat this process for the values to the left, otherwise for the
        ///     values to the right.
        ///     O(n) Algorithmic Complexity.
        /// </summary>
        public bool BinarySearch(int[] data, int value)
        {
            var start = 0;
            var end = data.Length - 1;

            while (start <= end)
            {
                var middle = (start + end) / 2;

                if (data[middle] == value)
                    return true;

                if (data[middle] < value)
                    start = middle + 1;
                else
                    end = middle - 1;
            }

            return false;
        }
    }
}
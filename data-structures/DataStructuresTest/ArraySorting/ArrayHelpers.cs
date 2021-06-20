namespace DataStructuresTest.ArraySorting
{
    public static class ArrayHelpers
    {
        public static int[] CreateUnsortedArray()
        {
            return new[] {9, 8, 7, 6, 5, 4, 3, 1, 2};
        }

        public static bool CheckSorted(int[] data)
        {
            for (var i = 1; i < data.Length; i++)
                if (data[i - 1] > data[i])
                    return false;

            return true;
        }
    }
}
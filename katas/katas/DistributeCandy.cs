using System.Collections.Generic;

namespace katas
{
    public class DistributeCandy
    {
        public int DistributeCandies(int[] candyType)
        {
            var hs = new HashSet<int>(candyType);
            return hs.Count < candyType.Length / 2 ? hs.Count : candyType.Length / 2;
        }
    }
}
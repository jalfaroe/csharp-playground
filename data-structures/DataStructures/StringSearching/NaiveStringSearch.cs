using System;
using System.Collections.Generic;

namespace DataStructures.StringSearching
{
    /// <summary>
    ///     Performance:
    ///     - O(n+m) average performance.
    ///     - O(nm) worst case performance.
    ///     - Requires no pre-processing. Appropriate for small inputs.
    /// </summary>
    public class NaiveStringSearch : IStringSearchAlgorithm
    {
        /*
         * It is a for loop that starts at the beginning of the string being searched,
         * matchCount is the count of the characters of the string being searched for
         * that have currently been found. Then, a while loop executes, which looks for
         * the string being sought at the current index. 
         */
        public IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
        {
            if (toFind == null) throw new ArgumentNullException("toFind");

            if (toSearch == null) throw new ArgumentNullException("toSearch");

            if (toFind.Length > 0 && toSearch.Length > 0)
                for (var startIndex = 0; startIndex <= toSearch.Length - toFind.Length; startIndex++)
                {
                    var matchCount = 0;

                    while (toFind[matchCount] == toSearch[startIndex + matchCount])
                    {
                        matchCount++;

                        if (toFind.Length == matchCount)
                        {
                            yield return new StringSearchMatch(startIndex, matchCount);

                            startIndex += matchCount - 1;
                            break;
                        }
                    }
                }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace katas
{
    public class Anagram
    {
        // Two strings are anagrams if and only if their sorted strings are equal.
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var groupedAnagrams = new Dictionary<string, IList<string>>();

            for (var i = 0; i < strs.Length; i++)
            {
                var str = strs[i];
                var charArray = str.ToCharArray();
                Array.Sort(charArray);
                var key = new string(charArray);

                if (groupedAnagrams.TryGetValue(key, out var group))
                {
                    group.Add(str);
                }
                else
                {
                    groupedAnagrams.Add(key, new List<string> {str});
                }

            }

            return groupedAnagrams.Select(kvp => kvp.Value).ToList();
        }
    }
}
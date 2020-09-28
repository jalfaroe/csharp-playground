using System.Linq;

namespace katas
{
    /// <summary>
    ///     An isogram is a word that has no repeating letters, consecutive or non-consecutive. Implement a function that
    ///     determines whether a string that contains only letters is an isogram. Assume the empty string is an isogram. Ignore
    ///     letter case.
    ///     isIsogram "Dermatoglyphics" == true
    ///     isIsogram "aba" == false
    ///     isIsogram "moOse" == false -- ignore letter case
    /// </summary>
    public class Isogram
    {
        public bool IsIsogram(string str)
        {
            return str.ToLower().Distinct().Count() == str.Length;
        }

        public bool IsIsogram2(string str)
        {
            str = str.ToLower();
            for (var i = 0; i < str.Length; i++)
            for (var j = i + 1; j < str.Length; j++)
                if (str[i] == str[j])
                    return false;

            return true;
        }
    }
}
using System.Linq;
using System.Text.RegularExpressions;

namespace katas
{
    public class Palindrome
    {
        /// <summary>
        ///     A palindrome is a word, number, phrase, or other sequence of characters which reads the same backward as forward, such as madam, racecar.
        ///     Examples
        ///     IsPalindrome("madam") == true
        ///     IsPalindrome("racecar") == true
        ///     IsPalindrome("today") == false
        /// </summary>
        public bool IsPalindrome(object o) => o.ToString().SequenceEqual(o.ToString().Reverse());

        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            var rgx = new Regex("[^a-z0-9]");
            s = rgx.Replace(s, string.Empty);

            return s.SequenceEqual(s.Reverse());
        }
    }
}
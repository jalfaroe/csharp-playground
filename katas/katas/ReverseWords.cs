using System.Text;
using System.Text.RegularExpressions;

namespace katas
{
    public class ReverseWords
    {
        public string ReverseTheWords(string s)
        {
            var result = new StringBuilder();
            s = Regex.Replace(s, @"\s+", " ");
            var split = s.Split(" ");

            for (var i = split.Length - 1; i >= 0; i--)
            {
                result.AppendFormat("{0} ", split[i]);
            }

            return result.ToString().Trim();
        }
    }
}
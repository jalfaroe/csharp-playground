using System.Linq;

namespace katas
{
    public class StringReverse
    {
        public string Reverse(string str) => new string(str.Reverse().ToArray());

        public void Reverse(char[] s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }
    }
}
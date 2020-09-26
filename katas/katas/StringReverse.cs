using System;
using System.Linq;

namespace katas
{
    public class StringReverse
    {
        public string Reverse(string str) => new string(str.Reverse().ToArray());
    }
}
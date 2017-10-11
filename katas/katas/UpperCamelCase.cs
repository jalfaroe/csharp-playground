using System.Linq;
using System;

namespace katas
{
    /// <summary>
    /// From: "How can mirrors be real if our eyes aren't real"
    /// To:     "How Can Mirrors Be Real If Our Eyes Aren't Real"
    /// </summary>
    public class UpperCamelCase
    {
        public string ConvertToUpperCamelCase(string phrase)
        {
            return String.Join(" ", phrase.Split().Select(i => Char.ToUpper(i[0]) + i.Substring(1)));
        }
    }
}

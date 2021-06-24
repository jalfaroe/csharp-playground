using System;

namespace katas
{
    public class Solution
    {
        public string DayOfTheWeek(int day, int month, int year)
        {
            var d = new DateTime(year, month, day);
            return d.DayOfWeek.ToString();
        }
    }
}
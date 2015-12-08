using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public static class StringExtension
    {
        public static string ToUpperFirstLetter(this string s)
        {
            string result = s.First().ToString().ToUpper();
            result += s.Substring(1).ToLower();
            return result;
        }
    }
}

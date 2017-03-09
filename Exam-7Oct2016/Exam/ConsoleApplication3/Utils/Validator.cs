using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3.Utils
{
    public static class Validator
    {
        public static bool ValidateName(string name)
        {
            // Yoda expression should be more suitable here but StyleCop is crying!
            if (name.Length < 2 || name.Length > 31)
            {
                return false;
            }

            if (Regex.IsMatch(name, @"^[\p{L}]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

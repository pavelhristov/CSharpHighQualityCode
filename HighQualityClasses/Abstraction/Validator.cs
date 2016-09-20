using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public static class Validator
    {
        static Validator()
        {
        }

        public static bool IsPositiveNumber(double number, string message)
        {
            if (number<0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
            else
            {
                return true;
            }
        }
    }
}

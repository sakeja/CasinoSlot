using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public static class InputValidator
    {
        public static bool ValidateInput(uint a)
        {
            if (a < uint.MinValue || a > uint.MaxValue) return false;
            else return true;
        }

        public static bool ValidateInput(uint a, uint b)
        {
            if (a < b) return false;
            else return true;
        }
    }
}

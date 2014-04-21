using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    static class ExtensionMethods
    {
        public static int ToRingElement(this char c)
        {
            return Convert.ToInt32(Char.ToLower(c)) - 97;
        }

        public static char ToCharInRing(this int e)
        {
            return Convert.ToChar(e + 97);
        }
    }
}

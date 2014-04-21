using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("CaesarTest")]

namespace Caesar
{
    class ModuloArithmetic
    {
        private readonly int mod;

        public ModuloArithmetic(int mod)
        {
            this.mod = mod;
        }

        public int Congruent(int v)
        {
            return (v >= 0) ? v % mod : Congruent(v + mod);
        }

        public int Inverse(int x) 
        {
            if (x < 0) return this.Inverse(this.Congruent(x));

            var r = Egcd(26, x);
            if (r.Item1 > 1) throw new ArgumentException(string.Format("{0} has no inverse in {1} (gcd({0}, {1}) = {2}", x, mod, r.Item1));
            return Egcd(26, x).Item3;
        }

        public static Tuple<int, int, int> Egcd(int a, int b) 
        {
            if (b == 0) return Tuple.Create(a, 1, 0);
            var dstOld = Egcd(b, a % b);
            var dst = Tuple.Create(dstOld.Item1, dstOld.Item3, dstOld.Item2 - (a / b) * dstOld.Item3);

            return dst;
        } 
    }
}

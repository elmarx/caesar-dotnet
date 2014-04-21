using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class CaesarCipher
    {
        public int A { get; private set; }
        
        public int B { get; private set; }

        private static readonly ModuloArithmetic ring = new ModuloArithmetic(26);

        public CaesarCipher(int a, int b) 
        {
            this.A = a;
            this.B = b;
        }

        public CaesarCipher(string cipherText)
        {
            var frequency = cipherText.ToCharArray().GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).ToArray();

            var c1 = frequency[0].ToRingElement();
            var m1 = 'e'.ToRingElement();

            var c2 = frequency[1].ToRingElement();
            var m2 = 'n'.ToRingElement();

            var a = ring.Congruent(c1 - c2) * ring.Inverse(m1 - m2);
            var b = c1 - m1 * a;

            this.A = ring.Congruent(a);
            this.B = ring.Congruent(b);
        }

        public char Decrypt(char c)
        {
            return Decrypt(c.ToRingElement()).ToCharInRing();
        }

        public int Decrypt(int c)
        {
            return ring.Congruent((c - B) * ring.Inverse(A));
        }

        public char Encrypt(char m)
        {
            return Encrypt(m.ToRingElement()).ToCharInRing();
        }

        public int Encrypt(int m)
        {
            return ring.Congruent(A * m + B);
        }

        public string Decrypt(string c)
        {
            return new String(c.ToCharArray().Select(x => Decrypt(x)).ToArray());
        }

        public string Encrypt(string m)
        {
            return new String(m.ToCharArray().Select(x => Encrypt(x)).ToArray());
        }
    }
}

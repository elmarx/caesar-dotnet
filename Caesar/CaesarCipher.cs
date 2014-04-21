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

        public static CaesarCipher Crack(string c)
        {
            var frequency = c.ToCharArray().GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).ToArray();

            var c1 = CharToRingElement(frequency[0]);
            var m1 = CharToRingElement('e');

            var c2 = CharToRingElement(frequency[1]);
            var m2 = CharToRingElement('n');

            var a = ring.Congruent(c1 - c2) * ring.Inverse(m1 - m2);
            var b = c1 - m1 * a;

            return new CaesarCipher(ring.Congruent(a), ring.Congruent(b));
        }

        public char Decrypt(char c)
        {
            return RingElementToChar(Decrypt(CharToRingElement(c)));
        }

        public int Decrypt(int c)
        {
            return ring.Congruent(
                (c - B) * ring.Inverse(A)
                );
        }

        public char Encrypt(char m)
        {
            return RingElementToChar(
                Encrypt(
                    CharToRingElement(m)
                )
            );
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

        public static int CharToRingElement(char c)
        {
            return Convert.ToInt32(Char.ToLower(c)) - 97;
        }

        public static char RingElementToChar(int e)
        {
            return Convert.ToChar(e + 97);
        }
    }
}

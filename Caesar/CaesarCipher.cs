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

        static readonly Dictionary<char, int> Letters = Enumerable.Range(0, 26).ToDictionary(i => Convert.ToChar(i + 97));
        static readonly char[] StatisticalFrequency = { 'e', 'n' };

        public CaesarCipher(int a, int b) 
        {
            this.A = a;
            this.B = b;
        }

        public static CaesarCipher Crack(string c)
        {
            var frequency = c.ToCharArray().GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).ToArray();

            var ring = new ModuloArithmetic(26);

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
            throw new NotImplementedException();
        }

        public char Encrypt(char m)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string c)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string m)
        {
            throw new NotImplementedException();
        }

        public static int CharToRingElement(char c)
        {
            return Convert.ToInt32(Char.ToLower(c)) - 97;
        }
    }
}

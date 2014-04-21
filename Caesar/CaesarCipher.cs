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
            var frequency = c.ToCharArray().GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);

            return new CaesarCipher(1, 1);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class CaesarSystem
    {
        public int a { get; private set; }
        public int b { get; private set; }

        static readonly Dictionary<Char, int> letters = Enumerable.Range(0, 26).ToDictionary(i => Convert.ToChar(i + 97));
        static readonly char[] statisticalFrequency = {'e', 'n'};

        public CaesarSystem(int a, int b) {
            this.a = a;
            this.b = b;
        }

        public static CaesarSystem crack(String c)
        {
            var frequency = c.ToCharArray().GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);

            return new CaesarSystem(1, 1);
        }

        public char decrypt(char c)
        {
            throw new NotImplementedException();
        }

        public char encrypt(char m)
        {
            throw new NotImplementedException();
        }

        public String decrypt(String c)
        {
            throw new NotImplementedException();
        }

        public String encrypt(String m)
        {
            throw new NotImplementedException();
        }
    }
}

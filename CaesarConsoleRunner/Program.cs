using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caesar.F;

namespace CaesarConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var cipherText = "CKDCSQDLQJEWJGFQIBQIIQDUQJJQJCQJJCKDQIJKGFNAWDRSAQJWSQDUQJJQJCOZZNQJ";
            var system = new CaesarCipher(cipherText);
            Console.WriteLine("A: {0}, B: {1}", system.A, system.B);
            Console.WriteLine(system.Decrypt(cipherText));
            Console.ReadLine();
        }
    }
}

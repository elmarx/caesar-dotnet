using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar.F;

namespace CaesarTest
{
    [TestClass]
    public class FCaesarChiperTest
    {
        [TestMethod]
        public void Crack()
        {
            var crackedSystem = new CaesarCipher("CKDCSQDLQJEWJGFQIBQIIQDUQJJQJCQJJCKDQIJKGFNAWDRSAQJWSQDUQJJQJCOZZNQJ");
            Assert.AreEqual(5, crackedSystem.A);
            Assert.AreEqual(22, crackedSystem.B);
        }

        [TestMethod]
        public void EncryptChars()
        {
            var subject = new CaesarCipher(5, 22);
            Assert.AreEqual('c', subject.Encrypt('w'));
        }

        [TestMethod]
        public void EncryptStrings()
        {
            var subject = new CaesarCipher(5, 22);
            Assert.AreEqual("cozznqj", subject.Encrypt("wollten"));
            Assert.AreEqual("cozznqj", subject.Encrypt("WOLLTEN"));
        }

        [TestMethod]
        public void DecryptStrings()
        {
            var subject = new CaesarCipher(5, 22);
            Assert.AreEqual("wollten", subject.Decrypt("cozznqj"));
        }
    }
}

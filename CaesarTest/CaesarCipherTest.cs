using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar;

namespace CaesarTest
{
    [TestClass]
    public class CaesarChiperTest
    {
        [TestMethod]
        public void CharToRingElement()
        {
            Assert.AreEqual(CaesarCipher.CharToRingElement('a'), 0);
            Assert.AreEqual(CaesarCipher.CharToRingElement('z'), 25);
            Assert.AreEqual(CaesarCipher.CharToRingElement('e'), 4);
        }

        public void RingElementToChar()
        {
            Assert.AreEqual(CaesarCipher.RingElementToChar(0), 'a');
            Assert.AreEqual(CaesarCipher.RingElementToChar(25), 'z');
            Assert.AreEqual(CaesarCipher.RingElementToChar(4), 'e');
        }

        [TestMethod]
        public void Crack()
        {
            var crackedSystem = CaesarCipher.Crack("CKDCSQDLQJEWJGFQIBQIIQDUQJJQJCQJJCKDQIJKGFNAWDRSAQJWSQDUQJJQJCOZZNQJ");
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

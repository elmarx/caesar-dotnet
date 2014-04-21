using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar;

namespace CaesarTest
{
    [TestClass]
    public class CaesarChiperTest
    {
        [TestMethod]
        public void ToRingElementExtensionMethod()
        {
            Assert.AreEqual('a'.ToRingElement(), 0);
            Assert.AreEqual('z'.ToRingElement(), 25);
            Assert.AreEqual('e'.ToRingElement(), 4);
        }

        [TestMethod]
        public void ToCharInRingExtensionMethod()
        {
            Assert.AreEqual(0.ToCharInRing(), 'a');
            Assert.AreEqual(25.ToCharInRing(), 'z');
            Assert.AreEqual(4.ToCharInRing(), 'e');
        }

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

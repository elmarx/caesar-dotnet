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
    }
}

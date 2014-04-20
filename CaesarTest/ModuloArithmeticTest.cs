using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar;

namespace CaesarTest
{
    [TestClass]
    public class ModuloArithmeticTest
    {
        ModuloArithmetic subject;
        

        [TestInitialize]
        public void SetUp()
        {
            subject = new ModuloArithmetic(26);

        }

        [TestMethod]
        public void egcd()
        {
            Assert.AreEqual(Tuple.Create(1, 1, -2), ModuloArithmetic.egcd(27, 13));
            Assert.AreEqual(Tuple.Create(1, 11, -6), ModuloArithmetic.egcd(23, 42));
        }

        [TestMethod]
        public void inverse()
        {
            Assert.AreEqual(subject.inverse(9), 3);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void noInverse()
        {
            subject.inverse(91);
        }
    }
}

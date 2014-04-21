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
        public void Egcd()
        {
            Assert.AreEqual(Tuple.Create(1, 1, -2), ModuloArithmetic.Egcd(27, 13));
            Assert.AreEqual(Tuple.Create(1, 11, -6), ModuloArithmetic.Egcd(23, 42));
        }

        [TestMethod]
        public void Inverse()
        {
            Assert.AreEqual(subject.Inverse(9), 3);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void NoInverse()
        {
            subject.Inverse(91);
        }
    }
}

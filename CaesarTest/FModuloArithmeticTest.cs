using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar.F;

namespace CaesarTest
{
    [TestClass]
    public class FModuloArithmeticTest
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

        [TestMethod]
        public void Congruent()
        {
            Assert.AreEqual(6, subject.Congruent(-20));
            Assert.AreEqual(6, subject.Congruent(32));
            Assert.AreEqual(25, subject.Congruent(-261));
        }
    }
}

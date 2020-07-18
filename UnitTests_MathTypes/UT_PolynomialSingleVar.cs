using System;
using MathTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_MathTypes
{
    [TestClass]
    public class UT_PolynomialSingleVar
    {
        [TestMethod]
        public void TestMethod1()
        {
            var p1 = new PolynomialSingleVar(
                new MonomialSingleVar(2, 1),
                new MonomialSingleVar(3, 2));

            var p2 = new PolynomialSingleVar(
                new MonomialSingleVar(3, 2),
                new MonomialSingleVar(7, 3));

            var result = new PolynomialSingleVar(
                new MonomialSingleVar(2, 1),
                new MonomialSingleVar(6, 2),
                new MonomialSingleVar(7, 3));

            Assert.AreEqual(result, p1 + p2);
        }
    }
}

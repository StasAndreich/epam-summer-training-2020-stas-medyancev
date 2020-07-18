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
            var p1 = new PolynomialSingleVar(0, 2, 3);// 3x^2 + 2x + 0 + 0x^3

            var p2 = new PolynomialSingleVar(0, 0, 3, 7);// 7x^3 + 3x^2 + 0x + 0

            var result = new PolynomialSingleVar(0, 2, 6, 7);// 7x^3 + 6x^2 + 2x + 0

            //var sum = p1 + p2;
            
            //Assert.IsTrue(result.Equals(sum));
        }
    }
}

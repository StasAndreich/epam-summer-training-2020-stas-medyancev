using System;
using MathTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_MathTypes
{
    [TestClass]
    public class UT_PolynomialSingleVar
    {
        [TestMethod]
        public void AdditionOperatorOverloading_TwoPolynomials_CorrectPolynomial()
        {
            var p1 = new PolynomialSingleVar(0, 2, 3);// 3x^2 + 2x + 0 + 0x^3

            var p2 = new PolynomialSingleVar(0, 0, 3, 7);// 7x^3 + 3x^2 + 0x + 0

            var result = new PolynomialSingleVar(0, 2, 6, 7);// 7x^3 + 6x^2 + 2x + 0

            var sum = p1 + p2;

            Assert.IsTrue(result.Equals(sum));
        }

        [TestMethod]
        public void SubtractionOperatorOverloading_TwoPolynomials_CorrectPolynomial()
        {
            var p1 = new PolynomialSingleVar(0, 2, 3, 0, 1, 1);// 3x^2 + 2x + 0 + 0x^3

            var p2 = new PolynomialSingleVar(0, 0, 3, 7, -8);// 7x^3 + 3x^2 + 0x + 0

            var result = new PolynomialSingleVar(0, 2, 0, -7, 9, 1);// 7x^3 + 6x^2 + 2x + 0

            //var dif = p1 - p2;
            var dif = p1.Minus(p1, p2);

            Assert.IsTrue(result.Equals(p1 - p2));
        }
    }
}

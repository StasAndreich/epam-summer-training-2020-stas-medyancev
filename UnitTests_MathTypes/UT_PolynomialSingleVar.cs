using System;
using MathTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_MathTypes
{
    [TestClass]
    public class UT_PolynomialSingleVar
    {
        private const double tolerance = 0.000001;

        [TestMethod]
        public void AdditionOperatorOverloading_TwoPolynomials_CorrectPolynomial()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Rand params for 1st poly.
                var paramsCount1 = rand.Next(1, 100);
                var paramsArray1 = new double[paramsCount1];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount1; j++)
                {
                    paramsArray1[j] = rand.Next(0, 10000) * rand.NextDouble();
                }
                //
                //
                // Rand params for 2nd poly.
                var paramsCount2 = rand.Next(1, 100);
                var paramsArray2 = new double[paramsCount2];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount2; j++)
                {
                    paramsArray2[j] = rand.Next(0, 10000) * rand.NextDouble();
                }

                // Create polys.
                var poly1 = new PolynomialSingleVar(paramsArray1);
                var poly2 = new PolynomialSingleVar(paramsArray2);

                // Calc result.
                // Create a new obj.
                var resultPoly = poly1.GetCopy();
                for (int j = 0; j < poly2.Count; j++)
                {
                    resultPoly.AddMember(poly2[j]);
                }

                if (!resultPoly.Equals(poly1 + poly2))
                    throw new ApplicationException("Sum of two polynomials is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SubtractionOperatorOverloading_TwoPolynomials_CorrectPolynomial()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Rand params for 1st poly.
                var paramsCount1 = rand.Next(1, 100);
                var paramsArray1 = new double[paramsCount1];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount1; j++)
                {
                    paramsArray1[j] = rand.Next(0, 10000) * rand.NextDouble();
                }
                //
                //
                // Rand params for 2nd poly.
                var paramsCount2 = rand.Next(1, 100);
                var paramsArray2 = new double[paramsCount2];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount2; j++)
                {
                    paramsArray2[j] = rand.Next(0, 10000) * rand.NextDouble();
                }

                // Create polys.
                var poly1 = new PolynomialSingleVar(paramsArray1);
                var poly2 = new PolynomialSingleVar(paramsArray2);

                // Calc result.
                // Create a new obj.
                var resultPoly = poly1.GetCopy();
                for (int j = 0; j < poly2.Count; j++)
                {
                    if (poly2[j].Exponent > resultPoly.MaxExponent)
                        resultPoly.AddMember(poly2[j].Exponent,
                                             -poly2[j].Coefficient);
                    else
                        resultPoly[j].Coefficient -= poly2[j].Coefficient;
                }

                if (!resultPoly.Equals(poly1 - poly2))
                    throw new ApplicationException("Difference of two polynomials is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MultiplicationOperatorOverloading_TwoPolynomials_CorrectPolynomial()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Rand params for 1st poly.
                var paramsCount1 = rand.Next(1, 100);
                var paramsArray1 = new double[paramsCount1];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount1; j++)
                {
                    paramsArray1[j] = rand.Next(0, 10000) * rand.NextDouble();
                }
                //
                //
                // Rand params for 2nd poly.
                var paramsCount2 = rand.Next(1, 100);
                var paramsArray2 = new double[paramsCount2];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount2; j++)
                {
                    paramsArray2[j] = rand.Next(0, 10000) * rand.NextDouble();
                }

                // Create polys.
                var poly1 = new PolynomialSingleVar(paramsArray1);
                var poly2 = new PolynomialSingleVar(paramsArray2);

                // Calc result.
                // Create a new obj.
                var resultPoly = new PolynomialSingleVar();
                for (int j = 0; j < poly1.Count; j++)
                {
                    for (int k = 0; k < poly2.Count; k++)
                    {
                        resultPoly.AddMember(poly1[j] * poly2[k]);
                    }
                }

                if (!resultPoly.Equals(poly1 * poly2))
                    throw new ApplicationException("Product of two polynomials is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DivisionOperatorOverloading_PolynomialsDivideOnMonomial_CorrectPolynomial()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Rand params for poly.
                var paramsCount = rand.Next(1, 100);
                var paramsArray = new double[paramsCount];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount; j++)
                {
                    paramsArray[j] = rand.Next(0, 10000) * rand.NextDouble();
                }
                //
                //
                // Rand params for monomial.
                var coef = rand.Next(1, 10000) * rand.NextDouble();
                var exp = rand.Next(0, paramsArray.Length);

                // Create poly and mono.
                var poly = new PolynomialSingleVar(paramsArray);
                var mono = new MonomialSingleVar(coef, exp);

                // Calc result.
                // Create a new obj.
                var resultPoly = new PolynomialSingleVar();
                for (int j = 0; j < poly.Count; j++)
                {
                    // Check if mono exp is not bigger than current poly member.
                    if (poly[j].Exponent >= mono.Exponent)
                    {
                        resultPoly.AddMember(poly[j] / mono);
                    }
                }

                if (!resultPoly.Equals(poly / mono))
                    throw new ApplicationException("Division of polynomial on monomial is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EqualityOperatorOverloading_TwoEqualPolynomials_BooleanTrue()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                var paramsCount = rand.Next(1, 100);
                var paramsArray = new double[paramsCount];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount; j++)
                {
                    paramsArray[j] = rand.Next(0, 10000) * rand.NextDouble();
                }

                // Get evaluated value from polnomial.
                var poly1 = new PolynomialSingleVar(paramsArray);
                var poly2 = new PolynomialSingleVar(paramsArray);

                // If evaluated != expected.
                if (!poly1.Equals(poly2))
                    throw new ApplicationException("Equality of two equal polynomials is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InequalityOperatorOverloading_TwoEqualPolynomials_BooleanTrue()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Rand params for 1st poly.
                var paramsCount1 = rand.Next(1, 100);
                var paramsArray1 = new double[paramsCount1];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount1; j++)
                {
                    paramsArray1[j] = rand.Next(0, 10000) * rand.NextDouble();
                }
                //
                //
                // Rand params for 2nd poly.
                var paramsCount2 = rand.Next(1, 100);
                var paramsArray2 = new double[paramsCount2];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount2; j++)
                {
                    paramsArray2[j] = rand.Next(0, 10000) * rand.NextDouble();
                }

                // Create equal polys.
                var poly1 = new PolynomialSingleVar(paramsArray1);
                var poly2 = new PolynomialSingleVar(paramsArray2);

                if (poly1.Equals(poly2))
                    throw new ApplicationException("Inequality of two equal polynomials is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Evaluate_DoubleValue_EvaluatedPolynomialValue()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                var paramsCount = rand.Next(1, 100);
                var paramsArray = new double[paramsCount];

                // Fill in array with rand nums.
                for (int j = 0; j < paramsCount; j++)
                {
                    paramsArray[j] = rand.Next(0, 10000) * rand.NextDouble();
                }

                var evaluateDouble = rand.Next(0, 10000) * rand.NextDouble();

                // Calc evaluated value from rand array.
                double expected = 0;
                for (int k = 0; k < paramsArray.Length; k++)
                {
                    expected += Math.Pow(evaluateDouble, k) * paramsArray[k];
                }

                // Get evaluated value from polnomial.
                var poly = new PolynomialSingleVar(paramsArray);
                var evaluated = poly.Evaluate(evaluateDouble);

                // If evaluated != expected.
                if (Math.Abs(evaluated - expected) > tolerance)
                    throw new ApplicationException("Evaluation value is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }
    }
}

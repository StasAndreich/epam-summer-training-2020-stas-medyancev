using System;
using EuclideanAlgo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_EuclideanAlgo
{
    [TestClass]
    public class UT_GCD
    {
        #region Zero-params cases
        [TestMethod]
        public void GetEuclideanGCD_ZeroAsTwoParams_ZeroResult()
        {
            var zeroResult = 0;

            int gcdResult = GCD.GetEuclideanGCD(0, 0);

            Assert.AreEqual(gcdResult, zeroResult);
        }

        [TestMethod]
        public void GetEuclideanGCD_ZeroAsThreeParams_ZeroResult()
        {
            var zeroResult = 0;

            int gcdResult = GCD.GetEuclideanGCD(0, 0, 0);

            Assert.AreEqual(gcdResult, zeroResult);
        }

        [TestMethod]
        public void GetEuclideanGCD_ZeroAsFourParams_ZeroResult()
        {
            var zeroResult = 0;

            int gcdResult = GCD.GetEuclideanGCD(0, 0, 0, 0);

            Assert.AreEqual(gcdResult, zeroResult);
        }

        [TestMethod]
        public void GetEuclideanGCD_ZeroAsFiveParams_ZeroResult()
        {
            var zeroResult = 0;

            int gcdResult = GCD.GetEuclideanGCD(0, 0, 0, 0, 0);

            Assert.AreEqual(gcdResult, zeroResult);
        }
        #endregion


        [TestMethod]
        public void GetEuclideanGCD_ZeroAs1stParamIntAs2ndParam_ResultEqualsToAbsIntParam()
        {
            var zeroParam = 0;

            // Check through all the System.Int32 values range.
            // Preventing from computing the absolute value of 
            // System.Int32.MinValue.
            for (int intParam = int.MinValue + 1; intParam < int.MaxValue; intParam++)
            {
                // Skip 0 value.
                if (intParam == 0)
                    continue;

                int gcdResult = GCD.GetEuclideanGCD(zeroParam, intParam);

                // Check if the answer is incorrect.
                if (!gcdResult.Equals(Math.Abs(intParam)))
                {
                    throw new InvalidOperationException("Result of GetEuclideanGCD " +
                        "does not equal to abs of the int parameter.");
                }
            }

            // If there is no mistakes the test will be passed.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetEuclideanGCD_IntAs1stParamZeroAs2ndParam_ResultEqualsToAbsIntParam()
        {
            var zeroParam = 0;

            // Check through all the System.Int32 values range.
            // Preventing from computing the absolute value of 
            // System.Int32.MinValue.
            for (int intParam = int.MinValue + 1; intParam < int.MaxValue; intParam++)
            {
                // Skip 0 value.
                if (intParam == 0)
                    continue;

                int gcdResult = GCD.GetEuclideanGCD(intParam, zeroParam);

                // Check if the answer is incorrect.
                if (!gcdResult.Equals(Math.Abs(intParam)))
                {
                    throw new InvalidOperationException("Result of GetEuclideanGCD " +
                        "does not equal to abs of the int parameter.");
                }
            }

            // If there is no mistakes the test will be passed.
            Assert.IsTrue(true);
        }


        #region Random values cases
        [TestMethod]
        public void GetEuclideanGCD_IntParams_CorrectGCD()
        {
            var attemptsToBreakTheCode = 10000;
            var rand = new Random();

            // Assume that tested method will produce correct outputs.
            bool isResultCorrect = true;

            for (int attempt = 0; attempt < attemptsToBreakTheCode; attempt++)
            {
                // Create a var for storing tmp result.
                int gcdCorrect;

                int a = rand.Next();
                int b = rand.Next();

                // Compute GCD using explicit Euclidean algorithm.
                if (a == 0)
                    gcdCorrect = b;
                else if (b == 0)
                    gcdCorrect = a;
                else
                {
                    while (a != b)
                    {
                        _ = (a > b) ? (a -= b) :
                            (b -= a);
                    }
                    // Get a correct GCD value.
                    gcdCorrect = a;
                }
                // Get GCD from the method.
                int gcdResult = GCD.GetEuclideanGCD(a, b);

                // Check their equality.
                if (!gcdResult.Equals(gcdCorrect))
                {
                    isResultCorrect = false;
                    break;
                }
            }

            Assert.IsTrue(isResultCorrect);
        }

        [TestMethod]
        public void GetSteinGCD_IntParams_CorrectGCD()
        {
            var attemptsToBreakTheCode = 10000;
            var rand = new Random();

            // Assume that tested method will produce correct outputs.
            bool isResultCorrect = true;

            for (int attempt = 0; attempt < attemptsToBreakTheCode; attempt++)
            {
                // Create a var for storing tmp result.
                int gcdCorrect;

                int a = rand.Next();
                int b = rand.Next();

                // Compute GCD using explicit Euclidean algorithm.
                if (a == 0)
                    gcdCorrect = b;
                else if (b == 0)
                    gcdCorrect = a;
                else
                {
                    while (a != b)
                    {
                        _ = (a > b) ? (a -= b) :
                            (b -= a);
                    }
                    // Get a correct GCD value.
                    gcdCorrect = a;
                }
                // Get GCD from the method.
                int gcdResult = GCD.GetSteinGCD(a, b, execTime: out _);

                // Check their equality.
                if (!gcdResult.Equals(gcdCorrect))
                {
                    isResultCorrect = false;
                    break;
                }
            }

            Assert.IsTrue(isResultCorrect);
        }
        #endregion
    }
}

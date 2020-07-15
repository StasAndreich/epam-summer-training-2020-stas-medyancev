using MathTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests_MathTypes
{
    [TestClass]
    public class UT_Vector3
    {
        #region Static props test
        [TestMethod]
        public void PropOne_Get_UnitVector3()
        {
            // Create a unit vector.
            var unit = new Vector3(1, 1, 1);

            // Get a unit vector from property One.
            var oneProp = Vector3.One;

            if (!unit.Equals(oneProp))
                throw new ApplicationException("Unit vector coords are incorrect.");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PropZero_Get_ZeroVector3()
        {
            // Create a zero vector.
            var unit = new Vector3(0, 0, 0);

            // Get a zero vector from property Zero.
            var zeroProp = Vector3.Zero;

            if (!unit.Equals(zeroProp))
                throw new ApplicationException("Zero vector coords are incorrect.");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PropNegativeInfinity_Get_NegativeInfinityVector3()
        {
            // Create a negative infinity vector.
            var unit = new Vector3(double.NegativeInfinity,
                                   double.NegativeInfinity,
                                   double.NegativeInfinity);

            // Get a negative infinity vector from property NegativeInfinity.
            var negativeInfinityProp = Vector3.NegativeInfinity;

            if (!unit.Equals(negativeInfinityProp))
                throw new ApplicationException("Negative infinity vector coords are incorrect.");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PropPositiveInfinity_Get_PositiveInfinityVector3()
        {
            // Create a positive infinity vector.
            var unit = new Vector3(double.PositiveInfinity,
                                   double.PositiveInfinity,
                                   double.PositiveInfinity);

            // Get a positive infinity vector from property PositiveInfinity.
            var positiveInfinityProp = Vector3.PositiveInfinity;

            if (!unit.Equals(positiveInfinityProp))
                throw new ApplicationException("Positive infinity vector coords are incorrect.");

            Assert.IsTrue(true);
        }
        #endregion


        [TestMethod]
        public void PropMagnitude_Get_MagnitudeOfVector3()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values.
                var x = rand.NextDouble() * rand.Next(0, 10000);
                var y = rand.NextDouble() * rand.Next(0, 10000);
                var z = rand.NextDouble() * rand.Next(0, 10000);

                // Compute magnitude of xyz rand values.
                var xyzMagnitude = Math.Sqrt(x * x + y * y + z * z);

                // Create a rand vector from xyz.
                var vector = new Vector3(x, y, z);

                if (!xyzMagnitude.Equals(vector.Magnitude))
                    throw new ApplicationException("Magnitude of a vector is incorrect.");
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PropSqrMagnitude_Get_SquaredMagnitudeOfVector3()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values.
                var x = rand.NextDouble() * rand.Next(0, 10000);
                var y = rand.NextDouble() * rand.Next(0, 10000);
                var z = rand.NextDouble() * rand.Next(0, 10000);

                // Compute squared magnitude of xyz rand values.
                var xyzSqrMagnitude = x * x + y * y + z * z;

                // Create a rand vector from xyz.
                var vector = new Vector3(x, y, z);

                if (!xyzSqrMagnitude.Equals(vector.SqrMagnitude))
                    throw new ApplicationException("Squared magnitude of a vector is incorrect.");
            }

            Assert.IsTrue(true);
        }
    }
}

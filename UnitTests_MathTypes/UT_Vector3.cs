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

        [TestMethod]
        public void Dot_TwoVectors3_DoubleScalar()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for 1st vector.
                var x1 = rand.NextDouble() * rand.Next(0, 10000);
                var y1 = rand.NextDouble() * rand.Next(0, 10000);
                var z1 = rand.NextDouble() * rand.Next(0, 10000);

                // Randomise xyz-coords values for 2nd vector.
                var x2 = rand.NextDouble() * rand.Next(0, 10000);
                var y2 = rand.NextDouble() * rand.Next(0, 10000);
                var z2 = rand.NextDouble() * rand.Next(0, 10000);

                // Create the 1st rand vector from xyz.
                var vector1 = new Vector3(x1, y1, z1);
                // Create the 2nd rand vector from xyz.
                var vector2 = new Vector3(x2, y2, z2);

                // Compute vector1 and vector2 dot product.
                var dotProduct = (vector1.X * vector2.X)
                                  + (vector1.Y * vector2.Y)
                                  + (vector1.Z * vector2.Z);

                if (!dotProduct.Equals(Vector3.Dot(vector1, vector2)))
                    throw new ApplicationException("Dot product of two vectors3 is incorrect.");
            }

            Assert.IsTrue(true);
        }

        #region Operators overloading
        [TestMethod]
        public void AdditionOperatorOverloading_TwoVectors3_SumVector3()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for 1st vector.
                var x1 = rand.NextDouble() * rand.Next(0, 10000);
                var y1 = rand.NextDouble() * rand.Next(0, 10000);
                var z1 = rand.NextDouble() * rand.Next(0, 10000);

                // Randomise xyz-coords values for 2nd vector.
                var x2 = rand.NextDouble() * rand.Next(0, 10000);
                var y2 = rand.NextDouble() * rand.Next(0, 10000);
                var z2 = rand.NextDouble() * rand.Next(0, 10000);

                // Create the 1st rand vector from xyz.
                var vector1 = new Vector3(x1, y1, z1);
                // Create the 2nd rand vector from xyz.
                var vector2 = new Vector3(x2, y2, z2);

                // Compute vector1 and vector2 sum.
                var sumVector = new Vector3(vector1.X + vector2.X,
                                            vector1.Y + vector2.Y,
                                            vector1.Z + vector2.Z);

                if (!sumVector.Equals(vector1 + vector2))
                    throw new ApplicationException("Sum of two vectors3 is incorrect.");
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SubtractionOperatorOverloading_TwoVectors3_DifferenceVector3()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for 1st vector.
                var x1 = rand.NextDouble() * rand.Next(0, 10000);
                var y1 = rand.NextDouble() * rand.Next(0, 10000);
                var z1 = rand.NextDouble() * rand.Next(0, 10000);

                // Randomise xyz-coords values for 2nd vector.
                var x2 = rand.NextDouble() * rand.Next(0, 10000);
                var y2 = rand.NextDouble() * rand.Next(0, 10000);
                var z2 = rand.NextDouble() * rand.Next(0, 10000);

                // Create the 1st rand vector from xyz.
                var vector1 = new Vector3(x1, y1, z1);
                // Create the 2nd rand vector from xyz.
                var vector2 = new Vector3(x2, y2, z2);

                // Compute vector1 and vector2 difference.
                var diffVector = new Vector3(vector1.X - vector2.X,
                                             vector1.Y - vector2.Y,
                                             vector1.Z - vector2.Z);

                if (!diffVector.Equals(vector1 - vector2))
                    throw new ApplicationException("Difference of two vectors3 is incorrect.");
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MultiplicationOperatorOverloading_Vector3AndDoubleAndViceVersa_Vector3()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for a vector.
                var x = rand.NextDouble() * rand.Next(0, 10000);
                var y = rand.NextDouble() * rand.Next(0, 10000);
                var z = rand.NextDouble() * rand.Next(0, 10000);

                // Create a rand vector from xyz.
                var vector = new Vector3(x, y, z);
                // Create a rand double value.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);

                // Compute vector and number product vector.
                var productVector = new Vector3(vector.X * doubleValue,
                                                vector.Y * doubleValue,
                                                vector.Z * doubleValue);

                if (!(productVector.Equals(vector * doubleValue))
                    && (productVector.Equals(doubleValue * vector)))
                    throw new ApplicationException("Product of a vectors3 and double value is incorrect.");
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DivisionOperatorOverloading_Vector3AndDouble_Vector3()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for vectors.
                var x = rand.NextDouble() * rand.Next(0, 10000);
                var y = rand.NextDouble() * rand.Next(0, 10000);
                var z = rand.NextDouble() * rand.Next(0, 10000);

                // Create a rand vector from xyz.
                var vector = new Vector3(x, y, z);
                // Create a rand double value.
                var doubleValue = rand.NextDouble() * rand.Next(1, 10000);

                // Compute vector and number quotient vector.
                var quotientVector = new Vector3(vector.X / doubleValue,
                                                 vector.Y / doubleValue,
                                                 vector.Z / doubleValue);

                if (!quotientVector.Equals(vector / doubleValue))
                    throw new ApplicationException("Quotient of a vectors3 and double value is incorrect.");
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EqualityOperatorOverloading_TwoEqualVectors3_BooleanTrue()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for vectors.
                var x = rand.NextDouble() * rand.Next(0, 10000);
                var y = rand.NextDouble() * rand.Next(0, 10000);
                var z = rand.NextDouble() * rand.Next(0, 10000);

                // Create rand equal vectors from xyz.
                var vector1 = new Vector3(x, y, z);
                var vector2 = new Vector3(x, y, z);

                if (!vector1.Equals(vector2))
                    throw new ApplicationException("Equality of two equal vectors3 is incorrect.");
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InequalityOperatorOverloading_TwoDifferentVectors3_BooleanTrue()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Randomise xyz-coords values for 1st vector.
                var x1 = rand.NextDouble() * rand.Next(0, 10000);
                var y1 = rand.NextDouble() * rand.Next(0, 10000);
                var z1 = rand.NextDouble() * rand.Next(0, 10000);

                // Randomise xyz-coords values for 2nd vector.
                var x2 = rand.NextDouble() * rand.Next(0, 10000);
                var y2 = rand.NextDouble() * rand.Next(0, 10000);
                var z2 = rand.NextDouble() * rand.Next(0, 10000);

                // Create the 1st rand vector from xyz.
                var vector1 = new Vector3(x1, y1, z1);
                // Create the 2nd rand vector from xyz.
                var vector2 = new Vector3(x2, y2, z2);

                if (vector1.Equals(vector2))
                    throw new ApplicationException("Inequality of two equal vectors3 is incorrect.");
            }

            Assert.IsTrue(true);
        }
        #endregion
    }
}

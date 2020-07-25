using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace UnitTests_BoxOfShapes
{
    [TestClass]
    public class UT_Shapes
    {
        private const double tolerance = 0.00001;

        #region GetPerimeter() tests
        [TestMethod]
        public void Circle_GetPerimeter_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand circle.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle = new Circle(doubleValue);

                // Compare results.
                if (!(Math.Abs(circle.GetPerimeter()
                    - (2 * Math.PI * doubleValue)) < tolerance))
                    throw new ApplicationException("Perimeter value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Triangle_GetPerimeter_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand triangle.
                var side = rand.NextDouble() * rand.Next(0, 10000);
                var triangle = new Triangle(side);

                // Compare results.
                if (!(Math.Abs(triangle.GetPerimeter()
                    - (3 * side)) < tolerance))
                    throw new ApplicationException("Perimeter value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Rectangle_GetPerimeter_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand rectangle.
                var side1 = rand.NextDouble() * rand.Next(0, 10000);
                var side2 = rand.NextDouble() * rand.Next(0, 10000);
                var rectangle = new Rectangle(side1, side2);

                // Compare results.
                if (!(Math.Abs(rectangle.GetPerimeter()
                    - (2 * (side1 + side2))) < tolerance))
                    throw new ApplicationException("Perimeter value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion


        #region GetArea tests
        [TestMethod]
        public void Circle_GetArea_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand circle.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle = new Circle(doubleValue);

                var area = Math.PI * doubleValue * doubleValue;

                // Compare results.
                if (!(Math.Abs(circle.GetArea() - area) < tolerance))
                    throw new ApplicationException("Area value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Triangle_GetArea_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand triangle.
                var side = rand.NextDouble() * rand.Next(0, 10000);
                var triangle = new Triangle(side);

                var halfPerimeter = (3 * side) / 2;
                // Compare results.
                var area = Math.Sqrt(
                            (halfPerimeter / 2) *
                            (halfPerimeter - side) *
                            (halfPerimeter - side) *
                            (halfPerimeter - side));

                if (!(Math.Abs(triangle.GetArea() - area) < tolerance))
                    throw new ApplicationException("Area value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Rectangle_GetArea_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand rectangle.
                var side1 = rand.NextDouble() * rand.Next(0, 10000);
                var side2 = rand.NextDouble() * rand.Next(0, 10000);
                var rectangle = new Rectangle(side1, side2);

                var area = side1 * side2;

                // Compare results.
                if (!(Math.Abs(rectangle.GetArea() - area) < tolerance))
                    throw new ApplicationException("Area value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion
    }
}

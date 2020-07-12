using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace UnitTests_Shapes
{
    [TestClass]
    public class UT_Shapes
    {
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
                if (!circle.GetPerimeter()
                    .Equals(2 * Math.PI * doubleValue))
                    throw new ApplicationException("Perimeter value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void Triangle_GetPerimeter_CorrectResult()
        //{
        //    var attempts = 10000;
        //    var rand = new Random();

        //    for (int i = 0; i < attempts; i++)
        //    {
        //        // Create a rand triangle.
        //        var side1 = rand.NextDouble() * rand.Next(0, 10000);
        //        var side2 = rand.NextDouble() * rand.Next(0, 10000);
        //        var side3 = rand.NextDouble() * rand.Next(0, 10000);
        //        var triangle = new Triangle(side1, side2, side3);

        //        // Compare results.
        //        if (!triangle.GetPerimeter()
        //            .Equals(2 * Math.PI * doubleValue))
        //            throw new ApplicationException("Perimeter value is incorrect.");
        //    }

        //    // If no exceptions.
        //    Assert.IsTrue(true);
        //}

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
                if (!rectangle.GetPerimeter()
                    .Equals(side1 + side2 + side1 + side2))
                    throw new ApplicationException("Perimeter value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Square_GetPerimeter_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand triangle.
                var side = rand.NextDouble() * rand.Next(0, 10000);
                var square = new Square(side);

                // Compare results.
                if (!square.GetPerimeter()
                    .Equals(4 * side))
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

                // Compare results.
                if (!circle.GetArea()
                    .Equals(Math.PI * doubleValue * doubleValue))
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

                // Compare results.
                if (!rectangle.GetArea()
                    .Equals(side1 * side2))
                    throw new ApplicationException("Area value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Square_GetArea_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand triangle.
                var side = rand.NextDouble() * rand.Next(0, 10000);
                var square = new Square(side);

                // Compare results.
                if (!square.GetArea()
                    .Equals(side * side))
                    throw new ApplicationException("Area value is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion


        #region Equals tests
        [TestMethod]
        public void Circle_Equals_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create rand circles.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle1 = new Circle(doubleValue);
                var circle2 = new Circle(doubleValue);
                var circle3 = new Circle(doubleValue);

                // Reflectiveness check.
                if (!circle1.Equals(circle1))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Symmetry check.
                if (!circle1.Equals(circle2))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Symmetry check.
                if (!circle2.Equals(circle1))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Transitivity check.
                if (!(circle1.Equals(circle2)
                    && circle2.Equals(circle3))
                    && circle1.Equals(circle3))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Rectangle_Equals_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create rand rectangles.
                var doubleValue1 = rand.NextDouble() * rand.Next(0, 10000);
                var doubleValue2 = rand.NextDouble() * rand.Next(0, 10000);

                var rectangle1 = new Rectangle(doubleValue1, doubleValue2);
                var rectangle2 = new Rectangle(doubleValue1, doubleValue2);
                var rectangle3 = new Rectangle(doubleValue1, doubleValue2);

                // Reflectiveness check.
                if (!rectangle1.Equals(rectangle1))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Symmetry check.
                if (!rectangle1.Equals(rectangle2))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Symmetry check.
                if (!rectangle2.Equals(rectangle1))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Transitivity check.
                if (!(rectangle1.Equals(rectangle2)
                    && rectangle2.Equals(rectangle3))
                    && rectangle1.Equals(rectangle3))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Square_Equals_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create rand squares.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);

                var square1 = new Square(doubleValue);
                var square2 = new Square(doubleValue);
                var square3 = new Square(doubleValue);

                // Reflectiveness check.
                if (!square1.Equals(square1))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Symmetry check.
                if (!square1.Equals(square2))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Symmetry check.
                if (!square2.Equals(square1))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");

                // Transitivity check.
                if (!(square1.Equals(square2)
                    && square2.Equals(square3))
                    && square1.Equals(square3))
                    throw new ApplicationException("Equals check of two equal obj is incorrect.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion
    }
}

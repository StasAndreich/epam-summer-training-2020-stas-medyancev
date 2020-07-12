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
        public void Circle_GetPerimeter_CorectResult()
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
        //public void Triangle_GetPerimeter_CorectResult()
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
        public void Square_GetPerimeter_CorectResult()
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
        public void Circle_GetArea_CorectResult()
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
        public void Square_GetArea_CorectResult()
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
    }
}

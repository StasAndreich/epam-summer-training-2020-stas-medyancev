using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using Materials;

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


        #region GetArea() tests
        [TestMethod]
        public void Circle_GetArea_CorrectResult()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
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


        #region ChangeColor() tests
        [TestMethod]
        public void Circle_ChangeColor_ColorOfMaterialChanged()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle = new Circle(new Paper(), doubleValue);

                // Rand color.
                var randColor = (Color)rand.Next(0, 5);
                circle.ChangeColor(randColor);

                // Compare results.
                if (!circle.Material.Color.Equals(randColor))
                    throw new ApplicationException("Color is not correctly changed.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Triangle_ChangeColor_ColorOfMaterialChanged()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var triangle = new Triangle(new Paper(), doubleValue);

                // Rand color.
                var randColor = (Color)rand.Next(0, 5);
                triangle.ChangeColor(randColor);

                // Compare results.
                if (!triangle.Material.Color.Equals(randColor))
                    throw new ApplicationException("Color is not correctly changed.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Rectangle_ChangeColor_ColorOfMaterialChanged()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue1 = rand.NextDouble() * rand.Next(0, 10000);
                var doubleValue2 = rand.NextDouble() * rand.Next(0, 10000);
                var rectangle = new Rectangle(new Paper(), doubleValue1, doubleValue2);

                // Rand color.
                var randColor = (Color)rand.Next(0, 5);
                rectangle.ChangeColor(randColor);

                // Compare results.
                if (!rectangle.Material.Color.Equals(randColor))
                    throw new ApplicationException("Color is not correctly changed.");
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion


        #region Copy-ctors

        #region Circle ctor
        [TestMethod]
        public void CircleCtor_CutCircleFromCircle_AnotherCircle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle = new Circle(new Paper(), doubleValue);

                // Cut a shape from existing one.
                var clippedCircle = new Circle(circle, doubleValue / 2);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CircleCtor_CutCircleFromTriangle_AnotherCircle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var triangle = new Triangle(new Paper(), doubleValue);

                // Cut a shape from existing one.
                var clippedCircle = new Circle(triangle, doubleValue / 4);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CircleCtor_CutCircleFromRectangle_AnotherCircle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue1 = rand.NextDouble() * rand.Next(0, 10000);
                var doubleValue2 = rand.NextDouble() * rand.Next(0, 10000);
                var rectangle = new Rectangle(new Paper(), doubleValue1, doubleValue2);

                // Cut a shape from existing one.
                var clippedCircle = new Circle(rectangle,
                    Math.Min(doubleValue1, doubleValue2) / 2);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion

        #region Triangle ctor
        [TestMethod]
        public void TriangleCtor_CutTriangleFromCircle_AnotherTriangle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle = new Circle(new Paper(), doubleValue);

                // Cut a shape from existing one.
                var clippedTriangle = new Triangle(circle,
                    doubleValue / 2);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TriangleCtor_CutTriangleFromTriangle_AnotherTriangle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var triangle = new Triangle(new Paper(), doubleValue);

                // Cut a shape from existing one.
                var clippedTriangle = new Triangle(triangle,
                    doubleValue / 2);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TriangleCtor_CutTriangleFromRectangle_AnotherTriangle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue1 = rand.NextDouble() * rand.Next(0, 10000);
                var doubleValue2 = rand.NextDouble() * rand.Next(0, 10000);
                var rectangle = new Rectangle(new Paper(), doubleValue1, doubleValue2);

                // Cut a shape from existing one.
                var clippedTriangle = new Triangle(rectangle,
                    Math.Min(doubleValue1, doubleValue2) / 2);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion

        #region Rectangle ctor
        [TestMethod]
        public void RectangleCtor_CutRectangleFromCircle_AnotherRectangle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circle = new Circle(new Paper(), doubleValue);

                // Cut a shape from existing one.
                var clippedRectangle = new Rectangle(circle,
                    doubleValue / 4, doubleValue / 4);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RectangleCtor_CutRectangleFromTriangle_AnotherRectangle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var triangle = new Triangle(new Paper(), doubleValue);

                // Cut a shape from existing one.
                var clippedRectangle = new Rectangle(triangle,
                    doubleValue / 4, doubleValue / 4);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RectangleCtor_CutRectangleFromRectangle_AnotherRectangle()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a rand shape.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var rectangle = new Rectangle(new Paper(), doubleValue, doubleValue);

                // Cut a shape from existing one.
                var clippedRectangle = new Rectangle(rectangle,
                    doubleValue / 2, doubleValue / 2);
            }

            // If no exceptions.
            Assert.IsTrue(true);
        }
        #endregion

        #endregion
    }
}

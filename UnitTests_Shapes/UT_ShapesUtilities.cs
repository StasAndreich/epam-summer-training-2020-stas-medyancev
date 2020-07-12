using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using ShapesUtilities;

namespace UnitTests_Shapes
{
    [TestClass]
    public class UT_ShapesUtilities
    {
        [TestMethod]
        public void LoadShapeFromString_CircleString_CircleShapeObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create an input string.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var circleString = "Circle " + doubleValue;

                try
                {
                    // Load a shape from that string.
                    var loadedCircleFromString =
                        ShapeLoader.LoadShapeFromString(shapeCreator: new CircleCreator(),
                                                        input: circleString);
                }
                catch (Exception)
                {
                    Assert.IsTrue(false);
                    throw;
                }
            }

            Assert.IsTrue(true);
        }


        #region Strings with sides
        [TestMethod]
        public void LoadShapeFromString_TriangleSidesString_TriangleShapeObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create an input string.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var triangleString = $"Triangle {doubleValue} {doubleValue} {doubleValue}";

                try
                {
                    // Load a shape from that string.
                    var loadedRectangleFromString =
                        ShapeLoader.LoadShapeFromString(shapeCreator: new TriangleCreator(),
                                                        input: triangleString);
                }
                catch (Exception)
                {
                    Assert.IsTrue(false);
                    throw;
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoadShapeFromString_RectangleSidesString_RectangleShapeObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create an input string.
                var doubleValue1 = rand.NextDouble() * rand.Next(0, 10000);
                var doubleValue2 = rand.NextDouble() * rand.Next(0, 10000);
                var rectangleString = "Rectangle " + doubleValue1 + " " + doubleValue2;

                try
                {
                    // Load a shape from that string.
                    var loadedRectangleFromString =
                        ShapeLoader.LoadShapeFromString(shapeCreator: new RectangleCreator(),
                                                        input: rectangleString);
                }
                catch (Exception)
                {
                    Assert.IsTrue(false);
                    throw;
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoadShapeFromString_SquareSidesString_SquareShapeObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create an input string.
                var doubleValue = rand.NextDouble() * rand.Next(0, 10000);
                var squareString = "Square " + doubleValue;

                try
                {
                    // Load a shape from that string.
                    var loadedRectangleFromString =
                        ShapeLoader.LoadShapeFromString(shapeCreator: new SquareCreator(),
                                                        input: squareString);
                }
                catch (Exception)
                {
                    Assert.IsTrue(false);
                    throw;
                }
            }

            Assert.IsTrue(true);
        }
        #endregion


        [TestMethod]
        public void LoadShapesArrayFromTextFile_TextFile_ShapeObjectsArray()
        {
            // Expected figures array.
            var shapes = new Shape[]
            {
                new Circle(23.9),
                new Rectangle(34, 54),
                new Triangle(12, 13, 5),
                new Square(6),
                new Rectangle(
                    new Point(-5, -2.5),
                    new Point(-5, 2.5),
                    new Point(5, 2.5),
                    new Point(5, -2.5)),
                new Square(
                    new Point(-3, -3),
                    new Point(-3, 3),
                    new Point(3, 3),
                    new Point(3, -3)),
                new Triangle(
                    new Point(-6, -2.5),
                    new Point(-6, 2.5),
                    new Point(6, -2.5))
            };

            // Output shapes array.
            var outputShapes = ShapeLoader.LoadShapesArrayFromTextFile("ShapesFile.txt");

            // Compare two array elements.
            for (int i = 0; i < outputShapes.Length; i++)
            {
                if (!outputShapes[i].Equals(shapes[i]))
                    throw new ApplicationException("Loading shapes from file is incorrect.");
            }

            Assert.IsTrue(true);
        }
    }
}

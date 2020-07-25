using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using Materials;
using Containers;

namespace UnitTests_BoxOfShapes
{
    [TestClass]
    public class UT_ShapeBox
    {
        [TestMethod]
        public void SaveAllShapesToXmlFileViaXmlWriter_OutFilePath_XmlFile()
        {
            var rand = new Random();

            // Create a shapeBox with some shapes.
            var shapeBox = new ShapeBox(3);
            shapeBox.Add(new Circle(new Paper(), rand.Next()));
            shapeBox.Add(new Triangle(new Paper(), rand.Next()));
            shapeBox.Add(new Rectangle(new Paper(), rand.Next(), rand.Next()));

            // Parse all shapes to xml-file.
            shapeBox.SaveAllShapesToXmlFileViaXmlWriter("XmlWriterShapes.xml");

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SaveAllShapesToXmlFileViaStreamWriter_OutFilePath_XmlFile()
        {
            var rand = new Random();

            // Create a shapeBox with some shapes.
            var shapeBox = new ShapeBox(3);
            shapeBox.Add(new Circle(new Paper(), rand.Next()));
            shapeBox.Add(new Triangle(new Paper(), rand.Next()));
            shapeBox.Add(new Rectangle(new Paper(), rand.Next(), rand.Next()));

            // Parse all shapes to xml-file.
            shapeBox.SaveAllShapesToXmlFileViaStreamWriter("StreamWriterShapes.xml");

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoadAllShapesFromXmlViaXmlReader_FilePath_ShapesInShapeBox()
        {
            // Create a shapeBox with shapes.
            var shapeBox = new ShapeBox(3);
            shapeBox.Add(new Circle(new Paper(), 15));
            shapeBox.Add(new Rectangle(new Film(), 25, 10));
            shapeBox.Add(new Triangle(new Paper(), 7));

            // Create an empty shapeBox.
            var parsedshapeBox = new ShapeBox(3);

            // Parse all shapes from xml-file to a box.
            parsedshapeBox.LoadAllShapesFromXmlViaXmlReader("ShapesTestExample.xml");

            if (!shapeBox.Equals(parsedshapeBox))
                throw new ApplicationException("XML parsing is incorrect.");

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExtractAt_Index_ShapeBoxWithoutIndexedShape()
        {
            // Create a shapeBox with shapes.
            var shapeBox = new ShapeBox(3);
            // Index 0.
            shapeBox.Add(new Circle(new Paper(), 15));
            // Index 1.
            shapeBox.Add(new Rectangle(new Film(), 25, 10));
            // Index 2.
            shapeBox.Add(new Triangle(new Paper(), 7));

            shapeBox.ExtractAt(1);

            if (shapeBox[1] != null)
                throw new ApplicationException("Exctraction failed.");

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExtractByType_Rectangle_ShapeBoxWithoutRectangles()
        {
            // Create a shapeBox with shapes.
            var shapeBox = new ShapeBox(3);
            // Index 0.
            shapeBox.Add(new Circle(new Paper(), 15));
            // Index 1.
            shapeBox.Add(new Rectangle(new Film(), 25, 10));
            // Index 2.
            shapeBox.Add(new Triangle(new Paper(), 7));

            shapeBox.ExtractByType<Rectangle>();

            if (shapeBox[1] != null)
                throw new ApplicationException("Exctraction failed.");

            // If no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExtractByMaterial_FilmMaterial_ShapeBoxWithoutFilmShapes()
        {
            // Create a shapeBox with shapes.
            var shapeBox = new ShapeBox(3);
            // Index 0.
            shapeBox.Add(new Circle(new Paper(), 15));
            // Index 1.
            shapeBox.Add(new Rectangle(new Film(), 25, 10));
            // Index 2.
            shapeBox.Add(new Triangle(new Paper(), 7));

            shapeBox.ExtractByMaterial<Film>();

            if (shapeBox[1] != null)
                throw new ApplicationException("Exctraction failed.");

            // If no exceptions.
            Assert.IsTrue(true);
        }
    }
}

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
    }
}

using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Shapes
{
    public class ShapeXmlParser
    {
        #region Read XML
        public static IList<IShape> GetShapesListFromXmlFileSax(string filePath)
        {
            var shapes = new List<IShape>();

            using (var xReader = XmlReader.Create(filePath))
            {
                var currentElement = "";
                var currentAttribute = "";

                while (xReader.Read())
                {
                    switch (xReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            currentElement = xReader.Name;
                            break;

                        case XmlNodeType.Attribute:
                            currentAttribute = xReader.Name;
                            break;

                        case XmlNodeType.Text:
                            switch (currentElement)
                            {
                                case "Material":

                                    break;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (xReader.Name.Equals("Shape"))
                                shapes.Add(new );
                            break;

                    }
                }
            }

            return shapes;
        } 
        #endregion


        #region Write XML
        public static void ParseToXmlViaDom(IEnumerable<IShape> shapes, string outputFilePath)
        {

        }

        /// <summary>
        /// Parses IShape objects to an XML-file
        /// via SAX parsing with XmlWriter class.
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="outputFilePath"></param>
        public static void ParseToXmlViaSax(IEnumerable<IShape> shapes, string outputFilePath)
        {
            // Using XmlWriter.
            XmlWriter xWriter = null;
            var settings = new XmlWriterSettings()
            { Indent = true, IndentChars = "\t" };

            try
            {
                using (xWriter = XmlWriter.Create(outputFilePath, settings))
                {
                    xWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                    // General <Shapes> tag.
                    xWriter.WriteStartElement("Shapes");

                    foreach (var shape in shapes)
                    {
                        // <Shape Name="ShapeName"> tag.
                        xWriter.WriteStartElement("Shape");
                        xWriter.WriteAttributeString("Name", shape.Name);

                        // <Material Color="ColorEx">MaterialEx</Material> tags.
                        xWriter.WriteStartElement("Material");
                        xWriter.WriteAttributeString("Color", shape.Material.Color.ToString());
                        xWriter.WriteString(shape.Material.ToString());
                        xWriter.WriteEndElement();

                        // Additional shape params.
                        switch (shape.Name)
                        {
                            // Define a shape type.
                            case "Circle":
                                // Ex.: <Radius>Double-value</Radius>.
                                xWriter.WriteElementString("Radius", ((Circle)shape).Radius.ToString());
                                break;
                            case "Rectangle":
                                xWriter.WriteElementString("Height", ((Rectangle)shape).Height.ToString());
                                xWriter.WriteElementString("Width", ((Rectangle)shape).Width.ToString());
                                break;
                            case "Triangle":
                                xWriter.WriteElementString("Side", ((Triangle)shape).Side.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                    xWriter.WriteEndElement();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (xWriter != null)
                    xWriter.Close();
            }
        }

        /// <summary>
        /// Parses IShape objects to an XML-file
        /// via SAX parsing with XmlWriter class
        /// that is using a stream of StreamWriter class.
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="outputStream"></param>
        public static void ParseToXmlViaSax(IEnumerable<IShape> shapes, StreamWriter outputStream)
        {
            // Using XmlWriter.
            XmlWriter xWriter = null;
            var settings = new XmlWriterSettings()
            { Indent = true, IndentChars = "\t" };

            try
            {
                // Pass StreamWriter instance to XmlWriter.
                using (xWriter = XmlWriter.Create(outputStream, settings))
                {
                    xWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                    // General <Shapes> tag.
                    xWriter.WriteStartElement("Shapes");

                    foreach (var shape in shapes)
                    {
                        // <Shape Name="ShapeName"> tag.
                        xWriter.WriteStartElement("Shape");
                        xWriter.WriteAttributeString("Name", shape.Name);

                        // <Material Color="ColorEx">MaterialEx</Material> tags.
                        xWriter.WriteStartElement("Material");
                        xWriter.WriteAttributeString("Color", shape.Material.Color.ToString());
                        xWriter.WriteString(shape.Material.ToString());
                        xWriter.WriteEndElement();

                        // Additional shape params.
                        switch (shape.Name)
                        {
                            // Define a shape type.
                            case "Circle":
                                // Ex.: <Radius>Double-value</Radius>.
                                xWriter.WriteElementString("Radius", ((Circle)shape).Radius.ToString());
                                break;
                            case "Rectangle":
                                xWriter.WriteElementString("Height", ((Rectangle)shape).Height.ToString());
                                xWriter.WriteElementString("Width", ((Rectangle)shape).Width.ToString());
                                break;
                            case "Triangle":
                                xWriter.WriteElementString("Side", ((Triangle)shape).Side.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                    xWriter.WriteEndElement();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (xWriter != null)
                    xWriter.Close();
            }
        } 
        #endregion
    }
}

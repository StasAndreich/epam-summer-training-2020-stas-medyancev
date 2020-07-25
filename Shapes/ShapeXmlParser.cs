using Materials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Shapes
{
    /// <summary>
    /// Contains static methods for IShape objects
    /// parsing from/to XML-files.
    /// </summary>
    public static class ShapeXmlParser
    {
        #region Read XML
        /// <summary>
        /// Parses IShape objects from an
        /// XML-file via XmlReader class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IList<IShape> XmlReaderParseFromXmlFile(string filePath)
        {
            var shapes = new List<IShape>();

            using (var xReader = XmlReader.Create(filePath))
            {
                // IShape elements tmp holders.
                var shapeName = "";
                var material = "";
                double radius = 0;
                double height = 0;
                double width = 0;
                double side = 0;

                // XML parts tmp name holders.
                var currentElement = "";

                while (xReader.Read())
                {
                    switch (xReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            currentElement = xReader.Name;
                            if (xReader.GetAttribute("Name") != null)
                                shapeName = xReader.GetAttribute("Name");
                            break;

                        case XmlNodeType.Text:
                            switch (currentElement)
                            {
                                case "Material":
                                    material = xReader.Value;
                                    break;
                                case "Radius":
                                    if (!double.TryParse(xReader.Value, out radius))
                                        throw new ApplicationException("Radius must be a double value.");
                                    break;
                                case "Height":
                                    if (!double.TryParse(xReader.Value, out height))
                                        throw new ApplicationException("Height must be a double value.");
                                    break;
                                case "Width":
                                    if (!double.TryParse(xReader.Value, out width))
                                        throw new ApplicationException("Width must be a double value.");
                                    break;
                                case "Side":
                                    if (!double.TryParse(xReader.Value, out side))
                                        throw new ApplicationException("Side must be a double value.");
                                    break;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (xReader.Name == "Shape")
                            {
                                switch (shapeName)
                                {
                                    case "Circle":
                                        if (material == "Paper")
                                            shapes.Add(new Circle(new Paper(), radius));
                                        else if (material == "Film")
                                            shapes.Add(new Circle(new Film(), radius));
                                        break;
                                    case "Rectangle":
                                        if (material == "Paper")
                                            shapes.Add(new Rectangle(new Paper(), height, width));
                                        else if (material == "Film")
                                            shapes.Add(new Rectangle(new Film(), height, width));
                                        break;
                                    case "Triangle":
                                        if (material == "Paper")
                                            shapes.Add(new Triangle(new Paper(), side));
                                        else if (material == "Film")
                                            shapes.Add(new Triangle(new Film(), side));
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
            return shapes;
        }

        /// <summary>
        /// Parses IShape objects from an
        /// XML-file with XmlWriter class
        /// that is using a stream of StreamReader class.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static IList<IShape> CombinedParseFromXmlFile(StreamReader stream)
        {
            var shapes = new List<IShape>();

            using (var xReader = XmlReader.Create(stream))
            {
                // IShape elements tmp holders.
                var shapeName = "";
                var material = "";
                var color = "";
                double radius = 0;
                double height = 0;
                double width = 0;
                double side = 0;

                // XML parts tmp name holders.
                var currentElement = "";

                while (xReader.Read())
                {
                    switch (xReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            currentElement = xReader.Name;
                            break;

                        case XmlNodeType.Attribute:
                            switch (xReader.Name)
                            {
                                case "Name":
                                    shapeName = xReader.Value;
                                    break;
                                case "Color":
                                    color = xReader.Value;
                                    break;
                            }
                            break;

                        case XmlNodeType.Text:
                            switch (currentElement)
                            {
                                case "Material":
                                    material = xReader.Value;
                                    break;
                                case "Radius":
                                    if (!double.TryParse(xReader.Value, out radius))
                                        throw new ApplicationException("Radius must be a double value.");
                                    break;
                                case "Height":
                                    if (!double.TryParse(xReader.Value, out height))
                                        throw new ApplicationException("Height must be a double value.");
                                    break;
                                case "Width":
                                    if (!double.TryParse(xReader.Value, out width))
                                        throw new ApplicationException("Width must be a double value.");
                                    break;
                                case "Side":
                                    if (!double.TryParse(xReader.Value, out side))
                                        throw new ApplicationException("Side must be a double value.");
                                    break;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (xReader.Name == "Shape")
                            {
                                switch (shapeName)
                                {
                                    case "Circle":
                                        if (material == "Paper")
                                            shapes.Add(new Circle(new Paper(), radius));
                                        else if (material == "Film")
                                            shapes.Add(new Circle(new Film(), radius));
                                        break;
                                    case "Rectangle":
                                        if (material == "Paper")
                                            shapes.Add(new Rectangle(new Paper(), height, width));
                                        else if (material == "Film")
                                            shapes.Add(new Rectangle(new Film(), height, width));
                                        break;
                                    case "Triangle":
                                        if (material == "Paper")
                                            shapes.Add(new Triangle(new Paper(), side));
                                        else if (material == "Film")
                                            shapes.Add(new Triangle(new Film(), side));
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
            return shapes;
        }
        #endregion


        #region Write XML
        /// <summary>
        /// Parses IShape objects to an XML-file
        /// via DOM parsing using StreamWriter.
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="outputFilePath"></param>
        public static void StreamWriterParseToXmlFile(IEnumerable<IShape> shapes, string outputFilePath)
        {
            // Create an empty output string.
            var output = new StringBuilder();

            // Append XML data to that string.
            //
            // Append a processing instruction.
            output.Append("<?xml version='1.0' encoding='UTF-8'?>\n");
            // Main tag.
            output.Append("<Shapes>\n");

            // Append data.
            foreach (var shape in shapes)
            {
                // Start Shape tag.
                output.Append($"\t<Shape Name=\"{shape.Name}\">\n");
                output.Append($"\t\t<Material Color=\"{shape.Material.Color}\">{shape.Material}</Material>\n");

                // Additional data.
                switch (shape.Name)
                {
                    // Check a shape type.
                    case "Circle":
                        output.Append($"\t\t<Radius>{((Circle)shape).Radius}</Radius>\n");
                        break;
                    case "Rectangle":
                        output.Append($"\t\t<Height>{((Rectangle)shape).Height}</Height>\n");
                        output.Append($"\t\t<Width>{((Rectangle)shape).Width}</Width>\n");
                        break;
                    case "Triangle":
                        output.Append($"\t\t<Side>{((Triangle)shape).Side}</Side>\n");
                        break;
                    default:
                        break;
                }

                // Close Shape tag.
                output.Append("\t</Shape>\n");
            }

            // Close main tag.
            output.Append("</Shapes>");

            // Pass a created string to an XML file.
            using (var strWriter = new StreamWriter(outputFilePath))
            {
                try
                {
                    strWriter.Write(output.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    strWriter.Close();
                }
            }
        }

        /// <summary>
        /// Parses IShape objects to an XML-file
        /// via SAX parsing with XmlWriter class.
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="outputFilePath"></param>
        public static void XmlWriterParseToXmlFile(IEnumerable<IShape> shapes, string outputFilePath)
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
                            // Check a shape type.
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
                        // Close Shape tag.
                        xWriter.WriteEndElement();
                    }
                    // Close Shapes tag.
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
        public static void CombinedParseToXmlFile(IEnumerable<IShape> shapes, StreamWriter outputStream)
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
                            // Check a shape type.
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
                        // Close Shape tag.
                        xWriter.WriteEndElement();
                    }
                    // Close Shapes tag.
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

        /// <summary>
        /// Parses IShape objects from an
        /// XML-file via XmlReader class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IList<IShape> StreamReaderParseFromXmlFile(string filePath)
        {
            //var shapes = new List<IShape>();

            //using (var stream = new StreamReader(filePath))
            //{
            //    var line = stream.ReadLine();

            //    var shapeRegex = new Regex("");
            //    var materialRegex = new Regex("");
            //}

            throw new NotImplementedException("Are you kidding me? Parsing XML with a regex? " +
                "What's the idea of using StreamReader without any wrappers here?");
        }
    }
}

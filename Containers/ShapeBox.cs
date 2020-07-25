using System;
using System.Collections.Generic;
using Materials;
using Shapes;

namespace Containers
{
    /// <summary>
    /// Container for storing IShape objects.
    /// </summary>
    public sealed class ShapeBox
    {
        private const double tolerance = 0.00001;

        private IShape[] shapes;

        /// <summary>
        /// Default ctor that sets
        /// a container capacity.
        /// </summary>
        /// <param name="capacity">
        /// Amount of IShape obj. (default: 20).
        /// </param>
        public ShapeBox(int capacity = 20)
        {
            this.shapes = new IShape[capacity];
        }

        /// <summary>
        /// Returns max container capacity.
        /// </summary>
        public int Capacity { get => shapes.Length; }
        
        /// <summary>
        /// Returns the count of IShape obj
        /// in a container.
        /// </summary>
        public int Count
        {
            get
            {
                var count = 0;
                foreach (var shape in shapes)
                    if (shape != null)
                        count++;

                return count;
            }
        }

        /// <summary>
        /// (Prop.) Returns a total perimeter value
        /// of all shapes in container.
        /// </summary>
        public double TotalArea
        {
            get
            {
                double totalArea = 0;
                foreach (var shape in shapes)
                {
                    if (shape != null)
                        totalArea += shape.GetArea();
                }
                return totalArea;
            }
        }

        /// <summary>
        /// (Prop.) Returns a total area value
        /// of all shapes in container.
        /// </summary>
        public double TotalPerimeter
        {
            get
            {
                double totalPerim = 0;
                foreach (var shape in shapes)
                {
                    if (shape != null)
                        totalPerim += shape.GetPerimeter();
                }
                return totalPerim;
            }
        }

        /// <summary>
        /// Indexer that returns an IShape obj
        /// by its index in container.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IShape this[int index]
        {
            get
            {
                if (index > shapes.Length)
                    throw new IndexOutOfRangeException("Index must not" +
                        "be bigger than max capacity of ShapeBox container.");

                return shapes[index];
            }
            set
            {
                if (index > shapes.Length)
                    throw new IndexOutOfRangeException("Index must not" +
                        "be bigger than max capacity of ShapeBox container.");

                shapes[index] = value;
            }
        }

        /// <summary>
        /// Adds an IShape to a container.
        /// If there is an attempt to add a 
        /// duplicate object an exception 
        /// occured.
        /// </summary>
        /// <param name="shape"></param>
        /// <exception cref="ApplicationException"/>
        public void Add(IShape shape)
        {
            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i].Equals(shape))
                    throw new ApplicationException("An object duplicate can not" +
                        "be stored in this container.");
            }
        }

        /// <summary>
        /// Tries to add an IShape to a container.
        /// If there is an attempt to add a duplicate
        /// object nothing occured.
        /// </summary>
        /// <param name="shape"></param>
        public void TryAdd(IShape shape)
        {
            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i].Equals(shape))
                    return;
            }
        }

        /// <summary>
        /// Extracts an IShape obj from
        /// a container at a specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"/>
        public IShape ExtractAt(int index)
        {
            // Get object by its index.
            var result = this[index];

            if (result != null)
            {
                // Remove this obj.
                RemoveAt(index);
                return result;
            }
            else
                throw new NullReferenceException("There is nothing to" +
                    "extract by specified index.");
        }

        /// <summary>
        /// Removes an IShape obj
        /// at a specified index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (this[index] != null)
                this[index] = null;
        }

        /// <summary>
        /// Extracts all specified TShape
        /// objects from container.
        /// </summary>
        /// <typeparam name="TShape"></typeparam>
        /// <returns>Extracted shapes of the same type.</returns>
        public ICollection<TShape> ExtractByType<TShape>() where TShape : IShape
        {
            var resultList = new List<TShape>();

            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i] != null)
                {
                    // Compares the run-time shape type
                    // with a generic one.
                    if (shapes[i].GetType().Equals(typeof(TShape)))
                    {
                        resultList.Add((TShape)shapes[i]);
                        RemoveAt(i);
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// Extracts all shapes that are
        /// made of a specified TMaterial
        /// from container.
        /// </summary>
        /// <typeparam name="TMaterial"></typeparam>
        /// <returns>Extracted shapes made of the same material.</returns>
        public ICollection<IShape> ExtractByMaterial<TMaterial>() where TMaterial : IMaterial
        {
            var resultList = new List<IShape>();

            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i] != null)
                {
                    if (shapes[i].Material.GetType().Equals(typeof(TMaterial)))
                    {
                        resultList.Add(shapes[i]);
                        RemoveAt(i);
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// Find IShapes that are equivalents
        /// to a given sample by material
        /// and shape area.
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public ICollection<IShape> TryFindBySample(IShape sample)
        {
            var resultList = new List<IShape>();
            foreach (var shape in shapes)
            {
                if (shape.Material.Equals(sample.Material)
                    && Math.Abs(shape.GetArea() - sample.GetArea()) < tolerance)
                {
                    resultList.Add(shape);
                }
            }

            return resultList;
        }


        #region Load from XML-file
        /// <summary>
        /// Loads all shapes from XML-file
        /// using StreamReader.
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadAllShapesFromXmlViaStreamReader(string filePath)
        {
            foreach (var shape in ShapeXmlParser.StreamReaderParseFromXmlFile(filePath))
            {
                // If the space is out.
                if (this.Capacity == this.Count)
                    return;

                this.TryAdd(shape);
            }
        }

        /// <summary>
        /// Loads all shapes from XML-file
        /// using XmlReader.
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadAllShapesFromXmlViaXmlReader(string filePath)
        {
            foreach (var shape in ShapeXmlParser.XmlReaderParseFromXmlFile(filePath))
            {
                // If the space is out.
                if (this.Capacity == this.Count)
                    return;

                this.TryAdd(shape);
            }
        }
        #endregion


        #region Save to XML-file
        /// <summary>
        /// Saves all shapes from the container
        /// to XML-file via StreamWriter.
        /// </summary>
        /// <param name="outputFilePath"></param>
        public void SaveAllShapesToXmlFileViaStreamWriter(string outputFilePath)
        {
            var savingList = new List<IShape>();
            foreach (var shape in shapes)
            {
                if (shape != null)
                    savingList.Add(shape);
            }

            ShapeXmlParser.StreamWriterParseToXmlFile(savingList, outputFilePath);
        }

        /// <summary>
        /// Saves all shapes from the container
        /// to XML-file via XmlWriter.
        /// </summary>
        /// <param name="outputFilePath"></param>
        public void SaveAllShapesToXmlFileViaXmlWriter(string outputFilePath)
        {
            var savingList = new List<IShape>();
            foreach (var shape in shapes)
            {
                if (shape != null)
                    savingList.Add(shape);
            }

            ShapeXmlParser.XmlWriterParseToXmlFile(savingList, outputFilePath);
        }

        /// <summary>
        /// Saves shapes of a specified
        /// material from the container
        /// to XML-file via StreamWriter.
        /// </summary>
        /// <typeparam name="TMaterial"></typeparam>
        /// /// <param name="outputFilePath"></param>
        public void SaveShapesToXmlFileViaStreamWriterByMaterial<TMaterial>(string outputFilePath)
            where TMaterial : IMaterial
        {
            var savingList = new List<IShape>();

            foreach (var shape in shapes)
            {
                if (shape != null)
                    if (shape.Material.GetType().Equals(typeof(TMaterial)))
                        savingList.Add(shape);
            }

            ShapeXmlParser.StreamWriterParseToXmlFile(savingList, outputFilePath);
        }

        /// <summary>
        /// Saves shapes of a specified
        /// material from the container
        /// to XML-file via XmlWriter.
        /// </summary>
        /// <typeparam name="TMaterial"></typeparam>
        /// /// <param name="outputFilePath"></param>
        public void SaveShapesToXmlFileViaXmlWriterByMaterial<TMaterial>(string outputFilePath)
            where TMaterial : IMaterial
        {
            var savingList = new List<IShape>();

            foreach (var shape in shapes)
            {
                if (shape != null)
                    if (shape.Material.GetType().Equals(typeof(TMaterial)))
                        savingList.Add(shape);
            }

            ShapeXmlParser.XmlWriterParseToXmlFile(savingList, outputFilePath);
        }
        #endregion


        /// <summary>
        /// Check the equality of this ShapeBox instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var shapeBox = (ShapeBox)obj;

            for (int i = 0; i < shapes.Length; i++)
            {
                // If even a shapes order is different
                // than the shape boxes are not equal.
                if (!shapes[i].Equals(shapeBox.shapes[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a hash-code for a ShapeBox object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return shapes.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with ShapeBox elements.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"ShapeBox capacity: {Capacity};\n" +
                $"ShapeBox elements: {Count}.");
        }
    }
}

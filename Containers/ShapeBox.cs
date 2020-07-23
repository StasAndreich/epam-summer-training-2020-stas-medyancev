﻿using System;
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
        public ICollection<TMaterial> ExtractByMaterial<TMaterial>() where TMaterial : IMaterial
        {
            var resultList = new List<TMaterial>();

            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i] != null)
                {
                    if (shapes[i].Material.Equals(typeof(TMaterial)))
                    {
                        resultList.Add((TMaterial)shapes[i]);
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
    }
}

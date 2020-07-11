using System;
using System.Collections.Generic;

namespace Shapes
{
    /// <summary>
    /// Abstract class that defines a basic
    /// geometrical shape and its basic methods.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Returns an array of sides computed from points.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static double[] GetSidesArrayFromPoints(params Point[] points)
        {
            double[] sides = new double[points.Length];

            for (int i = 0; i < points.Length - 1; i++)
            {
                // Compute a side between the last and the first points.
                if (i == points.Length - 2)
                {
                    sides[i + 1] = Math.Sqrt(
                    Math.Pow(points[i + 1].X - points[0].X, 2) +
                    Math.Pow(points[i + 1].Y - points[0].Y, 2));
                }

                sides[i] = Math.Sqrt(
                    Math.Pow(points[i].X - points[i + 1].X, 2) +
                    Math.Pow(points[i].Y - points[i + 1].Y, 2));
            }

            return sides;
        }

        /// <summary>
        /// Returns an array of shapes that
        /// are equal to a shape passed as parameter.
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static Shape[] FindEqualShapesInArray(Shape[] shapes, Shape shape)
        {
            var equalShapes = new List<Shape>();

            foreach (var item in shapes)
            {
                if (item.Equals(shape))
                    equalShapes.Add(item);
            }

            return equalShapes.ToArray();
        }

        /// <summary>
        /// Basic ctor that takes a name of a figure.
        /// </summary>
        /// <param name="name">Figure name.</param>
        public Shape(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Keeps the shape name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Returns the perimeter of the shape.
        /// </summary>
        /// <returns>Double perimeter value.</returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Returns the area of the shape.
        /// </summary>
        /// <returns>Double area value.</returns>
        public abstract double GetArea();
    }
}

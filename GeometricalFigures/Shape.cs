using System;

namespace Shapes
{
    /// <summary>
    /// Abstract class that defines a basic
    /// geometrical shape and its basic methods.
    /// </summary>
    public abstract class Shape
    {
        public static double[] GetSidesArrayFromVertices(params Point[] vertices)
        {
            double[] sides = new double[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                sides[i] = Math.Sqrt(
                    Math.Pow(vertices[i].X - vertices[i + 1].X, 2) +
                    Math.Pow(vertices[i].Y - vertices[i + 1].Y, 2));

                if (i == vertices.Length - 1)
                {
                    i++;
                    sides[i] = Math.Sqrt(
                    Math.Pow(vertices[i].X - vertices[i + 1].X, 2) +
                    Math.Pow(vertices[i].Y - vertices[i + 1].Y, 2));
                }
            }

            return sides;
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
        public string Name { get; }

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

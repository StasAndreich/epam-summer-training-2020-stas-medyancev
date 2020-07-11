using System;

namespace Shapes
{
    /// <summary>
    /// Abstract class that defines a basic
    /// geometrical shape and its basic methods.
    /// </summary>
    public abstract class Shape
    {
        public static double[] GetSidesArrayFromPoints(params Point[] points)
        {
            double[] sides = new double[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                sides[i] = Math.Sqrt(
                    Math.Pow(points[i].X - points[i + 1].X, 2) +
                    Math.Pow(points[i].Y - points[i + 1].Y, 2));

                if (i == points.Length - 1)
                {
                    i++;
                    sides[i] = Math.Sqrt(
                    Math.Pow(points[i].X - points[i + 1].X, 2) +
                    Math.Pow(points[i].Y - points[i + 1].Y, 2));
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

using System;

namespace Shapes
{
    /// <summary>
    /// Defines a general triangle shape.
    /// </summary>
    public class Triangle : Shape 
    {
        /// <summary>
        /// Ctor that inits a triangle with 3 sides.
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        /// <param name="cSide"></param>
        public Triangle(double aSide, double bSide, double cSide)
            : base("Triangle")
        {
            this.Sides = new double[]
            {
                aSide, bSide, cSide
            };
        }

        /// <summary>
        /// Ctor that inits a triangle with 3 vertices.
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <param name="vertex3"></param>
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
            : base("Triangle")
        {
            this.Sides = Shape.GetSidesArrayFromVertices(vertex1,
                                                         vertex2,
                                                         vertex3);
        }

        /// <summary>
        /// Array that keeps all the triangle sides.
        /// </summary>
        public double[] Sides { get; }

        /// <summary>
        /// Returns a triangle perimeter.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            double perimeter = 0;

            foreach (var side in Sides)
            {
                perimeter += side;
            }

            return perimeter;
        }

        /// <summary>
        /// Returns an area of the triangle.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            // Use Heron's formula.
            var halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(
                (halfPerimeter / 2) *
                (halfPerimeter - Sides[0]) *
                (halfPerimeter - Sides[1]) *
                (halfPerimeter - Sides[2]));

        }

        /// <summary>
        /// Returns a formatted string filled with Triangle props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"{base.Name}";

            foreach (var side in Sides)
            {
                result += $" {side}";
            }

            return result;
        }
    }
}

using System;

namespace Shapes
{
    /// <summary>
    /// Defines a general rectangle shape.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Ctor that inits a rectangle with 2 sides.
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        public Rectangle(double aSide, double bSide)
            : base("Rectangle")
        {
            this.Sides = new double[]
            {
                aSide, bSide
            };
        }

        /// <summary>
        /// Ctor that inits a rectangle with 3 points.
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <param name="vertex3"></param>
        /// <param name="vertex4"></param>
        public Rectangle(Point vertex1, Point vertex2,
                        Point vertex3, Point vertex4)
            : base("Rectangle")
        {
            this.Sides = Shape.GetSidesArrayFrompoints(vertex1,
                                                         vertex2,
                                                         vertex3,
                                                         vertex4);
        }

        /// <summary>
        /// Array that keeps all the triangle sides.
        /// </summary>
        public double[] Sides { get; }

        /// <summary>
        /// Returns a rectangle perimeter.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return (Sides[0] + Sides[1]) * 2;
        }

        /// <summary>
        /// Returns an area of the rectangle.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Sides[0] * Sides[1];
        }

        /// <summary>
        /// Returns a formatted string filled with Rectangle props.
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

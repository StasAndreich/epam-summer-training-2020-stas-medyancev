using System;

namespace Shapes
{
    /// <summary>
    /// Defines a general triangle shape.
    /// </summary>
    public class Triangle : Polygon 
    {
        /// <summary>
        /// Ctor that inits a triangle with 3 sides.
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        /// <param name="cSide"></param>
        public Triangle(double aSide, double bSide, double cSide)
            : base("Triangle", aSide, bSide, cSide)
        { }

        /// <summary>
        /// Ctor that inits a triangle with 3 points.
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <param name="vertex3"></param>
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
            : base("Triangle", vertex1,
                               vertex2,
                               vertex3)
        { }

        /// <summary>
        /// Returns a triangle perimeter.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return base.GetPerimeter();
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
            return base.ToString();
        }

        /// <summary>
        /// Returns a hash-code for a triangle object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Check the equality of this triangle instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

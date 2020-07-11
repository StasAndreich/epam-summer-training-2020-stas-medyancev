﻿namespace Shapes
{
    /// <summary>
    /// Defines a general rectangle shape.
    /// </summary>
    public class Rectangle : Polygon
    {
        /// <summary>
        /// Ctor that inits a rectangle with 2 sides.
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        public Rectangle(double aSide, double bSide)
            : base("Rectangle", aSide, bSide, aSide, bSide)
        { }

        /// <summary>
        /// Ctor that inits a rectangle with 4 points.
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <param name="vertex3"></param>
        /// <param name="vertex4"></param>
        public Rectangle(Point vertex1, Point vertex2,
                        Point vertex3, Point vertex4)
            : base("Rectangle", vertex1,
                                vertex2,
                                vertex3,
                                vertex4)
        { }

        /// <summary>
        /// Returns a rectangle perimeter.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return base.GetPerimeter();
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
            return base.ToString();
        }

        /// <summary>
        /// Returns a hash-code for a rectangle object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Check the equality of this rectangle instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

namespace Shapes
{
    /// <summary>
    /// Defines a general square shape.
    /// </summary>
    public class Square : Polygon
    {
        /// <summary>
        /// Ctor that inits a square with a side size.
        /// </summary>
        /// <param name="side"></param>
        public Square(double side)
            : base("Square", side, side, side, side)
        { }

        /// <summary>
        /// Ctor that inits a square with 4 points.
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <param name="vertex3"></param>
        /// <param name="vertex4"></param>
        public Square(Point vertex1, Point vertex2,
                        Point vertex3, Point vertex4)
            : base("Square", vertex1,
                             vertex2,
                             vertex3,
                             vertex4)
        { }

        /// <summary>
        /// Returns a square perimeter.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return base.GetPerimeter();
        }

        /// <summary>
        /// Returns an area of the square.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Sides[0] * Sides[1];
        }

        /// <summary>
        /// Returns a formatted string filled with Square props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Returns a hash-code for a square object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Check the equality of this square instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

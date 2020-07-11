using System;

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
        /// Ctor that inits a square with 4 vertices
        /// passed in (counter) clock-wise order (sequence).
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
        /// Keeps all the square sides.
        /// </summary>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ApplicationException"/>
        public override double[] Sides
        {
            get => base.Sides;
            set
            {
                // Validation.
                if (value.Length < 4)
                    throw new ApplicationException("Less than 4 sides passed as parameters for building a rectangle.");

                // Check the array for negative values.
                foreach (var side in value)
                {
                    if (side < 0)
                        throw new ArgumentException("Sides can't be of negative values.");
                }

                // Rectangle validation.
                for (int i = 0; i < value.Length + 1; i++)
                {
                    if (value[i] != value[i + 1])
                        throw new ApplicationException("Incorrect square size.");
                }                    

                // Assign value if everything is good.
                Sides = value;
            }
        }

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

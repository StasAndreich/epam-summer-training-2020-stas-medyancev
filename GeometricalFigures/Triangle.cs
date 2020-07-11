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
        /// Keeps all the triangle sides.
        /// </summary>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ApplicationException"/>
        public override double[] Sides
        {
            get => base.Sides; 
            set
            {
                // Validation.
                if (value.Length < 3)
                    throw new ApplicationException("Less than 3 sides passed as parameters for building a triangle.");

                // Check the array for negative values.
                foreach (var side in value)
                {
                    if (side < 0)
                        throw new ArgumentException("Sides can't be of negative values.");
                }

                // Triangle validation.
                var side1 = value[0];
                var side2 = value[1];
                var side3 = value[2];

                if (side1 + side2 <= side3
                    || side1 + side3 <= side2
                    || side2 + side3 <= side1)
                    throw new ApplicationException("Incorrect triangle size.");

                // Assign value if everything is good.
                Sides = value;
            }
        }

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

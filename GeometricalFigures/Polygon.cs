using System;

namespace Shapes
{
    /// <summary>
    /// Defines a general polygon.
    /// </summary>
    public class Polygon : Shape
    {
        private double[] sides;

        /// <summary>
        /// Ctor that inits a polygon with its sides.
        /// </summary>
        /// <param name="polygonName"></param>
        /// <param name="sides"></param>
        public Polygon(string polygonName, params double[] sides)
            : base(polygonName)
        {
            // Sides array is same-sized as sides params count.
            this.Sides = sides;
        }

        /// <summary>
        /// Ctor that inits a polygon with its points.
        /// </summary>
        /// <param name="polygonName"></param>
        /// <param name="points"></param>
        public Polygon(string polygonName, params Point[] points)
            : base(polygonName)
        {            
            // Get sides values from static method.
            this.Sides = Shape.GetSidesArrayFromPoints(points);
        }

        /// <summary>
        /// Keeps all the polygon sides.
        /// </summary>
        public double[] Sides
        {
            get => sides;
            set
            {
                if (value.Length < 3)
                    throw new ApplicationException("Less than 3 sides passed as parameters for building a polygon.");

                sides = value;
            }
        }

        /// <summary>
        /// Returns the perimeter of the polygon.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            double perimeter = 0;

            foreach (var side in sides)
            {
                perimeter += side;
            }

            return perimeter;
        }

        /// <summary>
        /// Returns the area of the polygon.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}

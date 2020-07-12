using System;

namespace Shapes
{
    /// <summary>
    /// Defines a general polygon.
    /// </summary>
    public class Polygon : Shape
    {
        /// <summary>
        /// Array of all polygon sides.
        /// </summary>
        protected double[] sides;

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
        public virtual double[] Sides
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

        /// <summary>
        /// Returns a formatted string filled with Polygon props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"{base.Name}";
            foreach (var side in sides)
            {
                result += $" {side}";
            }

            return result;
        }

        /// <summary>
        /// Returns a hash-code for a circle object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (int)(GetArea() * GetPerimeter() / 2);
            }
        }

        /// <summary>
        /// Check the equality of this polygon instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var polygon = (Polygon)obj;

            for (int i = 0; i < this.sides.Length; i++)
            {
                if (this.sides[i] != polygon.sides[i])
                    return false;
            }

            return true;
        }
    }
}

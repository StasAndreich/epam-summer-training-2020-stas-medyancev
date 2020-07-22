using Materials;
using System;

namespace Shapes
{
    /// <summary>
    /// Defines a general triangle shape.
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Creates an equilateral triangle.
        /// </summary>
        /// <param name="side"></param>
        public Triangle(double side)
        {

        }

        /// <summary>
        /// Triangle shape material.
        /// </summary>
        public IMaterial Material { get; }

        /// <summary>
        /// Shape name.
        /// </summary>
        public string Name { get; }

        private double side;
        /// <summary>
        /// Triangle side.
        /// </summary>
        public double Side
        {
            get => side;
            set
            {
                _ = (value < 0) ? side = Math.Abs(value)
                                : side = value;
            }
        }

        /// <summary>
        /// Returns a perimeter of the triangle.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return Side * 3;
        }

        /// <summary>
        /// Returns an area of the triangle.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            // Use Heron's formula.
            var halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(
                (halfPerimeter / 2) *
                (halfPerimeter - Side) *
                (halfPerimeter - Side) *
                (halfPerimeter - Side));
        }

        /// <summary>
        /// Check the equality of this triangle instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var triangle = (Triangle)obj;
            var tolerance = 0.00001f;

            return Math.Abs(this.Side - triangle.Side) < tolerance;
        }

        /// <summary>
        /// Returns a hash-code for a triangle object.
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
        /// Returns a formatted string filled with triangle props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name} {Side} {Side} {Side}");
        }
    }
}

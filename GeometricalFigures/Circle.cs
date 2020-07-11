using System;

namespace Shapes
{
    /// <summary>
    /// Defines a circle shape on a plane.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Default ctor that inits a circle.
        /// </summary>
        /// <param name="center">Point structure.</param>
        /// <param name="radius">Double value.</param>
        public Circle(Point center, double radius)
            : base("Circle")
        {
            this.Radius = radius;
            this.Center = center;
        }

        /// <summary>
        /// Circle radius.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Cirlce center point.
        /// </summary>
        public Point Center { get; set; }

        /// <summary>
        /// Returns a circumference.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Returns a circle area.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Returns a formatted string filled with Circle props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{base.Name} {Center} {Radius}");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

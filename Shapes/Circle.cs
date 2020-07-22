using Materials;
using System;
using System.Net;

namespace Shapes
{
    /// <summary>
    /// Defines a circle shape.
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Default ctor that inits a circle.
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="material"></param>
        public Circle(IMaterial material, double radius)
        {
            this.Material = material;
            this.radius = radius;   
            this.Name = "Circle";
        }

        /// <summary>
        /// Circle shape material.
        /// </summary>
        public IMaterial Material { get; }

        /// <summary>
        /// Shape name.
        /// </summary>
        public string Name { get; }

        private double radius;
        /// <summary>
        /// Circle radius prop. If setting a negative
        /// value positive one will be applied.
        /// </summary>
        public double Radius
        {
            get => radius;
            set
            {
                _ = (value < 0) ? radius = Math.Abs(value)
                                : radius = value;
            }
        }

        /// <summary>
        /// Returns a perimeter (length) of the circle.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Returns an area of the circle.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Paints shape in a specific color.
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColor(Color color)
        {
            this.Material.Paint(color);
        }

        /// <summary>
        /// Check the equality of this circle instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var circle = (Circle)obj;
            var tolerance = 0.00001f;

            return Math.Abs(this.Radius - circle.Radius) < tolerance;
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
        /// Returns a formatted string filled with circle props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name} {Radius}");
        }
    }
}

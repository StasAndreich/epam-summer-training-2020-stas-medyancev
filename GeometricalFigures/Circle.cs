using System;

namespace Shapes
{
    /// <summary>
    /// Defines a circle shape on a plane.
    /// </summary>
    public class Circle : Shape
    {
        private double radius;

        /// <summary>
        /// Default ctor that inits a circle.
        /// </summary>
        /// <param name="radius">Double value.</param>
        public Circle(double radius)
            : base("Circle")
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Circle radius prop. If setting a negative
        /// value positive one will be applied.
        /// </summary>
        public double Radius
        { 
            get => radius;
            set
            {
                if (value < 0)
                    // No matter what is the sign of
                    // the radius value.
                    radius = Math.Abs(value);
                else
                    radius = value;
            }
        }

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
            return string.Format($"{base.Name} {Radius}");
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

            return this.Radius.Equals(circle.Radius);
        }
    }
}

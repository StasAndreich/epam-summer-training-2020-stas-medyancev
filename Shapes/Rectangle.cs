using Materials;
using System;

namespace Shapes
{
    /// <summary>
    /// Defines a rectangle shape.
    /// </summary>
    public class Rectangle : IShape
    {
        /// <summary>
        /// Ctor that inits a rectangle with 2 sides.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
            this.Name = "Rectangle";
        }
        /// <summary>
        /// Ctor that inits a rectangle with 2 sides
        /// and a specific material.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="material"></param>
        public Rectangle(IMaterial material, double height, double width)
            : this(height, width)
        {
            this.Material = material;
        }

        /// <summary>
        /// Copy-ctor for creating a rectangle
        /// from another shape.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Rectangle(IShape shape, double height, double width)
        {
            var rect = new Rectangle(shape.Material, height, width);
            if (!(rect.GetArea() <= shape.GetArea()))
                throw new ApplicationException("There is impossible to cut out" +
                    "a bigger shape from a smaller one.");
            else
            {
                this.Material = rect.Material;
                this.Height = rect.Height;
                this.Width = rect.Width;
                this.Name = rect.Name;
            }
        }

        /// <summary>
        /// Rectangle shape material.
        /// </summary>
        public IMaterial Material { get; }

        /// <summary>
        /// Shape name.
        /// </summary>
        public string Name { get; }

        private double width;
        private double height;
        /// <summary>
        /// Rectangle width.
        /// </summary>
        public double Width
        {
            get => width;
            set
            {
                _ = (value < 0) ? width = Math.Abs(value) 
                                : width = value;
            }
        }
        /// <summary>
        /// Rectangle height.
        /// </summary>
        public double Height
        {
            get => height;
            set
            {
                _ = (value < 0) ? height = Math.Abs(value)
                                : height = value;
            }
        }

        /// <summary>
        /// Returns a perimeter of the rectangle.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return (Height + Width) * 2;
        }

        /// <summary>
        /// Returns an area of the rectangle.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return Height * Width;
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
        /// Check the equality of this rectangle instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var rectangle = (Rectangle)obj;
            var tolerance = 0.00001f;

            return Math.Abs(this.Width - rectangle.Width) < tolerance
                && Math.Abs(this.Height - rectangle.Height) < tolerance;
        }

        /// <summary>
        /// Returns a hash-code for a rectangle object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (int)(GetArea() * GetPerimeter() / 2) ^ Name.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a formatted string filled with rectangle props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name} {Height} {Width}");
        }
    }
}

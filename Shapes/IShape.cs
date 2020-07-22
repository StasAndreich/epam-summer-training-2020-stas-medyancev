using Materials;

namespace Shapes
{
    /// <summary>
    /// Contains definitions for a shape elements.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Shape material.
        /// </summary>
        IMaterial Material { get; }

        /// <summary>
        /// Shape name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns a perimeter of the shape.
        /// </summary>
        /// <returns></returns>
        double GetPerimeter();

        /// <summary>
        /// Returns an area of the shape.
        /// </summary>
        /// <returns></returns>
        double GetArea();

        /// <summary>
        /// Paints shape in a specific color.
        /// </summary>
        /// <param name="color"></param>
        void ChangeColor(Color color);
    }
}

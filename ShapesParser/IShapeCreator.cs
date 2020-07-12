using Shapes;

namespace ShapesUtilities
{
    /// <summary>
    /// Interface that defines a factory method
    /// for creating shapes instances.
    /// </summary>
    public interface IShapeCreator
    {
        /// <summary>
        /// Creates a specific shape using its sides.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        Shape CreateShape(params double[] sides);

        /// <summary>
        /// Creates a specific shape using its coordinates.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        Shape CreateShape(params Point[] points);
    }
}

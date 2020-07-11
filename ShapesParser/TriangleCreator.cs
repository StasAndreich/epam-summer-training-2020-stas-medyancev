using Shapes;

namespace ShapesUtilities
{
    /// <summary>
    /// Class-creator that implements a fabric method
    /// for creating a triangle.
    /// </summary>
    public class TriangleCreator : IShapeCreator
    {
        /// <summary>
        /// Creates a triangle using sides values.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params double[] sides)
        {
            if (sides.Length != 3)
                throw new System.ApplicationException("Incorrect input data for creating a triangle.");

            return new Triangle(sides[0], sides[1], sides[2]);
        }

        /// <summary>
        /// Creates a triangle using coordinates.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params Point[] points)
        {
            if (points.Length != 3)
                throw new System.ApplicationException("Incorrect input data for creating a triangle.");

            return new Triangle(points[0], points[1], points[2]);
        }
    }
}

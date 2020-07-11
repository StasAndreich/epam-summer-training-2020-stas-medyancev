using Shapes;

namespace ShapesUtilities
{
    /// <summary>
    /// Class-creator that implements a fabric method
    /// for creating a rectangle.
    /// </summary>
    public class RectangleCreator : IShapeCreator
    {
        /// <summary>
        /// Creates a rectangle using sides values.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params double[] sides)
        {
            if (sides.Length != 2)
                throw new System.ApplicationException("Incorrect input data for creating a rectangle.");

            return new Rectangle(sides[0], sides[1]);
        }

        /// <summary>
        /// Creates a rectangle using coordinates.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params Point[] points)
        {
            if (points.Length != 4)
                throw new System.ApplicationException("Incorrect input data for creating a rectangle.");

            return new Rectangle(points[0], points[1], points[2], points[3]);
        }
    }
}

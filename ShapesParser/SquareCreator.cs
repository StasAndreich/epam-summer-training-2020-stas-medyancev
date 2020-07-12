using Shapes;

namespace ShapesUtilities
{
    /// <summary>
    /// Class-creator that implements a fabric method
    /// for creating a square.
    /// </summary>
    public class SquareCreator : IShapeCreator
    {
        /// <summary>
        /// Creates a square using sides values.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params double[] sides)
        {
            if (sides.Length != 1)
                throw new System.ApplicationException("Incorrect input data for creating a square.");

            return new Square(sides[0]);
        }

        /// <summary>
        /// Creates a square using coordinates.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params Point[] points)
        {
            if (points.Length != 4)
                throw new System.ApplicationException("Incorrect input data for creating a square.");

            return new Square(points[0], points[1], points[2], points[3]);
        }
    }
}

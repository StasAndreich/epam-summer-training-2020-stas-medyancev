using Shapes;

namespace ShapesUtilities
{
    /// <summary>
    /// Class-creator that implements a fabric method
    /// for creating a circle.
    /// </summary>
    public class CircleCreator : IShapeCreator
    {
        /// <summary>
        /// Creates a circle using a side param as its radius.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params double[] sides)
        {
            if (sides.Length != 1)
                throw new System.ApplicationException("Incorrect input data for creating a circle.");

            // Use a side parameter as circle radius.
            return new Circle(sides[0]);
        }

        /// <summary>
        /// Non-suitable method for circle creating.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"/>
        public Shape CreateShape(params Point[] points)
        {
            throw new System.ApplicationException("There is no way to create a circle from a single point.");
        }
    }
}

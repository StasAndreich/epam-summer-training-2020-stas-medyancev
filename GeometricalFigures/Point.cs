namespace Shapes
{
    /// <summary>
    /// Struct that defines a point on a plane.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X-coord.
        /// </summary>
        public double X;

        /// <summary>
        /// Y-coord.
        /// </summary>
        public double Y;

        /// <summary>
        /// Returns a formatted string filled with Point data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"({X}; {Y})");
        }
    }
}

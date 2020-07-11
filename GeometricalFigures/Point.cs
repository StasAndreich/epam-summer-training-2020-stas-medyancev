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

        /// <summary>
        /// Returns a hash-code for a point object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ((int)X << 2) ^ (int)Y;
        }

        /// <summary>
        /// Check the equality of this point instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var point = (Point)obj;

            return (this.X.Equals(point.X))
                && (this.Y.Equals(point.Y));
        }
    }
}

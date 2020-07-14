using System;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a three-dimensional vector.
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// Ctor that creates a new vector
        /// with (x, y, z) components.
        /// </summary>
        /// <param name="x">X-component.</param>
        /// <param name="y">Y-component.</param>
        /// <param name="z">Z-component.</param>
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// X-component of the vector.
        /// </summary>
        public double X { get; protected set; }

        /// <summary>
        /// Y-component of the vector.
        /// </summary>
        public double Y { get; protected set; }

        /// <summary>
        /// Z-component of the vector.
        /// </summary>
        public double Z { get; protected set; }


        /// <summary>
        /// Returns a formatted string for Vector3.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + this.X + ";" + this.Y + ";" + this.Z + ")";
        }

        /// <summary>
        /// Vector3 class Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var vector3 = (Vector3)obj;
            return this.X.Equals(vector3.X) && this.Y.Equals(vector3.Y) && this.Z.Equals(vector3.Z);
        }

        /// <summary>
        /// Overrides GetHashCode in a simple way.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)(this.X * this.Y / this.Z);
        }
    }
}

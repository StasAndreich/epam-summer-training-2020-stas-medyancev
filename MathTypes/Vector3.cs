using System;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a three-dimensional vector.
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// Shortcut property for creating Vector3(1, 1, 1).
        /// </summary>
        public static Vector3 One
        {
            get => new Vector3(1f, 1f, 1f);
        }

        /// <summary>
        /// Shortcut property for creating Vector3(0, 0, 0).
        /// </summary>
        public static Vector3 Zero
        {
            get => new Vector3(0f, 0f, 0f);
        }

        /// <summary>
        /// Shortcut property for creating Vector3(float.NegativeInfinity,
        /// float.NegativeInfinity, float.NegativeInfinity).
        /// </summary>
        public static Vector3 NegativeInfinity
        {
            get => new Vector3(double.NegativeInfinity,
                               double.NegativeInfinity,
                               double.NegativeInfinity);
        }

        /// <summary>
        /// Shortcut property for creating Vector3(float.PositiveInfinity,
        /// float.PositiveInfinity, float.PositiveInfinity).
        /// </summary>
        public static Vector3 PositiveInfinity
        {
            get => new Vector3(double.PositiveInfinity,
                               double.PositiveInfinity,
                               double.PositiveInfinity);
        }

        /// <summary>
        /// Ctor that creates a new vector
        /// with (x, y, z) components.
        /// </summary>
        /// <param name="x">X-component.</param>
        /// <param name="y">Y-component.</param>
        /// <param name="z">Z-component.</param>
        public Vector3(double x, double y, double z)
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
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public double Magnitude
        {
            get => (double)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Returns squared length of this vector (Read Only).
        /// </summary>
        public double SqrMagnitude
        {
            get => (double)(X * X + Y * Y + Z * Z);
        }

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
            return this.X.Equals(vector3.X)
                && this.Y.Equals(vector3.Y)
                && this.Z.Equals(vector3.Z);
        }

        /// <summary>
        /// Overrides GetHashCode in a simple way.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)(this.X * this.Y / this.Z);
        }

        /// <summary>
        /// Set x, y and z components of an existing Vector3.
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newZ"></param>
        public void Set(float newX, float newY, float newZ)
        {
            this.X = newX;
            this.Y = newY;
            this.Z = newZ;
        }


        #region Operators overloading
        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Subtracts one vector from another.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Scalar multiplication of two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector3 a, Vector3 b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 a, double num)
        {
            return new Vector3(a.X * num, a.Y * num, a.Z * num);
        }

        /// <summary>
        /// Divides a vector by a number.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 a, double num)
        {
            if (!num.Equals(0))
                return new Vector3(a.X / num, a.Y / num, a.Z / num);
            throw new InvalidOperationException("Division by zero.");
        }

        /// <summary>
        /// Returns true if two vectors are equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 a, Vector3 b)
        {           
            return a.Equals(b);
        }

        /// <summary>
        /// Returns true if vectors are not equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !a.Equals(b);
        }
        #endregion
    }
}

using System;
using System.Diagnostics;

namespace EuclideanAlgo
{
    /// <summary>
    /// Static class that describes methods for
    /// computing the greatest common divisor.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Returns the GCD of two signed integers.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b)
        {
            var aAbs = Math.Abs(a);
            var bAbs = Math.Abs(b);

            while (aAbs != bAbs)
            {
                _ = (aAbs > bAbs) ? (aAbs -= bAbs) :
                    (bAbs -= aAbs);
            }

            return aAbs;
        }

        /// <summary>
        /// Returns the GCD of three signed integers.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, int c)
        {
            var cAbs = Math.Abs(c);
            return GetEuclideanGCD(GetEuclideanGCD(a, b), cAbs);
        }

        /// <summary>
        /// Returns the GCD of four signed integers.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <param name="d">Forth integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, int c, int d)
        {
            var dAbs = Math.Abs(d);
            return GetEuclideanGCD(GetEuclideanGCD(a, b, c), dAbs);
        }

        /// <summary>
        /// Returns the GCD of five signed integers.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <param name="d">Forth integer</param>
        /// <param name="e">Fifth integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, int c, int d, int e)
        {
            var eAbs = Math.Abs(e);
            return GetEuclideanGCD(GetEuclideanGCD(a, b, c, d), eAbs);
        }


        public static int GetSteinGCD(int a, int b, out long execTime)
        {
            // Starting a new Stopwatch for execution time measuring.
            var stopwatch = Stopwatch.StartNew();

            // Check simple cases.
            if (a == b)
            {
                // Get the execution time value.
                stopwatch.Stop();
                execTime = stopwatch.ElapsedMilliseconds;
                return a;
            }

            if (a == 0)
            {
                stopwatch.Stop();
                execTime = stopwatch.ElapsedMilliseconds;
                return b;
            }
            
            if (b == 0)
            {
                stopwatch.Stop();
                execTime = stopwatch.ElapsedMilliseconds;
                return a;
            }

            // Check if divisible by 2.
        }
    }
}

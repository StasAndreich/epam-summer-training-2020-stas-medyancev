using System;
using System.Collections.Generic;
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
        /// Returns the GCD of two signed integers
        /// using Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b)
        {
            int aAbs = Math.Abs(a);
            int bAbs = Math.Abs(b);

            // Simple cases that protect the while statement
            // from infinite looping.
            if (aAbs == 0)
                return bAbs;

            if (bAbs == 0)
                return aAbs;

            while (aAbs != bAbs)
            {
                _ = (aAbs > bAbs) ? (aAbs -= bAbs) :
                    (bAbs -= aAbs);
            }

            return aAbs;
        }

        /// <summary>
        /// Returns the GCD of three signed integers
        /// using Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, int c)
        {
            int cAbs = Math.Abs(c);
            return GetEuclideanGCD(GetEuclideanGCD(a, b), cAbs);
        }

        /// <summary>
        /// Returns the GCD of four signed integers
        /// using Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <param name="d">Forth integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, int c, int d)
        {
            int dAbs = Math.Abs(d);
            return GetEuclideanGCD(GetEuclideanGCD(a, b, c), dAbs);
        }

        /// <summary>
        /// Returns the GCD of five signed integers
        /// using Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <param name="d">Forth integer</param>
        /// <param name="e">Fifth integer</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, int c, int d, int e)
        {
            int eAbs = Math.Abs(e);
            return GetEuclideanGCD(GetEuclideanGCD(a, b, c, d), eAbs);
        }

        /// <summary>
        /// Returns the GCD of two signed integers
        /// using Stein binary algorithm.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="execTime">Method execution time out-parameter</param>
        /// <returns>GCD int-value</returns>
        public static int GetSteinGCD(int a, int b, out long execTime)
        {
            // Does not include Abs() in time measurement.
            int aAbs = Math.Abs(a);
            int bAbs = Math.Abs(b);

            // Starting a new Stopwatch for execution time measuring.
            var stopwatch = Stopwatch.StartNew();

            // Here (shift) is a temporal holder of shifts
            // needed to restore the common factors of 2
            // for the numbers that are the greatest
            // power of 2.
            var shift = 0;

            // Check simple cases.
            if (aAbs == 0)
            {
                stopwatch.Stop();
                execTime = stopwatch.ElapsedTicks;
                return bAbs;
            }

            if (bAbs == 0)
            {
                stopwatch.Stop();
                execTime = stopwatch.ElapsedTicks;
                return aAbs;
            }

            // If these nums are the greatest power of 2
            // then divide both aAbs and bAbs.
            while (((aAbs | bAbs) & 1) == 0)
            {
                shift++;
                aAbs >>= 1;
                bAbs >>= 1;
            }

            while ((aAbs & 1) == 0)
            {
                aAbs >>= 1;
            }

            // In this part bAbs is always odd.
            do
            {
                // Remove all factors of 2 in bAbs (they're not common):
                // bAbs is not zero
                while ((bAbs & 1) == 0)
                    bAbs >>= 1;

                // Now aAbs and bAbs are both odd.
                // Swap the numbers if necessary.
                if (aAbs > bAbs)
                {
                    // Swap aAbs and bAbs.
                    var tmp = bAbs;
                    bAbs = aAbs;
                    aAbs = tmp;
                }

                // At this place bAbs >= aAbs.
                bAbs -= aAbs;
            } while (bAbs != 0);

            stopwatch.Stop();
            execTime = stopwatch.ElapsedTicks;

            // Restore common factors of 2.
            return aAbs << shift;
        }

        /// <summary>
        /// Returns the GCD of two signed integers.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="execTime">Method execution time out-parameter</param>
        /// <returns>GCD int-value</returns>
        public static int GetEuclideanGCD(int a, int b, out long execTime)
        {
            // Does not include Abs() in time measurement.
            int aAbs = Math.Abs(a);
            int bAbs = Math.Abs(b);

            // Starting a new Stopwatch for execution time measuring.
            var stopwatch = Stopwatch.StartNew();

            // Check simple cases.
            if (aAbs == 0)
            {
                // Stopping the stopwatch and getting execTime.
                stopwatch.Stop();
                execTime = stopwatch.ElapsedTicks;
                return bAbs;
            }

            if (bAbs == 0)
            {
                stopwatch.Stop();
                execTime = stopwatch.ElapsedTicks;
                return aAbs;
            }

            while (aAbs != bAbs)
            {
                _ = (aAbs > bAbs) ? (aAbs -= bAbs) :
                    (bAbs -= aAbs);
            }

            // Get the execution time value.
            stopwatch.Stop();
            execTime = stopwatch.ElapsedTicks;

            return aAbs;
        }

        /// <summary>
        /// Compairs execution time of two GCD algorithms
        /// for the same integer values.
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>Key-value pairs of IDictionary</returns>
        public static IDictionary<string, long> GetGCDExecTimeComparisonData(int a, int b)
        {
            long euclideanTime;
            long steinTime;

            GetEuclideanGCD(a, b, execTime: out euclideanTime);
            GetSteinGCD(a, b, execTime: out steinTime);

            // Add results to a dictionary.
            var data = new SortedDictionary<string, long>();
            data.Add("Euclidean algorithm", euclideanTime);
            data.Add("Stein algorithm", steinTime);

            return data;
        }
    }
}

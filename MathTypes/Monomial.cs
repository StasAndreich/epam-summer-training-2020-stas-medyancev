using System;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a monomial.
    /// </summary>
    public sealed class Monomial
    {
        /// <summary>
        /// Ctor that creates a monomial using coef 
        /// and degree values (by default: degree = 0).
        /// </summary>
        /// <param name="coef"></param>
        /// <param name="degree"></param>
        public Monomial(double coef, double degree = 0)
        {
            this.Coefficient = coef;
            this.Degree = degree;
        }

        /// <summary>
        /// Monomial coefficient value.
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Monomial degree.
        /// </summary>
        public double Degree { get; set; }

        /// <summary>
        /// Inserts a parameter value in monomial.
        /// </summary>
        /// <param name="variableValue"></param>
        /// <returns>Computed monomial result.</returns>
        public double GetMonomialValue(double variableValue)
        {
            return Math.Pow(variableValue, Degree) * Coefficient;
        }
    }
}

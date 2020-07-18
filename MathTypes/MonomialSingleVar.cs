using System;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a single variable monomial.
    /// </summary>
    public sealed class MonomialSingleVar
    {
        /// <summary>
        /// Keeps monomial exponent (non-negative int).
        /// </summary>
        private int exponent;

        /// <summary>
        /// Ctor that creates a monomial using coef 
        /// and exponent values (by default: degree = 0).
        /// </summary>
        /// <param name="coef"></param>
        /// <param name="exponent"></param>
        public MonomialSingleVar(double coef, int exponent = 0)
        {
            this.Coefficient = coef;
            this.Exponent = exponent;
        }

        /// <summary>
        /// Monomial coefficient value.
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Monomial degree.
        /// </summary>
        public int Exponent
        {
            get => exponent;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Monomial exponent " +
                        "can't be anything except non-negative integer.");

                exponent = value;
            }
        }

        /// <summary>
        /// Inserts a parameter value in monomial.
        /// </summary>
        /// <param name="variableValue"></param>
        /// <returns>Computed monomial result.</returns>
        public double Evaluate(double variableValue)
        {
            return Math.Pow(variableValue, Exponent) * Coefficient;
        }

        /// <summary>
        /// Overrides ToString().
        /// </summary>
        /// <returns>Formatted string (ex. -2x^(4)).</returns>
        public override string ToString()
        {
            return $"{Coefficient}x^({Exponent})";
        }

        /// <summary>
        /// Overrides GetHashCode().
        /// </summary>
        /// <returns>Hash code for current obj.</returns>
        public override int GetHashCode()
        {
            return (int)(Coefficient * Exponent / 2);
        }

        /// <summary>
        /// Checks the equality of two monomials.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var monomial = (MonomialSingleVar)obj;

            if (!(this.Coefficient.Equals(monomial.Coefficient)
                && this.Exponent.Equals(monomial.Exponent)))
                return false;

            return true;
        }


        #region Operators overloadings
        /// <summary>
        /// Adds two monomials.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator +(MonomialSingleVar lhs, MonomialSingleVar rhs)
        {
            // If degrees are different.
            if (!lhs.Exponent.Equals(rhs.Exponent))
                return lhs;

            return new MonomialSingleVar(lhs.Coefficient + rhs.Coefficient,
                                lhs.Exponent);
        }

        /// <summary>
        /// Subtracts two monomials.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator -(MonomialSingleVar lhs, MonomialSingleVar rhs)
        {
            // If degrees are different.
            if (!lhs.Exponent.Equals(rhs.Exponent))
                return lhs;

            return new MonomialSingleVar(lhs.Coefficient - rhs.Coefficient,
                                lhs.Exponent);
        }

        /// <summary>
        /// Multiplies two monomials.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator *(MonomialSingleVar lhs, MonomialSingleVar rhs)
        {
            return new MonomialSingleVar(lhs.Coefficient * rhs.Coefficient,
                                lhs.Exponent + rhs.Exponent);
        }

        /// <summary>
        /// Divides two monomials.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator /(MonomialSingleVar lhs, MonomialSingleVar rhs)
        {
            return new MonomialSingleVar(lhs.Coefficient / rhs.Coefficient,
                                lhs.Exponent - rhs.Exponent);
        }
        #endregion
    }
}

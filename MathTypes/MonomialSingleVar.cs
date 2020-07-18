using System;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a single variable monomial.
    /// </summary>
    public sealed class MonomialSingleVar
    {
        /// <summary>
        /// Keeps monomial degree (non-negative int).
        /// </summary>
        private int degree;

        /// <summary>
        /// Ctor that creates a monomial using coef 
        /// and degree values (by default: degree = 0).
        /// </summary>
        /// <param name="coef"></param>
        /// <param name="degree"></param>
        public MonomialSingleVar(double coef, int degree = 0)
        {
            this.Coefficient = coef;
            this.degree = degree;
        }

        /// <summary>
        /// Monomial coefficient value.
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Monomial degree.
        /// </summary>
        public int Degree
        {
            get => degree;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Monomial degree " +
                        "can't be anything except non-negative integer.");

                this.degree = value;
            }
        }

        /// <summary>
        /// Inserts a parameter value in monomial.
        /// </summary>
        /// <param name="variableValue"></param>
        /// <returns>Computed monomial result.</returns>
        public double GetMonomialValue(double variableValue)
        {
            return Math.Pow(variableValue, Degree) * Coefficient;
        }

        /// <summary>
        /// Overrides ToString().
        /// </summary>
        /// <returns>Formatted string (ex. -2x^(4)).</returns>
        public override string ToString()
        {
            return $"{Coefficient}x^({Degree})";
        }

        /// <summary>
        /// Overrides GetHashCode().
        /// </summary>
        /// <returns>Hash code for current obj.</returns>
        public override int GetHashCode()
        {
            return (int)(Coefficient * Degree / 2);
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
                && this.Degree.Equals(monomial.Degree)))
                return false;

            return true;
        }


        #region Operators overloadings
        /// <summary>
        /// Adds two monomials.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator +(MonomialSingleVar original, MonomialSingleVar other)
        {
            if (!original.Degree.Equals(other.Degree))
                return null;

            return new MonomialSingleVar(original.Coefficient + other.Coefficient,
                                original.Degree);
        }

        /// <summary>
        /// Subtracts two monomials.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator -(MonomialSingleVar original, MonomialSingleVar other)
        {
            if (!original.Degree.Equals(other.Degree))
                return null;

            return new MonomialSingleVar(original.Coefficient - other.Coefficient,
                                original.Degree);
        }

        /// <summary>
        /// Multiplies two monomials.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator *(MonomialSingleVar original, MonomialSingleVar other)
        {
            return new MonomialSingleVar(original.Coefficient * other.Coefficient,
                                original.Degree + other.Degree);
        }

        /// <summary>
        /// Divides two monomials.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static MonomialSingleVar operator /(MonomialSingleVar original, MonomialSingleVar other)
        {
            return new MonomialSingleVar(original.Coefficient / other.Coefficient,
                                original.Degree - other.Degree);
        }
        #endregion
    }
}

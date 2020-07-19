using System;
using System.Collections.Generic;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a polynomial
    /// of a single variable in standart form.
    /// </summary>
    public class PolynomialSingleVar
    {
        private const double tolerance = 0.000001;

        /// <summary>
        /// Ctor that creates a single variable polynomial 
        /// using coeffs for creating monomials
        /// with degrees corresponding to their serial numbers.
        /// </summary>
        /// <param name="coefficients"></param>
        public PolynomialSingleVar(params double[] coefficients)
        {
            for (int i = 0; i < coefficients.Length; i++)
            {
                members.Add(new MonomialSingleVar(coefficients[i], i));
            }
        }

        /// <summary>
        /// Keeps all poynomial monomials-members.
        /// </summary>
        private List<MonomialSingleVar> members = new List<MonomialSingleVar>();

        /// <summary>
        /// Returns max exponent value of current polynomial.
        /// </summary>
        public int MaxExponent { get => members.Count - 1; }

        /// <summary>
        /// Returns the count of polynomial mono-members.
        /// </summary>
        public int Count { get => members.Count; }

        /// <summary>
        /// Evaluates a polynomial with a variable value.
        /// </summary>
        /// <param name="variableValue"></param>
        /// <returns></returns>
        public double Evaluate(double variableValue)
        {
            double result = 0;

            foreach (var member in members)
            {
                result += member.Evaluate(variableValue);
            }

            return result;
        }

        /// <summary>
        /// Overrides ToString.
        /// </summary>
        /// <returns>Formatted string of PolynomialSingleVar.</returns>
        public override string ToString()
        {
            //string result = $"{members[0]})";

            //for (int i = 1; i < members.Count; i++)
            //{
            //    result += $" + ({members[i]})";
            //}

            return base.ToString();
        }

        /// <summary>
        /// Overrides Equals of two polynomial obj.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var polynomial = (PolynomialSingleVar)obj;

            // Amount of monomials is not the same.
            if (!members.Count.Equals(polynomial.members.Count))
                return false;

            for (int i = 0; i < this.members.Count; i++)
            {
                if (!members[i].Equals(polynomial.members[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Overrides GetHashCode based polynomial components.
        /// </summary>
        /// <returns>Polynomial object hash code.</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            foreach (var item in members)
            {
                hash += item.GetHashCode();
            }

            return hash / members.Count;
        }

        /// <summary>
        /// Creates a copy of current polynomial.
        /// </summary>
        /// <returns>New PolynomialSingleVar object.</returns>
        public PolynomialSingleVar GetCopy()
        {
            var paramsArray = new double[members.Count];

            for (int i = 0; i < members.Count; i++)
            {
                paramsArray[i] = members[i].Coefficient;
            }

            return new PolynomialSingleVar(paramsArray);
        }

        /// <summary>
        /// Adds a new member to the polynomial.
        /// </summary>
        /// <param name="mono">Monomial.</param>
        public void AddMember(MonomialSingleVar mono)
        {
            // If exp of param is bigger than max exp.
            if (mono.Exponent > this.MaxExponent)
            {
                // Fill members list with empty monomials.
                for (int i = 0; i < mono.Exponent - this.MaxExponent; i++)
                {
                    if (mono.Exponent == this.MaxExponent)
                        // Param monomial.
                        members.Add(new MonomialSingleVar(mono.Coefficient, mono.Exponent));
                    else
                        // Empty (0, 0) monomial.
                        members.Add(new MonomialSingleVar(0));
                }
            }
            // If exp of param is less than max exp (or equals).
            else
            {
                members[mono.Exponent] += mono;
            }
        }

        /// <summary>
        /// Adds a new member to the polynomial.
        /// </summary>
        /// <param name="exp">Exponent.</param>
        /// <param name="coef">Coefficient.</param>
        public void AddMember(int exp, double coef)
        {
            // If exp of param is bigger than max exp.
            if (exp > this.MaxExponent)
            {
                // Fill members list with empty monomials.
                for (int i = 0; i < exp - this.MaxExponent; i++)
                {
                    if (exp == this.MaxExponent)
                        // Param monomial.
                        members.Add(new MonomialSingleVar(coef, exp));
                    else
                        // Empty (0, 0) monomial.
                        members.Add(new MonomialSingleVar(0));
                }
            }
            // If exp of param is less than max exp (or equals).
            else
            {
                members[exp] += new MonomialSingleVar(coef, exp);
            }
        }

        /// <summary>
        /// Indexer that provides access to the polynomial
        /// members by its exponent.
        /// </summary>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public MonomialSingleVar this[int exponent]
        {
            get
            {
                if (exponent < 0)
                    throw new ArgumentOutOfRangeException("Exponent can't be less than 0.");

                if (exponent > members.Count)
                    throw new ArgumentOutOfRangeException("Exponent can't be bigger than it actually is.");

                return members[exponent];
            }
        }

        #region Operator overloadings
        /// <summary>
        /// Adds two polynomials.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PolynomialSingleVar operator +(PolynomialSingleVar lhs, PolynomialSingleVar rhs)
        {
            // Create a new obj.
            var resultPoly = lhs.GetCopy();

            // Add all members.

            foreach (var member in rhs.members)
            {
                resultPoly.AddMember(member);
            }

            return resultPoly;
        }

        /// <summary>
        /// Subtracts two monomials.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PolynomialSingleVar operator -(PolynomialSingleVar lhs, PolynomialSingleVar rhs)
        {
            // Create a new obj.
            var resultPoly = lhs.GetCopy();

            for (int i = 0; i < rhs.members.Count; i++)
            {
                if (rhs.members[i].Exponent > resultPoly.MaxExponent)
                {
                    // Add new member with negative coef.
                    resultPoly.members.Add(new MonomialSingleVar(-rhs.members[i].Coefficient,
                                                                  rhs.members[i].Exponent));
                }
                else
                {
                    // Subtract coeffs.
                    resultPoly[i].Coefficient -= rhs.members[i].Coefficient;
                }
            }

            return resultPoly;
        }

        

        public PolynomialSingleVar Minus(PolynomialSingleVar lhs, PolynomialSingleVar rhs)
        {
            // Create a new obj.
            var resultPoly = lhs.GetCopy();

            for (int i = 0; i < rhs.members.Count; i++)
            {
                if (rhs.members[i].Exponent > resultPoly.MaxExponent)
                {
                    // Add new member with negative coef.
                    resultPoly.members.Add(new MonomialSingleVar(-rhs.members[i].Coefficient,
                                                                  rhs.members[i].Exponent));
                }
                else
                {
                    // Subtract coeffs.
                    resultPoly[i].Coefficient -= rhs.members[i].Coefficient;
                }
            }

            return resultPoly;
        }
        #endregion
    }
}

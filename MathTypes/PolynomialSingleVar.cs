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
                Members.Add(new MonomialSingleVar(coefficients[i], i));
            }
        }

        private List<MonomialSingleVar> members = new List<MonomialSingleVar>();

        /// <summary>
        /// Provides access to monomials of the polynomial.
        /// </summary>
        public List<MonomialSingleVar> Members 
        { 
            get => this.members;// ???
            set
            {
                if ()
            }
        }

        /// <summary>
        /// Returns max exponent value of current polynomial.
        /// </summary>
        public int MaxExponent
        {
            get
            {
                var maxExp = 0;
                foreach (var member in Members)
                {
                    if (member.Exponent > maxExp)
                        maxExp = member.Exponent;
                }

                return maxExp;
            }
        }

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

            foreach (var member in Members)
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
            string result = $"{Members[0]})";

            for (int i = 1; i < Members.Count; i++)
            {
                result += $" + ({Members[i]})";
            }

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
            if (!Members.Count.Equals(polynomial.Members.Count))
                return false;

            for (int i = 0; i < this.Members.Count; i++)
            {
                if (!Members[i].Equals(polynomial.Members[i]))
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

            foreach (var item in Members)
            {
                hash += item.GetHashCode();
            }

            return hash / Members.Count;
        }

        public PolynomialSingleVar GetCopy()
        {


            var copy = new PolynomialSingleVar();
        }

        /// <summary>
        /// Adds a new member to the polynomial.
        /// </summary>
        /// <param name="member"></param>
        public void AddMember(MonomialSingleVar member)
        {

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
                    throw new ArgumentOutOfRangeException("Expone");
                members[exponent]
            }
        }

        #region Operator overloadings
        //public static PolynomialSingleVar operator +(PolynomialSingleVar lhs, PolynomialSingleVar rhs)
        //{
        //    //var paramsList = new List<double>();

        //    //var maxCount = Math.Max(lhs.monomials.Count, rhs.monomials.Count);

        //    //for (int i = 0; i < maxCount; i++)
        //    //{
        //    //    paramsList.Add();
        //    //}




        //    //for (int i = 0; i < lhs.monomials.Count; i++)
        //    //{
        //    //    for (int j = 0; j < rhs.monomials.Count; j++)
        //    //    {
        //    //        // If degrees are equal than Add monomials.
        //    //        if (lhs.monomials[i].Degree.Equals(rhs.monomials[j].Degree))
        //    //        {
        //    //            paramsList.Add(lhs.monomials[i].Coefficient + rhs.monomials[j].Coefficient);
        //    //            break;
        //    //        }
        //    //        // Else add this monomial to the list of monomials
        //    //        // in polynomial type.
        //    //        else
        //    //            paramsList.Add(rhs.monomials[j].Coefficient);
        //    //    }
        //    //}

        //    ////foreach (var item in monoList)
        //    ////{
        //    ////    resultPoly.monomials.Add(item);
        //    ////}

        //    //return new PolynomialSingleVar(paramsList.ToArray());
        //}

        //public static PolynomialSingleVar operator -(PolynomialSingleVar lhs, PolynomialSingleVar rhs)
        //{

        //}
        #endregion
    }
}

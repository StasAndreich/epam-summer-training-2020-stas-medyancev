using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MathTypes
{
    /// <summary>
    /// Type that defines a polynomial
    /// of a single variable.
    /// </summary>
    public class PolynomialSingleVar
    {
        /// <summary>
        /// Creates a single variable polynomial 
        /// using coeffs for creating monomials
        /// with degrees of their serial numbers.
        /// </summary>
        /// <param name="coefficients"></param>
        public PolynomialSingleVar(params double[] coefficients)
        {
            for (int i = 0; i < coefficients.Length; i++)
            {
                this.Monomials.Add(new MonomialSingleVar(coefficients[i], i));
            }
            // new Poly(3, 4, 5);
            5x^2 + 4x + 3
        }

        /// <summary>
        /// Creates a single variable polynomial
        /// from multiple monomials.
        /// </summary>
        /// <param name="inputMonomials"></param>
        public PolynomialSingleVar(params MonomialSingleVar[] inputMonomials)
        {
            this.Monomials.AddRange(inputMonomials);
        }


        private List<MonomialSingleVar> monomials = new List<MonomialSingleVar>();

        /// <summary>
        /// Provides access to monomials of the polynomial.
        /// </summary>
        public List<MonomialSingleVar> Monomials
        {
            get => monomials;
            set
            {
                // Standard polynomial form validation.
                foreach (var inputMono in value)
                {
                    for (int i = 0; i < monomials.Count; i++)
                    {
                        if (monomials[i].Degree == inputMono.Degree)
                            monomials[i] += inputMono;
                        else
                            monomials.Add(inputMono);
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var polynomial = (PolynomialSingleVar)obj;

            if (!this.Monomials.Count.Equals(polynomial.Monomials.Count))
                return false;



            return base.Equals(obj);
        }


        public static PolynomialSingleVar operator +(PolynomialSingleVar aPoly, PolynomialSingleVar bPoly)
        {
            // Copy...
            var resultPoly = new PolynomialSingleVar(aPoly.Monomials.ToArray());

            for (int i = 0; i < resultPoly.Monomials.Count; i++)
            {
                for (int j = 0; j < bPoly.Monomials.Count; j++)
                {
                    if (resultPoly.Monomials[i].Degree != bPoly.Monomials[j].Degree)
                        continue;

                    resultPoly.Monomials[i] += bPoly.Monomials[j];
                }
            }

            return resultPoly;
        }
    }
}

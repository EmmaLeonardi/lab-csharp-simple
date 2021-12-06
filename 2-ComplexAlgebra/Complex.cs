using System;
using System.Collections.Generic;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// Model Complex numbers in an object-oriented way and implement this class.
    /// In other words, you must provide a means for:
    ///* instantiating complex numbers
    ///* accessing a complex number's real, and imaginary parts
    ///* accessing a complex number's modulus, and phase
    ///* complementing a complex number
    ///* summing up or subtracting two complex numbers
    ///* representing a complex number as a string or the form Re +/- iIm
    ///- e.g. via the ToString() method
    ///* checking whether two complex numbers are equal or not
    ///- e.g. via the Equals(object) method
    public class Complex
    {
        //private double _real;
        //private double _imm;

        public double Real
        {
            get;
        }

        public double Imaginary
        {
            get;
        }

        public Complex(double real, double imm)
        {
            Real = real;
            Imaginary = imm;
        }

        public double Modulus => System.Math.Sqrt(Real * Real + Imaginary * Imaginary);
        

        public double Phase => System.Math.Atan2(Imaginary, Real);
        
        public Complex Complement() => new Complex(Real, -Imaginary);
        

        public Complex Plus(Complex c)=> new Complex(Real + c.Real, Imaginary + c.Imaginary);
        
        public Complex Minus(Complex c)=> new Complex(Real - c.Real, Imaginary - c.Imaginary);
        

        public override string ToString()
        {
          
            string n="";
            if (Real > 0)
            {
                n = "+" + Real.ToString();
            }
            else if (Real < 0)
            {
                n = Real.ToString();
            }
            else
            {
                //Real=0
            }


            if (Imaginary * Imaginary == 1)
            {
                n = n + (Imaginary == 1 ? "+i" : "-i");
            }
            else if (Imaginary > 0)
            {
                n = n + "+" + Imaginary.ToString();
            }
            else if (Imaginary < 0)
            {
                n = n + Imaginary.ToString();
            }
            else
            {
                //Immaginary=0
            }

            if (Real == 0 && Imaginary == 0) return "0";

            return n;
        }



        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }
    }
}
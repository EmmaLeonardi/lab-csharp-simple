﻿using System;
using System.Linq;
using ComplexAlgebra;

namespace Arrays
{
    class Program
    {
        /// <summary>
        /// Given an array of <see cref="Complex"/> numbers, this method returns the one number with highest modulus,
        /// or <c>null</c>, in case of empty array
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>the <see cref="Complex"/> number with highest modulus in <paramref name="array"/>,
        /// or <c>null</c> in case <paramref name="array"/> is empty</returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        /// <seealso cref="Examples.Max"/>
        public static Complex MaxModulus(Complex[] array)
        {
            
            if (array.Length.Equals(0))
            {
                return null;
            }
            else
            {
                Complex max = new Complex(array[0].Real,array[0].Imaginary);
                foreach (Complex elem in array)
                {
                    if (max.Modulus < elem.Modulus)
                    {
                        max = new Complex(elem.Real, elem.Imaginary);
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Creates a <a href="https://en.wikipedia.org/wiki/Object_copying">shallow copy</a> of the given array of
        /// <see cref="Complex"/> numbers.
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>the shallow copy of <paramref name="array"/></returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        public static Complex[] Clone(Complex[] array)
        {
            if (array.Length.Equals(0))
            {
                throw new NullReferenceException("Cannot copy an empty array");
            }
            else
            {
                Complex[] copyArray = new Complex[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    copyArray[i] = array[i];
                }
                return copyArray;
            }
        }

        /// <summary>
        /// Creates a <a href="https://en.wikipedia.org/wiki/Object_copying">shallow copy</a> of the given array of
        /// <see cref="Complex"/> numbers, ordered by phase (from the lowest one to the highest one)
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>the shallow copy of <paramref name="array"/></returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        /// <seealso cref="Examples.BubbleSort"/>
        public static Complex[] SortByPhase(Complex[] array)
        {
            return Program.Clone(array).OrderBy(a => a.Phase).ToArray();


        }

        /// <summary>
        /// Creates a representation of the provided array of <see cref="Complex"/> as a string.
        /// Items of <paramref name="array"/> are represented via their <see cref="Complex.ToString"/> method.
        /// They are separated by a semicolon and enclosed within square brackets.
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>a string</returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
         public static string ArrayToString(Complex[] array)
        {
            string s = "";
            if (array.Length.Equals(0))
            {
                throw new NullReferenceException("Cannot create a representation of an empty array");
            }
            else
            {
                foreach(Complex elem in array)
                {
                    s += "[ " + elem.ToString() + " ], ";
                }
                return s;
            }
        }

        /// <summary>
        /// Test method for the aforementioned array algorithms
        /// </summary>
        static void Main(string[] args)
        {
            Complex[] numbers = new[] {
                 new Complex(0, 0),
                 new Complex(1, 1),
                 new Complex(0, 1),
                 new Complex(-2, 2),
                 new Complex(-3, 0),
                 new Complex(-2, -2),
                 new Complex(0, -4),
                 new Complex(1, -1),
                 new Complex(1, 0)
             };

            Complex[] orderedByPhase = new[] {
                 new Complex(-2, -2),
                 new Complex(0, -4),
                 new Complex(1, -1),
                 new Complex(0, 0),
                 new Complex(1, 0),
                 new Complex(1, 1),
                 new Complex(0, 1),
                 new Complex(-2, 2),
                 new Complex(-3, 0)
             };

            var cloned = numbers;

            ArraysAreEqual(cloned, numbers);
            ArraysAreEqual(SortByPhase(numbers), orderedByPhase);
            ArraysAreEqual(numbers, cloned);
            CheckComplexNumber(MaxModulus(numbers), new Complex(0, -4));
            CheckComplexNumber(MaxModulus(orderedByPhase), new Complex(0, -4));
            CheckComplexNumber(MaxModulus(cloned), new Complex(0, -4));
        }

        /// <summary>
        /// Checks whether the <paramref name="actual"/> array of <see cref="Complex"/> numbers is item-wise equal to
        /// the <paramref name="expected"/> one.
        /// </summary>
        /// <remarks>
        /// Items are compared via their <see cref="Complex.Equals(object)"/> method.
        /// </remarks>
        /// <param name="actual">the array of <see cref="Complex"/> numbers under test</param>
        /// <param name="expected">the expected array of <see cref="Complex"/> numbers</param>
        static void ArraysAreEqual(Complex[] actual, Complex[] expected)
        {
            var message = $"Error: expected: {ArrayToString(expected)}, actual: {ArrayToString(actual)}";
            if (expected.Length != actual.Length)
            {
                Console.WriteLine(message);
                return;
            }
            for (int i = 0; i < actual.Length; i++)
            {
                if (!actual[i].Equals(expected[i]))
                {
                    Console.WriteLine(message);
                    return;
                }
            }
            Console.WriteLine($"Array {ArrayToString(actual)} is ok");
        }

        /// <summary>
        /// Checks whether the <paramref name="actual"/> <see cref="Complex"/> number is equal to the
        /// <paramref name="expected"/> one (via the <see cref="Complex.Equals(object)"/> method).
        /// </summary>
        /// <param name="actual">the <see cref="Complex"/> number under test</param>
        /// <param name="expected">the <see cref="Complex"/> number <paramref name="actual"/> should be equal to</param>
        static void CheckComplexNumber(Complex actual, Complex expected)
        {
            if (!actual.Equals(expected))
            {
                Console.WriteLine($"Error: ({actual.ToString()}) has not the same hash code of ({expected.ToString()})");
                return;
            }
            Console.WriteLine($"({actual.ToString()}) is ok");
        }
    }
}
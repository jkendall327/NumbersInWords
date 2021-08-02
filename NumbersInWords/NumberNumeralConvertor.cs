using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersInWords
{
    /// <summary>
    /// Provides methods for converting between digits and numerals.
    /// </summary>
    public class NumberNumeralConvertor
    {
        private readonly string[] units = new[]
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private readonly string[] tens = new[]
        {
            "zero",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        private void HandlePowerOfTen(StringBuilder sb, ref int originalValue, int power, string numeral)
        {
            if ((originalValue / power) > 0)
            {
                sb.Append(ToWords(originalValue / power) + $" {numeral} ");
                originalValue %= power;
            }
        }

        /// <summary>
        /// Convert an integer into a human-readable numeral, e.g. '5' becomes 'five'.
        /// </summary>
        /// <param name="values">The integer to convert.</param>
        /// <returns>A list of converted values.</returns>
        public string ToWords(int value)
        {
            if (value == int.MinValue)
                return "minus" + " " + ToWords(int.MaxValue);

            if (value == 0)
                return "zero";

            if (value < 0)
                return "minus " + ToWords(Math.Abs(value));

            StringBuilder words = new();

            HandlePowerOfTen(words, ref value, 1000000, "million");
            HandlePowerOfTen(words, ref value, 1000, "thousand");
            HandlePowerOfTen(words, ref value, 100, "hundred");

            var result = words.ToString();

            if (value <= 0)
                return result;

            if (result != "")
                result += "and ";

            if (value < 20)
            {
                result += units[value];
            }
            else
            {
                result += tens[value / 10];

                if ((value % 10) > 0)
                    result += "-" + units[value % 10];
            }

            return result;
        }

        /// <summary>
        /// Convert a sequence of integers into human-readable numerals, e.g. '5' becomes 'five'.
        /// </summary>
        /// <param name="values">The integers to convert.</param>
        /// <returns>A list of converted values.</returns>
        public IEnumerable<string> ToWords(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                yield return ToWords(value);
            }
        }

        /// <summary>
        /// Converts a numeral to an integer. Invalid input is silently omitted.
        /// </summary>
        /// <param name="values">The numeral to convert.</param>
        /// <returns>The converted value.</returns>
        public int ToNumbers(string value)
        {
            return 0;
        }

        /// <summary>
        /// Converts a sequence of numerals to integers. Invalid input is silently omitted.
        /// </summary>
        /// <param name="values">The numerals to convert.</param>
        /// <returns>A list of converted values.</returns>
        public IEnumerable<int> ToNumbers(IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                yield return ToNumbers(value);
            }
        }
    }
}

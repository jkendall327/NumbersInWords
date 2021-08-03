using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersInWords
{
    /// <summary>
    /// Provides methods for converting between digits and numerals.
    /// </summary>
    public class NumberToNumeralConverter
    {
        private readonly string[] _units = new[]
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

        private readonly string[] _tens = new[]
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

        private readonly Dictionary<int, string> _significantFigures = new()
        {
            { 1_000_000_000, "billion," },
            { 1_000_000, "million," },
            { 1000, "thousand," },
            { 100, "hundred" }
        };

        /// <summary>
        /// Convert an integer into a human-readable numeral, e.g. '5' becomes 'five'.
        /// </summary>
        /// <param name="values">The integer to convert.</param>
        /// <returns>A list of converted values.</returns>
        public string ToWords(int value)
        {
            // base cases
            if (value < 20 && value >= 0)
                return _units[value];

            // special case
            if (value is int.MinValue)
                return HandleMinValue();

            // flip all other negatives
            if (value < 0)
                return "minus " + ToWords(Math.Abs(value));

            StringBuilder words = new();

            // recursively split up by significant figures
            // where clause skips unnecessary steps: don't check 500 against 1,000,000 etc.
            foreach (var pair in _significantFigures.Where(x => x.Key <= value))
            {
                HandleSignificantFigures(words, ref value, pair.Key, pair.Value);
            }

            var tempResult = words.ToString();

            if (tempResult != "")
                words.Append("and ");

            // tens, e.g. 'twenty', 'fifty'
            words.Append(_tens[value / 10]);

            // compounds, e.g. 'thirty-four'
            int remainder = value % 10;

            if (remainder > 0)
                words.Append("-" + _units[remainder]);

            return CleanResult(words.ToString());
        }

        private static string CleanResult(string result)
        {
            // clean-up awkward values like 1000

            if (result.EndsWith("and zero"))
            {
                result = result.Remove(result.Length - "and zero".Length);
            }

            result = result.Trim();

            if (result.EndsWith(","))
            {
                result = result.Remove(result.Length - ",".Length);
            }

            return result;
        }

        private string HandleMinValue()
        {
            // https://stackoverflow.com/questions/6265381/c-sharp-short-error-negating-the-minimum-value-of-a-twos-complement-number-is-i

            var max = "minus " + ToWords(int.MaxValue);

            // Math.Abs of min val can't be represented in an int
            // edit the string manually
            return max.Remove(max.Length - "seven".Length) + "eight";
        }

        private void HandleSignificantFigures(StringBuilder sb, ref int originalValue, int power, string numeral)
        {
            int result = originalValue / power;

            if (result <= 0) return;

            sb.Append(ToWords(result) + $" {numeral} ");

            originalValue %= power;
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
    }
}

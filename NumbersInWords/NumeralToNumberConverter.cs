using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumbersInWords
{
    public class NumeralToNumberConverter
    {
        private readonly Dictionary<string, int> _numbers = new()
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            { "ten", 10 },

            { "eleven", 11 },
            { "twelve", 12 },
            { "thirteen", 13 },
            { "fourteen", 14 },
            { "fifteen", 15 },
            { "sixteen", 16 },
            { "seventeen", 17 },
            { "eighteen", 18 },
            { "nineteen", 19 },

            { "twenty", 20 },
            { "thirty", 30 },
            { "forty", 40 },
            { "fifty", 50 },
            { "sixty", 60 },
            { "seventy", 70 },
            { "eighty", 80 },
            { "ninety", 90 },

            { "hundred", 100 },
            { "thousand", 1000 },
            { "million", 1000000 },
            { "billion", 1000000000 }
        };

        /// <summary>
        /// Converts a numeral to an integer. Invalid input is silently omitted.
        /// </summary>
        /// <param name="values">The numeral to convert.</param>
        /// <returns>The converted value.</returns>
        public int ToNumbers(string input)
        {
            input = input.ToLowerInvariant();

            var numbers = Regex.Matches(input, @"\w+")
                .Where(v => _numbers.ContainsKey(v.Value))
                .Select(v => _numbers[v.Value]);

            bool isNegative = input.StartsWith("minus", StringComparison.InvariantCultureIgnoreCase);

            var result = Accumulate(numbers, isNegative);

            if (isNegative)
                result *= -1;

            return result;
        }

        private int Accumulate(IEnumerable<int> numbers, bool negativeNumber)
        {
            int accumulator = 0;
            int total = 0;

            try
            {
                checked
                {
                    foreach (var n in numbers)
                    {
                        if (n >= 1000)
                        {
                            total += (accumulator * n);
                            accumulator = 0;
                        }
                        else if (n >= 100)
                        {
                            accumulator *= n;
                        }
                        else
                        {
                            accumulator += n;
                        }
                    }
                }

            }
            catch (OverflowException)
            {
                return negativeNumber ? int.MinValue : int.MaxValue;
            }

            return total + accumulator;
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

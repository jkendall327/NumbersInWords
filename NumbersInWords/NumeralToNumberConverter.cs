using System;
using System.Collections.Generic;

namespace NumbersInWords
{
    public class NumeralToNumberConverter
    {
        /// <summary>
        /// Converts a numeral to an integer. Invalid input is silently omitted.
        /// </summary>
        /// <param name="values">The numeral to convert.</param>
        /// <returns>The converted value.</returns>
        public int ToNumbers(string value)
        {
            throw new NotImplementedException();
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

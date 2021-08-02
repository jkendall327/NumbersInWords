using System.Collections.Generic;

namespace NumbersInWords
{
    public class ArgsValidator
    {
        /// <summary>
        /// Attempts to parse the elements of a string array as integers.
        /// </summary>
        /// <param name="args">The array of strings to parse as integers.</param>
        /// <returns>A list of successfully-parsed intergers.</returns>
        public static List<int> Validate(string[] args)
        {
            var values = new List<int>(args.Length);

            foreach (var item in args)
            {
                if (int.TryParse(item, out int result))
                {
                    values.Add(result);
                }
            }

            return values;
        }
    }
}

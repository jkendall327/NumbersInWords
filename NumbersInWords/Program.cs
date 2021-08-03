using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersInWords
{
    class Program
    {
        private readonly static StringBuilder _sb = new();

        // https://codingdojo.org/kata/NumbersInWords/
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers => words converter");

            if (args.Length < 1)
            {
                Console.WriteLine("No command-line arguments found. Using example data.");
                args = new[] { "34", "-11", "12341444" };
            }

            var validatedArgs = ArgsValidator.Validate(args);

            Console.WriteLine(FormatInput(validatedArgs));

            var output = new NumberToNumeralConverter().ToWords(validatedArgs);

            Console.WriteLine(FormatOutput(output));

            Console.WriteLine("Try converting a string to a number:");

            var numbers = new NumeralToNumberConverter().ToNumbers(Console.ReadLine());

            Console.WriteLine($"Result: {numbers}");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static string FormatInput(IEnumerable<int> input)
        {
            _sb.Clear();
            _sb.Append("Recognised input: ");

            foreach (var item in input)
            {
                _sb.Append(item);
                _sb.Append(", ");
            }

            var result = _sb.ToString();
            return result.Remove(result.Length - ", ".Length);
        }

        private static string FormatOutput(IEnumerable<string> output)
        {
            _sb.Clear();
            _sb.Append("Output: ");

            foreach (var item in output)
            {
                _sb.Append(item);
                _sb.Append(", ");
                _sb.Append(Environment.NewLine);
            }

            var result = _sb.ToString().Trim();
            return result.Remove(result.Length - ",".Length);
        }
    }
}

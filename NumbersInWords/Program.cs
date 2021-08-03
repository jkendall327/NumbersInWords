using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersInWords
{
    class Program
    {
        // https://codingdojo.org/kata/NumbersInWords/
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers => words converter");

            if (args.Length < 1)
            {
                Console.WriteLine("No command-line arguments found. Using example data.");
                args = new[] { "34", "-11", "12341444" };
            }

            var validatedArgs = ValidateArgs(args);

            if (!validatedArgs.Any())
            {
                Console.WriteLine("No valid arguments found, exiting.");
                Console.ReadLine();
                Environment.Exit(1);
            }

            Console.WriteLine(Format(validatedArgs, "Recognised input"));

            var output = new NumberToNumeralConverter().ToWords(validatedArgs);

            Console.WriteLine(Format(output, "Output"));

            Console.WriteLine("Try converting a string to a number:");

            try
            {
                var numbers = new NumeralToNumberConverter().ToNumbers(Console.ReadLine());
                Console.WriteLine($"Result: {numbers}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static IEnumerable<int> ValidateArgs(string[] args)
        {
            foreach (var item in args)
            {
                if (int.TryParse(item, out int result))
                {
                    yield return result;
                }
            }
        }

        private readonly static StringBuilder _sb = new();

        private static string Format<T>(IEnumerable<T> output, string message)
        {
            _sb.Clear();
            _sb.Append($"{message}: " + Environment.NewLine);

            foreach (var item in output)
            {
                _sb.Append(item);
                _sb.Append(", ");
                _sb.Append(Environment.NewLine);
            }

            var result = _sb.ToString().TrimEnd();
            return result.Remove(result.Length - ",".Length);
        }
    }
}

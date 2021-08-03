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
                Console.WriteLine("Usage: input each number to convert separated by spaced.");
                Console.WriteLine("Example: 'NumbersInWords.exe 34 12 2 8' => 'thirty-four', 'twelve', 'two', 'eight'");
                Console.ReadLine();
                return;
            }

            var input = ArgsValidator.Validate(args);

            Console.WriteLine(FormatInput(input));

            var converter = new NumberToNumeralConverter();
            var output = converter.ToWords(input);

            Console.WriteLine(FormatOutput(output));

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
            }

            var result = _sb.ToString().Trim();
            return result.Remove(result.Length - ",".Length);
        }
    }
}

using System;
using System.Collections.Generic;

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
                Console.WriteLine("Usage: input each number to convert separated by spaced.");
                Console.WriteLine("Example: 'NumbersInWords.exe 34 12 2 8' => 'thirty-four', 'twelve', 'two', 'eight'");
                Console.ReadLine();
                return;
            }

            var input = ArgsValidator.Validate(args);

            PrintAllInput(input);

            var converter = new NumberToNumeralConverter();

            var output = converter.ToWords(input);

            PrintAllOutput(output);

            Console.WriteLine("Exiting...");
            Console.ReadLine();
        }

        private static void PrintAllInput(IEnumerable<int> input)
        {
            throw new NotImplementedException();
        }

        private static void PrintAllOutput(IEnumerable<string> output)
        {
            throw new NotImplementedException();
        }
    }
}

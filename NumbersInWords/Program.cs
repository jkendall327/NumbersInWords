using System;

namespace NumbersInWords
{
    class Program
    {
        // https://codingdojo.org/kata/NumbersInWords/
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers => words converter");

            var validator = new ArgsValidator();

            var input = ArgsValidator.Validate(args);
        }
    }
}

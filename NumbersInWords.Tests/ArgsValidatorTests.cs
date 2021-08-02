using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NumbersInWords.Tests
{
    public class ArgsValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnEmptyList_WhenInputIsEmpty()
        {
            var input = Array.Empty<string>();

            var actual = ArgsValidator.Validate(input);

            actual.Should().BeEmpty("because no strings were passed in");
        }

        [Fact]
        public void Validate_ShouldReturnCorrectValues_WhenInputIsWellFormed()
        {
            var input = new string[] { "4", "2", "49" };

            var expected = new List<int>() { 4, 2, 49 };

            var actual = ArgsValidator.Validate(input);

            actual.Should().BeEquivalentTo(expected, "because all inputs are valid");
        }

        [Fact]
        public void Validate_ShouldOmitValues_WhenNotWellFormed()
        {
            var input = new string[] { "4", "test", "49" };

            var expected = new List<int>() { 4, 49 };

            var actual = ArgsValidator.Validate(input);

            actual.Should().BeEquivalentTo(expected, "because some input was invalid");
        }
    }
}

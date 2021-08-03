using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NumbersInWords.Tests
{
    public class NumberNumeralConvertorTests
    {
        private readonly NumberToNumeralConverter _sut = new();

        [Fact]
        public void ToWords_ShouldReturnEmptyList_WhenInputIsEmpty()
        {
            var input = Array.Empty<int>();

            var actual = _sut.ToWords(input);

            actual.Should().BeEmpty("because no values were passed in");
        }

        [InlineData(0, "zero")]
        [InlineData(1, "one")]
        [InlineData(-23, "minus twenty-three")]
        [InlineData(200, "two hundred")]
        [InlineData(1000, "one thousand")]
        [InlineData(5_000_000, "five million")]
        [InlineData(234_000_654, "two hundred and thirty-four million, six hundred and fifty-four")]
        [InlineData(454, "four hundred and fifty-four")]
        [InlineData(int.MaxValue, "two billion, one hundred and forty-seven million, four hundred and eighty-three thousand, six hundred and forty-seven")]
        [InlineData(int.MinValue, "minus two billion, one hundred and forty-seven million, four hundred and eighty-three thousand, six hundred and forty-eight")]
        [Theory]
        public void ToWords_ShouldReturnCorrectNumeral_ForSingleValue(int value, string expected)
        {
            var actual = _sut.ToWords(value);

            actual.Should().BeEquivalentTo(expected, "because a valid value was passed in");
        }

        [Fact]
        public void ToWords_ShouldReturnCorrectNumerals_ForMultipleValues()
        {
            var input = new[] { 5, 17, -8923, 139_729 };

            var expected = new List<string>()
            {
                "five",
                "seventeen",
                "minus eight thousand, nine hundred and twenty-three",
                "one hundred and thirty-nine thousand, seven hundred and twenty-nine"
            };

            var actual = _sut.ToWords(input);

            actual.Should().BeEquivalentTo(expected, "because valid values were passed in");
        }

        [Fact]
        public void ToWords_ShouldNotThrowException_WhenGivenIntMinValue()
        {
            _sut
                .Invoking(c => c.ToWords(int.MinValue))
                .Should()
                .NotThrow("because the specific case is handled");
        }
    }
}

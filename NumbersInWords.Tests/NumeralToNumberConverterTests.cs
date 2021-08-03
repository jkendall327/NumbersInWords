using FluentAssertions;
using Xunit;

namespace NumbersInWords.Tests
{
    public class NumeralToNumberConverterTests
    {
        readonly NumeralToNumberConverter _sut = new();

        [InlineData("zero", 0)]
        [InlineData("one", 1)]
        [InlineData("minus twenty-three", -23)]
        [InlineData("two hundred and thirty-four million six hundred and fifty-four", 234_000_654)]
        [InlineData("four hundred and fifty-four", 454)]
        [InlineData("two thousand one hundred and forty-seven million four hundred and eighty-three thousand six hundred and forty-seven", int.MaxValue)]
        [InlineData("minus two thousand one hundred and forty-seven million four hundred and eighty-three thousand six hundred and forty-seven", int.MinValue)]
        [InlineData("three thousand one hundred and forty-seven million four hundred and eighty-three thousand six hundred and forty-seven", int.MaxValue)] // overflow
        [InlineData("minus three thousand one hundred and forty-seven million four hundred and eighty-three thousand six hundred and forty-seven", int.MinValue)] // negative overflow
        [Theory]
        public void ToNumbers_ShouldReturnCorrectNumber_ForSingleValue(string value, int expected)
        {
            var actual = _sut.ToNumbers(value);

            actual.Should().Be(expected, "because a valid value was passed in");
        }
    }
}

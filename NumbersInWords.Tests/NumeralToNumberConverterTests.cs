using FluentAssertions;
using Xunit;

namespace NumbersInWords.Tests
{
    public class NumeralToNumberConverterTests
    {
        readonly NumeralToNumberConverter _sut = new();

        [InlineData("zero", 0)]
        [InlineData("one", 1)]
        [InlineData("twenty-three", 23)]
        [InlineData("minus twenty-three", -23)]
        [InlineData("four hundred and fifty-four", 454)]
        [InlineData("one thousand", 1000)]
        [InlineData("two hundred and thirty-four million six hundred and fifty-four", 234_000_654)]
        [InlineData("three billion two hundred and thirty-four million six hundred and fifty-four", int.MaxValue)]
        [InlineData("minus three billion two hundred and thirty-four million six hundred and fifty-four", int.MinValue)]
        [Theory]
        public void ToNumbers_ShouldReturnCorrectNumber_ForSingleValue(string value, int expected)
        {
            var actual = _sut.ToNumbers(value);

            actual.Should().Be(expected, "because a valid value was passed in");
        }
    }
}

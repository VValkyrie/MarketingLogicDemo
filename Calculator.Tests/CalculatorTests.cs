using Xunit;
using FluentAssertions;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ItShouldCalculateModule256Sum()
        {
            //arrange
            byte[] args = new byte[] { 255, 255 };

            //act
            byte result = Calculator.Calculate(OperationType.Sum, args);

            //assert
            result.Should().Be(254);
        }

        [Fact]
        public void ItShouldCalculateModule256Multiplication()
        {
            //arrange
            byte[] args = new byte[] { 7, 7, 7 };

            //act
            byte result = Calculator.Calculate(OperationType.Multiplication, args);

            //assert
            result.Should().Be(87);
        }

        [Fact]
        public void ItShouldSearchMaxElement()
        {
            //arrange
            byte[] args = new byte[] { 1, 100, 7 };

            //act
            byte result = Calculator.Calculate(OperationType.Max, args);

            //assert
            result.Should().Be(100);
        }

        [Fact]
        public void ItShouldSearchMinElement()
        {
            //arrange
            byte[] args = new byte[] { 1, 100, 7 };

            //act
            byte result = Calculator.Calculate(OperationType.Min, args);

            //assert
            result.Should().Be(1);
        }

        [Fact]
        public void ItShouldSearchMedianForArrayWithOddNumberOfElements()
        {
            //arrange
            byte[] args = new byte[] { 1, 100, 7, 45, 4 };

            //act
            byte result = Calculator.Median(args);

            //assert
            result.Should().Be(7);
        }
    }
}

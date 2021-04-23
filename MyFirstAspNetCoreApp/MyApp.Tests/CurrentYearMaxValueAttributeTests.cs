using MyFirstAspNetCoreApp.ValidatioAttributes;
using System;
using Xunit;

namespace MyApp.Tests
{
    public class CurrentYearMaxValueAttributeTests
    {
        [Fact]
        public void IsValidReturnsFalseForDateTimefterCurrentYear()
        {
            //Arrange
            var attribute = new CurrentYearMaxValueAttribute(1990);
            //Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1));
            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsFalseForYearsAfterCurrentYear()
        {
            //Arrange
            var attribute = new CurrentYearMaxValueAttribute(1990);
            //Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1).Year);
            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsTrueForYearsBeforeCurrentYear()
        {
            // Arange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(-1).Year);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidReturnsTrueForDateTimeBeforeCurrentYear()
        {
            //Arrange
            var attribute = new CurrentYearMaxValueAttribute(1990);
            //Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(-1));
            //Assert
            Assert.True(isValid);
        }
    }
}


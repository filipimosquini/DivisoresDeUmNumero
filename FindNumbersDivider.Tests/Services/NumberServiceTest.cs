using FindNumbersDivider.Domain.Services;
using FluentAssertions;
using KellermanSoftware.CompareNetObjects;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FindNumbersDivider.Tests.Services
{
    [Trait("Service Tests", "NumberService")]
    public class NumberServiceTest
    {
        private readonly CompareLogic _comparator = new CompareLogic();

        [Fact(DisplayName = "On_CalculatePrimeNumbers_ShouldExecuteWithoutErrors")]
        public void On_CalculatePrimeNumbers_ShouldExecuteWithoutErrors()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<NumberService>();

            var expectedResult = new List<int>() { 2, 3, 5, 7 };

            // Act
            var result = appService.CalculatePrimeNumbers(10);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }

        [Fact(DisplayName = "On_DecomposesNumberIntoPrimeFactors_ShouldExecuteWithoutErrors")]
        public async Task On_DecomposesNumberIntoPrimeFactors_ShouldExecuteWithoutErrors()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<NumberService>();

            var expectedResult = new List<int>() { 1, 2, 5 };

            // Act
            var result = await appService.DecomposesNumberIntoPrimeFactors(10);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }

        [Fact(DisplayName = "On_DecomposesNumberIntoPrimeFactors_ShouldNotExecuteIfExistOnlyNumberOneIntoPrimefactorsList")]
        public async Task On_DecomposesNumberIntoPrimeFactors_ShouldNotExecuteIfExistOnlyNumberOneIntoPrimefactorsList()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<NumberService>();

            var expectedResult = new List<int>() { 1 };

            // Act
            var result = await appService.DecomposesNumberIntoPrimeFactors(1);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }

        [Fact(DisplayName = "On_FindDividers_ShouldExecuteWithoutErrors")]
        public async Task On_FindDividers_ShouldExecuteWithoutErrors()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<NumberService>();

            var primeFactors = new List<int>() { 1, 2, 5 };

            var expectedResult = new List<int>() { 1, 2, 5, 10 };

            // Act
            var result = await appService.FindDividers(primeFactors);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }

        [Fact(DisplayName = "On_ExtractPrimeNumbersOfDividersList_ShouldExecuteWithoutErrors")]
        public async Task On_ExtractPrimeNumbersOfDividersList_ShouldExecuteWithoutErrors()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<NumberService>();

            var dividers = new List<int>() { 1, 2, 5, 10 };

            var expectedResult = new List<int>() { 1, 2, 5 };

            // Act
            var result = await appService.ExtractPrimeNumbersOfDividersList(dividers);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }
    }
}
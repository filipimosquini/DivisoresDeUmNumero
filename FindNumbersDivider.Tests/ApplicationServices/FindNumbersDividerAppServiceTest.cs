using FindNumbersDivider.Application;
using FindNumbersDivider.CrossCutting.Application;
using FindNumbersDivider.Domain.Entities;
using FindNumbersDivider.Domain.Responses;
using FindNumbersDivider.Domain.Services.Interface;
using FluentAssertions;
using KellermanSoftware.CompareNetObjects;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FindNumbersDivider.Tests.ApplicationServices
{
    [Trait("Application Service Tests", "FindNumbersDividerAppService")]
    public class FindNumbersDividerAppServiceTest
    {
        private readonly CompareLogic _comparator = new CompareLogic();

        [Fact(DisplayName = "On_FindDividersAccordingToNumber_ShouldFindWithoutErrors")]
        public async Task On_FindDividersAccordingToNumber_ShouldFindWithoutErrors()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<FindNumbersDividerAppService>();
            var service = mocker.GetMock<INumberService>();

            var primeFactors = new List<int>() { 1, 2, 5 };
            service
                .Setup(s => s.DecomposesNumberIntoPrimeFactors(10))
                .ReturnsAsync(primeFactors)
                .Verifiable();

            var dividers = new List<int>() { 1, 2, 5, 10 };
            service
                .Setup(s => s.FindDividers(primeFactors))
                .ReturnsAsync(dividers)
                .Verifiable();

            var primeDividers = new List<int>() { 1, 2, 5 };
            service
                .Setup(s => s.ExtractPrimeNumbersOfDividersList(dividers))
                .ReturnsAsync(primeDividers)
                .Verifiable();

            var expectedResult = new GenericResponse
            {
                Success = true,
                Message = "Divisores calculados com sucesso",
                Data = new NumberResponse
                {
                    Number = 10,
                    Dividers = dividers,
                    PrimeDividers = primeDividers
                }
            };

            // Act
            var result = await appService.FindDividersAccordingToNumber(10);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }

        [Fact(DisplayName = "On_FindDividersAccordingToNumber_ShouldFindWithErrors")]
        public async Task On_FindDividersAccordingToNumber_ShouldFindWithErrors()
        {
            // Arrange
            var mocker = new AutoMocker();
            var appService = mocker.CreateInstance<FindNumbersDividerAppService>();

            var algarism = new Number(-1);

            var expectedResult = new GenericResponse
            {
                Success = false,
                Message = "Erro ao calcular os divisores",
                Data = new ErrorResponse
                {
                    Errors = algarism.Notifications.Select(s => s.Message)
                }
            };

            // Act
            var result = await appService.FindDividersAccordingToNumber(-1);

            // Assert
            _comparator.Compare(expectedResult, result).AreEqual.Should().BeTrue();
            mocker.Verify();
        }
    }
}
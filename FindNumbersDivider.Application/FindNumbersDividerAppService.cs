using FindNumbersDivider.Application.Interfaces;
using FindNumbersDivider.CrossCutting.Application;
using FindNumbersDivider.Domain.Entities;
using FindNumbersDivider.Domain.Responses;
using FindNumbersDivider.Domain.Services.Interface;
using System.Threading.Tasks;

namespace FindNumbersDivider.Application
{
    public class FindNumbersDividerAppService : IFindNumbersDividerAppService
    {
        private readonly INumberService _numberService;

        public FindNumbersDividerAppService(INumberService numberService)
        {
            _numberService = numberService;
        }

        public async Task<GenericResponse> FindDividersAccordingToNumber(int number)
        {
            var algarism = new Number(algarism: number);

            if (!algarism.IsValid)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "Erro ao calcular os divisores",
                    Data = algarism.Notifications
                };
            }

            var primeFactors = await _numberService.DecomposesNumberIntoPrimeFactors(number);
            var dividers = await _numberService.FindDividers(primeFactors);
            var primeDividers = await _numberService.ExtractPrimeNumbersOfDividersList(dividers);

            return new GenericResponse
            {
                Success = true,
                Message = "Divisores calculados com sucesso",
                Data = new NumberResponse
                {
                    Number = number,
                    Dividers = dividers,
                    PrimeDividers = primeDividers
                }
            };
        }
    }
}
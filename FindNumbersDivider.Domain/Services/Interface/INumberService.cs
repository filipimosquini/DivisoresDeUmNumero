using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindNumbersDivider.Domain.Services.Interface
{
    public interface INumberService
    {
        /// <summary>
        /// Decomposes a number into prime factors
        /// </summary>
        /// <param name="number"></param>
        /// <returns> List of prime factors </returns>
        /// <remarks> reference: https://www.somatematica.com.br/fundam/divisor.php </remarks>
        Task<List<int>> DecomposesNumberIntoPrimeFactors(int number);

        /// <summary>
        /// Find dividers addording to prime factors list
        /// </summary>
        /// <param name="primeFactors"></param>
        /// <returns> Dividers list </returns>
        /// <remarks> reference: https://www.somatematica.com.br/fundam/divisor.php </remarks>
        /// <remarks> reference: https://www.somatematica.com.br/dicionarioMatematico/m.php </remarks>
        Task<List<int>> FindDividers(List<int> primeFactors);

        /// <summary>
        /// Extract prime numbers from list of dividers
        /// </summary>
        /// <param name="dividers"></param>
        /// <returns> Prime numbers List </returns>
        /// <remarks> reference: https://pt.wikipedia.org/wiki/Crivo_de_Erat%C3%B3stenes </remarks>
        Task<List<int>> ExtractPrimeNumbersOfDividersList(List<int> dividers);
    }
}
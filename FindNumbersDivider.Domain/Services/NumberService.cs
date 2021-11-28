using FindNumbersDivider.Domain.Services.Interface;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindNumbersDivider.Domain.Services
{
    public class NumberService : Notifiable<Notification>, INumberService
    {
        /// <summary>
        /// Creates a list of prime numbers according to a number
        ///
        /// This method is virtual for test coverage purposes. It should not be considered a service method.
        ///
        /// </summary>
        /// <param name="number"></param>
        /// <returns>List of prime numbers</returns>
        /// <remarks> reference: https://pt.wikipedia.org/wiki/Crivo_de_Erat%C3%B3stenes </remarks>
        public virtual IEnumerable<int> CalculatePrimeNumbers(int number)
        {
            var sqrt = Math.Floor(Math.Sqrt(number));

            var numbers = Enumerable.Range(2, number - 1).ToList();

            var index = 0; var value = 0;

            do
            {
                value = numbers[index];
                numbers.RemoveAll(numero => numero % value == 0
                               && numero != value);
                index++;
            }
            while (value <= sqrt);

            return numbers;
        }

        /// <summary>
        /// Decomposes a number into prime factors
        /// </summary>
        /// <param name="number"></param>
        /// <returns> List of prime factors </returns>
        /// <remarks> reference: https://www.somatematica.com.br/fundam/divisor.php </remarks>
        public Task<List<int>> DecomposesNumberIntoPrimeFactors(int number)
        {
            var primeFactors = new List<int>() { 1 };
            var primeNumbers = CalculatePrimeNumbers(number).ToArray();

            var index = 0; var result = number;

            do
            {
                if (result % primeNumbers[index] == 0)
                {
                    result = result / primeNumbers[index];
                    primeFactors.Add(primeNumbers[index]);
                }
                else
                {
                    index++;
                }
            } while (result != 1);

            return Task.FromResult(primeFactors);
        }

        /// <summary>
        /// Find dividers addording to prime factors list
        /// </summary>
        /// <param name="primeFactors"></param>
        /// <returns> Dividers list </returns>
        /// <remarks> reference: https://www.somatematica.com.br/fundam/divisor.php </remarks>
        /// <remarks> reference: https://www.somatematica.com.br/dicionarioMatematico/m.php </remarks>
        public Task<List<int>> FindDividers(List<int> primeFactors)
        {
            // list of dividers started by number one
            var dividers = new List<int>() { 1 };

            var multiplying = 0; var multiplier = 0;
            var quantityOfDividers = 0;

            // To find all the divisors of a number we must multiply each prime factor by the numbers in the list of divisors.
            do
            {
                quantityOfDividers = dividers.Count;
                do
                {
                    dividers.Add(primeFactors.ElementAt(multiplying) * dividers.ElementAt(multiplier));
                    multiplier++;
                } while (multiplier < quantityOfDividers);

                multiplier = 0;
                multiplying++;
            } while (multiplying < primeFactors.Count);

            // On final of process are removed duplicate values from list of dividers
            dividers = dividers.Distinct().OrderBy(numbers => numbers).ToList();

            return Task.FromResult(dividers);
        }

        /// <summary>
        /// Extract prime numbers from list of dividers
        /// </summary>
        /// <param name="dividers"></param>
        /// <returns> Prime numbers List </returns>
        /// <remarks> reference: https://pt.wikipedia.org/wiki/Crivo_de_Erat%C3%B3stenes </remarks>
        public Task<List<int>> ExtractPrimeNumbersOfDividersList(List<int> dividers)
        {
            var primes = new List<int>();

            primes.AddRange(dividers);

            var index = 0; var value = 0;
            do
            {
                value = primes[index];
                primes.RemoveAll(numero => numero % value == 0
                               && numero != value
                               && value != 0
                               && value != 1);
                index++;
            }
            while (index < primes.Count);

            return Task.FromResult(primes);
        }
    }
}
using FindNumbersDivider.Application.Interfaces;
using FindNumbersDivider.Domain.Responses;
using FindNumbersDivider.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DivisoresDeUmNumero
{
    internal class Program
    {
        private static IFindNumbersDividerAppService _findNumbersDividerAppService;

        private static void Welcome()
        {
            Console.WriteLine(@"
                                ______                  _   _ _           _       _
                                | ___ \                | | | (_)         | |     | |
                                | |_/ / ___ _ __ ___   | | | |_ _ __   __| | ___ | |
                                | ___ \/ _ \ '_ ` _ \  | | | | | '_ \ / _` |/ _ \| |
                                | |_/ /  __/ | | | | | \ \_/ / | | | | (_| | (_) |_|
                                \____/ \___|_| |_| |_|  \___/|_|_| |_|\__,_|\___/(_)

                               ");
        }

        private static async Task<bool> Menu()
        {
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine(@"

Pressione qualquer tecla para sair ou
Pressione * 1 * para calcular os divisores de um número!

");

            Console.WriteLine("-------------------------------------------------------");

            switch (Console.ReadLine())
            {
                case "1":

                    Console.Clear();

                    Console.WriteLine("Informe um número para obter seus divisores: ");

                    var evaluateData = new Regex(@"^\d+$").Match(Console.ReadLine());

                    if (evaluateData.Success)
                    {
                        int number = Convert.ToInt32(Console.ReadLine());

                        await CalculateNumberDividers(number);
                    }
                    else
                    {
                        Console.WriteLine(@"
    Número inválido!
                                         ");
                    }

                    return true;

                default:

                    return false;
            }
        }

        private static async Task CalculateNumberDividers(int number)
        {
            var result = await _findNumbersDividerAppService.FindDividersAccordingToNumber(number);

            if (!result.Success)
            {
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine($"Erros: {string.Join(", ", ((ErrorResponse)result.Data).Errors.Select(s => s))}");
            }

            if (result.Success)
            {
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine($"Número: {string.Join(", ", ((NumberResponse)result.Data).Number)}");

                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine($"Divisores: {string.Join(", ", ((NumberResponse)result.Data).Dividers.Select(s => s))}");

                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine($"Divisores Primos: {string.Join(", ", ((NumberResponse)result.Data).PrimeDividers.Select(s => s))}");
            }
        }

        private static async Task Main(string[] args)
        {
            // The ideal is to obtain the ServiceCollection by dependency injection,
            // but it was not possible because the execution calls the main method
            // and not the class's constructor.
            var _serviceCollection = new ServiceCollection();

            // Solve dependencies
            _serviceCollection.SolveDependencies();

            _findNumbersDividerAppService = _serviceCollection
                .BuildServiceProvider()
                .CreateScope()
                .ServiceProvider
                .GetService<IFindNumbersDividerAppService>();

            if (_findNumbersDividerAppService is null)
            {
                Console.WriteLine("Erro inesperado! Pressione qualquer tecla!");
                Console.ReadKey();
            }

            Welcome();

            var showMenu = true;
            while (showMenu)
            {
                showMenu = await Menu();
            }
        }
    }
}
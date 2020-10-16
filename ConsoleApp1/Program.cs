using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {       
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ILogMessage, LogMessage>()
            .AddScoped<IRandomGenerator, RandomGenerator>()
            .BuildServiceProvider();

            var _logger =  serviceProvider
           .GetService<ILogMessage>();

            _logger.DisplayMessage("Enter the number of overs.");
            int totalOvers = Convert.ToInt32(Console.ReadLine());

            _logger.DisplayMessage("Enter the target score.");
            int targetScore = Convert.ToInt32(Console.ReadLine());

            Match.GetMatchResults(serviceProvider, totalOvers, targetScore);          
        }
    }
}


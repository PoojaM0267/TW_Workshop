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

            GetTotalScore(serviceProvider, totalOvers, targetScore);            
        }

        public static void GetTotalScore(ServiceProvider serviceProvider, int totalOvers, int targetScore)
        {
            var _rndGenerator = serviceProvider
          .GetService<IRandomGenerator>();

            var _logger = serviceProvider
          .GetService<ILogMessage>();

            var totalScore = 0;

            for (int i = 0; i < totalOvers*6; i++)
            {
                var bowlerScore = _rndGenerator.GenerateRandomScore(7);
                var batsmanScore = _rndGenerator.GenerateRandomScore(7);

                _logger.DisplayInlineMessage("Batsman: " + batsmanScore + " ");
                _logger.DisplayInlineMessage("Bowler: " + bowlerScore + " ");
                _logger.DisplayMessage("");

                if (bowlerScore == batsmanScore)
                {
                    _logger.DisplayMessage("Batsman has lost.");
                    return;
                }

                totalScore = totalScore + batsmanScore;
                if (CheckTarget(totalScore, targetScore))
                {
                    _logger.DisplayMessage("Batsman has won.");
                }               
            }

            if (CheckTarget(totalScore, targetScore))
            {
                _logger.DisplayMessage("Batsman has won.");
            }
            else
            {
                _logger.DisplayMessage("Batsman has lost");
            }
        }

        public static bool CheckTarget(int totalScore, int targetScore)
        {
            return totalScore >= targetScore;
        }

    }
}


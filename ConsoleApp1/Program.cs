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
            .BuildServiceProvider();

            var _logger =  serviceProvider
           .GetService<ILogMessage>();

            Console.WriteLine("Enter the target score.");
            int targetScore = Convert.ToInt32(Console.ReadLine());                   

            if(GetTotalScore() >= targetScore)
            {
                _logger.DisplayMessage("Batsman has won.");
            }
            else
            {
                _logger.DisplayMessage("Batsman has lost");
            }
        }

        public static int GetTotalScore()
        {
            Random rnd = new Random();
            var totalScore = 0;

            Console.Write("Batsman : ");

            for (int i = 0; i < 6; i++)
            {
                var score = rnd.Next(7);
                totalScore = totalScore + score;
                Console.Write(score + " ");
            }

            return totalScore;
        }
    }
}

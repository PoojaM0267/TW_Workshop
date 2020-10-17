﻿using ConsoleApp1.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    public static class Match
    {
        public static bool GetMatchResults(ServiceProvider serviceProvider, int totalOvers, int targetScore)
        {
            var _logger = serviceProvider
          .GetService<ILogMessage>();

            var currentTotalScore = 0;

            BatsmanFactory factory = new ConcreteBatsmanFactory();
            ScoreFactory scfactory = new ConcreteScoreFactory();

            for (int i = 0; i < totalOvers * 6; i++)
            {
                var bowlerScore = Utility.GenerateRandomScore(1, 7);

                var batsmanScoringType = Utility.GenerateRandomScore(0, 3);

                var score = scfactory.GetScore(batsmanScoringType);

                _logger.DisplayInlineMessage("Batsman: " + score + " ");
                _logger.DisplayInlineMessage("Batsman Type: " + batsmanScoringType + " ");
                _logger.DisplayInlineMessage("Bowler: " + bowlerScore + " ");
                _logger.DisplayMessage("");

                if (bowlerScore == score)
                {
                    return false;
                }

                currentTotalScore = currentTotalScore + score;
                if (CheckTarget(currentTotalScore, targetScore))
                {
                    return true;
                }
            }

            return CheckTarget(currentTotalScore, targetScore);
        }

        public static bool CheckTarget(int currentTotalScore, int targetScore)
        {
            return currentTotalScore >= targetScore;
        }
    }
}

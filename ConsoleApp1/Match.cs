﻿using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    public static class Match
    {
        public static bool GetMatchResults(ServiceProvider serviceProvider, int totalOvers, int targetScore)
        {
            var _logger = serviceProvider
          .GetService<ILogMessage>();

            var currentTotalScore = 0;           
            ScoreFactory scfactory = new ConcreteScoreFactory();           

            for (int i = 0; i < totalOvers * 6; i++)
            {
                // get bowler details             
                var bowlerRandomTypeId = Utility.GenerateRandomScore(0, 2);
                var bowlerScore = Utility.GenerateRandomScore(1, 7);

                // get batsman and score details
                var batsmanScoringType = Utility.GenerateRandomScore(0, 3);
                var batsmanScore = scfactory.GetScore(batsmanScoringType);

                DisplayConsoleMessages(_logger, batsmanScore, batsmanScoringType, bowlerScore, bowlerRandomTypeId);                

                // To get a batsman out, it has to be a normal bowler
                if (bowlerRandomTypeId != (int)BowlerTypes.PartTime)
                {
                    if (bowlerScore == batsmanScore)
                    {
                       return false;
                    }

                    if (batsmanScoringType == (int)BatsmanType.TailEnd)
                    {
                        if ((bowlerScore % 2 == batsmanScore % 2))
                        {
                            return false;
                        }
                    }

                    currentTotalScore = currentTotalScore + batsmanScore;
                }
                else
                {
                    if (bowlerScore != batsmanScore)
                    {
                        currentTotalScore = currentTotalScore + batsmanScore;
                    }
                }

                // check for target
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

        public static void DisplayConsoleMessages(ILogMessage _logger, int score, int batsmanScoringType, int bowlerScore, int bowlerRandomTypeId)
        {
            _logger.DisplayInlineMessage("Batsman Score: " + score + " ");
            _logger.DisplayInlineMessage("Batsman Type: " + batsmanScoringType + " ");
            _logger.DisplayMessage("");
            _logger.DisplayInlineMessage("Bowler Score: " + bowlerScore + " ");
            _logger.DisplayInlineMessage("Bowler Type Id: " + bowlerRandomTypeId + " ");
            _logger.DisplayMessage("");
        }
    }
}

using ConsoleApp1.Models;
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
            BatsmanFactory btfactory = new ConcreteBatsmanFactory();

            for (int i = 0; i < totalOvers * 6; i++)
            {
                // get bowler details             
                var bowlerRandomTypeId = Utility.GenerateRandomScore(0, 2);
                var bowlerScore = Utility.GenerateRandomScore(1, 7);

                // get batsman and score details
                var batsmanType = Utility.GenerateRandomScore(0, 4);
                IBatsman btm = btfactory.GetBatsman(batsmanType);
                var batsmanScore = btm.GetBatsmanScore();

                DisplayConsoleMessages(_logger, batsmanScore, batsmanType, bowlerScore, bowlerRandomTypeId);                

                if (bowlerRandomTypeId != (int)BowlerType.PartTime)
                {
                    if (bowlerScore == batsmanScore)
                    {
                       return false;
                    }

                    currentTotalScore = currentTotalScore + batsmanScore;
                }

                if(batsmanType == (int)BatsmanType.TailEnd)
                {
                    if((bowlerScore % 2 == batsmanScore % 2))
                    {
                        return false;
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

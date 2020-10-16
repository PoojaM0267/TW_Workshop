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

            BatsmanFactory factory = new ConcreteBatsmanFactory();

            for (int i = 0; i < totalOvers * 6; i++)
            {
                var bowlerScore = Utility.GenerateRandomScore(1, 7);

                var batsmanType = Utility.GenerateRandomScore(0, 3);

                IBatsman btm = factory.GetBatsman(batsmanType);
                var batsmanScore = btm.GetBatsmanScore();

                _logger.DisplayInlineMessage("Batsman: " + batsmanScore + " ");
                _logger.DisplayInlineMessage("Batsman Type: " + batsmanType + " ");
                _logger.DisplayInlineMessage("Bowler: " + bowlerScore + " ");
                _logger.DisplayMessage("");

                if (bowlerScore == batsmanScore)
                {
                    return false;
                }

                currentTotalScore = currentTotalScore + batsmanScore;
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

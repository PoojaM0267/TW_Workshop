using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    public static class Match
    {
        public static void GetMatchResults(ServiceProvider serviceProvider, int totalOvers, int targetScore)
        {
            var _logger = serviceProvider
          .GetService<ILogMessage>();

            var totalScore = 0;

            for (int i = 0; i < totalOvers * 6; i++)
            {
                var bowlerScore = Utility.GenerateRandomScore(1, 7);
                var batsmanScore = Utility.GenerateRandomScore(7);

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
                    return;
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

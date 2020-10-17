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

            //BatsmanFactory factory = new ConcreteBatsmanFactory();
            ScoreFactory scfactory = new ConcreteScoreFactory();
            BowlerFactory bwlfactory = new ConcreteBowlerFactory();

            for (int i = 0; i < totalOvers * 6; i++)
            {
                // get bowler details             
                var bowlerRandomTypeId = Utility.GenerateRandomScore(0, 2);
                var bowler = bwlfactory.GetBowler(bowlerRandomTypeId);               
                var bowlerTypeId = bowler.GetBowlerType();

                var bowlerScore = Utility.GenerateRandomScore(1, 7);

                // get batsman and score details
                var batsmanScoringType = Utility.GenerateRandomScore(0, 3);
                var score = scfactory.GetScore(batsmanScoringType);

                _logger.DisplayInlineMessage("Batsman Score: " + score + " ");
                _logger.DisplayInlineMessage("Batsman Type: " + batsmanScoringType + " ");
                _logger.DisplayMessage("");
                _logger.DisplayInlineMessage("Bowler Score: " + bowlerScore + " ");
                _logger.DisplayInlineMessage("Bowler Type Id: " + bowlerTypeId + " ");
                _logger.DisplayMessage("");

                if (bowlerTypeId != (int)BowlerTypes.PartTime)
                {
                    if (bowlerScore == score)
                    {
                       return false;
                    }

                    currentTotalScore = currentTotalScore + score;
                }

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

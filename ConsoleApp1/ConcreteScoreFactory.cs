
namespace ConsoleApp1
{
    class ConcreteScoreFactory : ScoreFactory
    {
        public override int GetScore(int scoringStrategyId)
        {
            switch (scoringStrategyId)
            {
                case (int)ScoringStrategyId.Normal:
                    return Utility.GenerateRandomScore(7);
                case (int)ScoringStrategyId.Hit:
                    return Utility.GenerateBoundaryScore();
                case (int)ScoringStrategyId.Defensive:
                    return Utility.GenerateDefensiveScore();
                default:
                    return Utility.GenerateRandomScore(7);
            }
        }
    }
}

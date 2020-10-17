
namespace ConsoleApp1
{
    class ConcreteScoreFactory : ScoreFactory
    {
        public override int GetScore(int scoringStrategyId)
        {
            switch (scoringStrategyId)
            {
                case (int)BatsmanType.Normal:
                    return Utility.GenerateRandomScore(7);
                case (int)BatsmanType.Hit:
                    return Utility.GenerateBoundaryScore();
                case (int)BatsmanType.Defensive:
                    return Utility.GenerateDefensiveScore();
                case (int)BatsmanType.TailEnd:
                    return Utility.GenerateRandomScore(7);
                default:
                    return Utility.GenerateRandomScore(7);
            }
        }
    }
}

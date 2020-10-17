using System;

namespace ConsoleApp1
{
    public static class Utility
    {
        public static int GenerateRandomScore(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }

        public static int GenerateRandomScore(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public static int GenerateBoundaryScore()
        {
            int[] boundaryScores = new int[3] { 0, 4, 6 };
            Random rnd = new Random();
            return boundaryScores[rnd.Next(boundaryScores.Length)];
        }

        public static int GenerateDefensiveScore()
        {
            int[] defensiveScores = new int[4] { 0, 1, 2, 3 };
            Random rnd = new Random();
            return defensiveScores[rnd.Next(defensiveScores.Length)];
        }
    }

    public enum ScoringStrategyId
    {
        Normal,         // 0
        Hit,            // 1
        Defensive,      // 2       
    }

    public enum BowlerTypes
    {
        Normal,         // 0
        PartTime,       // 1
    }
}

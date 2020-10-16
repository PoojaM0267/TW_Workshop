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
    }
}

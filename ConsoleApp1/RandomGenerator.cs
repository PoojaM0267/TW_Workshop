using System;

namespace ConsoleApp1
{
    public class RandomGenerator : IRandomGenerator
    {
        public int GenerateRandomScore(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }

        public int GenerateRandomScore(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}


namespace ConsoleApp1.Models
{

    public interface IBatsman
    {
        int GetBatsmanScore();
    }
    public class Batsman : IBatsman
    {
        public int GetBatsmanScore()
        {
            return Utility.GenerateRandomScore(7);
        }
    }

    public class HitterBatsman : IBatsman
    {
        public int GetBatsmanScore()
        {
            return Utility.GenerateBoundaryScore();
        }
    }

    public class DefensiveBatsman : IBatsman
    {
        public int GetBatsmanScore()
        {
            return Utility.GenerateDefensiveScore();
        }
    }
}

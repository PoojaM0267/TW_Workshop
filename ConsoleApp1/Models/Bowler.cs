
namespace ConsoleApp1.Models
{
    public interface IBowler
    {
        int GetBowlerType();
    }

    public class NormalBowler : IBowler
    {
        public int GetBowlerType()
        {
            return 0;
        }

        public int GetBowlerScore()
        {
            return 0;
        }
    }

    public class PartTimeBowler : IBowler
    {
        public int GetBowlerType()
        {
            return 1;
        }

        public int GetBowlerScore()
        {
            return 0;
        }
    }
}

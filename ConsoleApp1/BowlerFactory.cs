using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public abstract class BowlerFactory
    {
        public abstract IBowler GetBowler(int bowlerType);
    }
}

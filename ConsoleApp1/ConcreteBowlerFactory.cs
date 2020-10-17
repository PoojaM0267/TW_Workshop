using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class ConcreteBowlerFactory : BowlerFactory
    {
        public override IBowler GetBowler(int bowlerType)
        {
            switch (bowlerType)
            {
                case 0:
                    return new NormalBowler();
                case 1:
                    return new PartTimeBowler();
                default:
                    return new NormalBowler();
            }
        }
    }
}

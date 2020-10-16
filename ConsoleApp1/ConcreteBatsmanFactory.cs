using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class ConcreteBatsmanFactory: BatsmanFactory
    {
        public override IBatsman GetBatsman(int type)
        {
            switch (type)
            {
                case 0:
                    return new Batsman();
                case 1:
                    return new HitterBatsman();
                case 2:
                    return new DefensiveBatsman();
                default:
                    return new Batsman();
            }
        }
    }
}

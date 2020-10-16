using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class ConcreteBatsmanFactory: BatsmanFactory
    {
        public override IBatsman GetScore(int type)
        {
            switch (type)
            {
                case 0:
                    return new Batsman();
                case 1:
                    return new HitterBatsman();
                default:
                    return new Batsman();
            }
        }
    }
}

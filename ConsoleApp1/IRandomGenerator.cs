
namespace ConsoleApp1
{
    public interface IRandomGenerator
    {
        int GenerateRandomScore(int max);
        int GenerateRandomScore(int min, int max);
    }
}


namespace ConsoleApp1.Models
{

    public interface IBatsman
    {
        int GetBatsmanScore();
    }
    public class Batsman : IBatsman
    {
        private int batsmanTypeId;

        public int BatsmanTypeId 
        {
            get { return batsmanTypeId; }  
            set { batsmanTypeId = 0; }  
        }

        public int GetBatsmanScore()
        {
            return Utility.GenerateRandomScore(7);
        }
    }

    public class HitterBatsman : IBatsman
    {

        private int batsmanTypeId;

        public int BatsmanTypeId
        {
            get { return batsmanTypeId; }
            set { batsmanTypeId = 1; }
        }

        public int GetBatsmanScore()
        {
            return Utility.GenerateBoundaryScore();
        }
    }


}

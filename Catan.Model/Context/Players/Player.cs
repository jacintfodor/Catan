using Catan.Model.Board;

namespace Catan.Model.Context.Players
{
    public class Player : IPlayer
    {
        private Goods _resources;
 
        public Goods AvailableResources { get { return _resources; } set { _resources = value; } }

        public Player()
        {
            _resources = new Goods();
        }

        public int CalculateScore()
        {
            return -1;
        }

        public int LengthOfLongestRoad()
        {
            return 4;
        }

        public int SizeOfArmy()
        {
            return 2;
        }

        public void AddResource(Goods resourcesToAdd)
        {
            _resources += resourcesToAdd;
        }

        public void ReduceResources(Goods resourcesToReduce)
        {
            _resources -= resourcesToReduce;
        }
    }
}

using Catan.Model.Board;

namespace Catan.Model.Context.Players
{
    public class Player : IPlayer
    {
        private Goods _resources;
 
        public Goods resources { get { return _resources; } set { _resources = value; } }

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

        public int sizeOfArmy()
        {
            return 2;
        }

        public void addResource(ResourceEnum resourceToAdd, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _resources = _resources + new Goods(resourceToAdd);
            }
        }

        public void reduceResources(Goods resourcesToReduce)
        {
            _resources = _resources - resourcesToReduce;
        }
    }
}

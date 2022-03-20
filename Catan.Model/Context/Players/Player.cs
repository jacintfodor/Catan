using Catan.Model.Board;

namespace Catan.Model.Context.Players
{
    public class Player : IPlayer
    {
        private List<int> _resources;
 
        public List<int> resources { get { return _resources; } set { _resources = value; } }

        public Player()
        {
            _resources = new List<int> { 0, 0, 0, 0, 0 };
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
            resources[(int)resourceToAdd] += amount;
        }

        //for buildings
        public void reduceResources(List<int> resourcesToReduce)
        {
            for (int i = 0; i < 5; i++)
            {
                resources[i] -= resourcesToReduce[i];
            }
        }
    }
}

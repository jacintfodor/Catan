using Catan.Model.Board;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        public void addResource(ResourceEnum resourceToAdd, int amount);

        public void reduceResources(Goods resourcesToReduce);

        public int CalculateScore();

        public int LengthOfLongestRoad();

        public int sizeOfArmy();

        public Goods resources { get; set; }

    }
}

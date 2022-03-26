using Catan.Model.Board;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        public string Name { get; set; }
        public void AddResource(Goods resourcesToAdd);

        public void ReduceResources(Goods resourcesToReduce);

        public int CalculateScore();

        public int LengthOfLongestRoad();

        public int SizeOfArmy();

        public Goods AvailableResources { get; set; }

        public bool CanAfford(Goods resourcesToAfford);

    }
}

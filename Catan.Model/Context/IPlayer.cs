using Catan.Model.Board;
using Catan.Model.Enums;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        public PlayerEnum ID { get; set; }
        public void AddResource(Goods resourcesToAdd);

        public void ReduceResources(Goods resourcesToReduce);

        public int CalculateScore();

        public int LengthOfLongestRoad();

        public int SizeOfArmy();

        public Goods AvailableResources { get; set; }

        public bool CanAfford(Goods resourcesToAfford);
        public bool CanAfford(Goods resourcesToAfford, String s);

    }
}

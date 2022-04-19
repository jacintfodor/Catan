using Catan.Model.Board;
using Catan.Model.Enums;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        public PlayerEnum ID { get; set; }
        public Goods AvailableResources { get; set; }
        public int AvailableSettlementCardCount { get; }
        public int AvailableTownCardCount { get; }
        public int AvailableRoadCardCount { get; }
        public int ScoreCardCount { get; }
        public int KnightCardCount { get; }
        public int LengthOfLongestRoad { get; set; }
        public void AddResource(Goods resourcesToAdd);
        public void ReduceResources(Goods resourcesToReduce);
        public int CalculateScore();
        public bool CanAfford(Goods resourcesToAfford);
        public void BuildRoad();//changes card counters
        public void BuildTown();//changes card counters
        public void BuildSettlement();//changes card counters
        public bool CanBuildRoad();//checks card counters
        public bool CanBuildTown();//checks card counters
        public bool CanBuildSettlement();//checks card counters
        public void PurchaseBonusCard(Goods resourcesToSpend);
    }
}

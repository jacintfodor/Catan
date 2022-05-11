using Catan.Model.Enums;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        /// <summary>
        /// The PlayerEnum of the player
        /// </summary>
        public PlayerEnum ID { get; set; }
        /// <summary>
        /// The availabe resources of the player
        /// </summary>
        public Goods AvailableResources { get; set; }
        /// <summary>
        /// The number of the available settlement cards
        /// </summary>
        public int AvailableSettlementCardCount { get; }
        /// <summary>
        /// The number of the available town cards
        /// </summary>
        public int AvailableTownCardCount { get; }
        /// <summary>
        /// The number of the available road cards
        /// </summary>
        public int AvailableRoadCardCount { get; }
        /// <summary>
        /// The number of the score cards
        /// </summary>
        public int ScoreCardCount { get; }
        /// <summary>
        /// The number of the knight cards
        /// </summary>
        public int KnightCardCount { get; }
        /// <summary>
        /// The longest road length
        /// </summary>
        public int LengthOfLongestRoad { get; set; }
        /// <summary>
        /// Add resource for this player
        /// </summary>
        /// <param name="resourcesToAdd"></param>
        public void AddResource(Goods resourcesToAdd);
        /// <summary>
        /// Reduce the resources of this player
        /// </summary>
        /// <param name="resourcesToReduce"></param>
        public void ReduceResources(Goods resourcesToReduce);
        /// <summary>
        /// The Score of this player
        /// </summary>
        public int Score { get; }

        public int FirstRoll { get; set; }

        public bool HasLargestArmy { get; }

        public bool HasLongestRoad { get; }

        /// <summary>
        /// If the player can affor returns true
        /// </summary>
        /// <param name="resourcesToAfford"></param>
        /// <returns>True if have enough resourse</returns>
        public bool CanAfford(Goods resourcesToAfford);
        /// <summary>
        /// Reduce the available road card counts
        /// </summary>
        public void BuildRoad();//changes card counters
        /// <summary>
        /// Reduce the available town card counts
        /// </summary>
        public void BuildTown();//changes card counters
        /// <summary>
        /// Reduce the available settlement card counts
        /// </summary>
        public void BuildSettlement();//changes card counters
        /// <summary>
        /// Check it still have road card
        /// </summary>
        /// <returns>true if bigger than 0 </returns>
        public bool CanBuildRoad();//checks card counters
        /// <summary>
        /// Check it still have town card
        /// </summary>
        /// <returns>true if bigger than 0 </returns>
        public bool CanBuildTown();//checks card counters
        /// <summary>
        /// Check it still have settlement card
        /// </summary>
        /// <returns>true if bigger than 0 </returns>
        public bool CanBuildSettlement();//checks card counters
        /// <summary>
        /// Give KnightCard or ScoreCard
        /// </summary>
        /// <param name="resourcesToSpend"></param>
        public void PurchaseBonusCard(Goods resourcesToSpend);
    }
}

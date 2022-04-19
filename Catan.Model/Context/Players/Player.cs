using Catan.Model.Board;
using Catan.Model.Context.Titles;
using Catan.Model.Enums;

namespace Catan.Model.Context.Players
{
    public class Player : IPlayer
    {
        #region Fields

        private Goods _resources;
        private PlayerEnum _id;

        private int _availableSettlementCardCount = 5;
        private int _availableTownCardCount = 5;
        private int _availableRoadCardCount = 15;

        private int _scoreCardCount = 0;
        private int _knightCardCount = 0;
        private int _longestRoad = 0;
        
        #endregion

        #region Properties
        public int AvailableSettlementCardCount { get { return _availableSettlementCardCount; } }
        public int AvailableTownCardCount { get { return _availableTownCardCount; } }
        public int AvailableRoadCardCount { get { return _availableRoadCardCount; } }
        public int LengthOfLongestRoad { get { return _longestRoad; } set { _longestRoad = value; } }
        public int ScoreCardCount { get { return _scoreCardCount; } }
        public int KnightCardCount { get { return _knightCardCount; } }
        public Goods AvailableResources { get { return _resources; } set { _resources = value; } }
        public PlayerEnum ID { get { return _id; } set { _id = value; } }

        #endregion

        #region Constructor
        public Player(PlayerEnum Name)
        {
            _resources = new Goods();
            _id = Name;
        }

        #endregion

        #region Card related Methods
        public void BuildSettlement()
        {
            _availableSettlementCardCount--;
        }
        public void BuildTown()
        {
            _availableSettlementCardCount++;
            _availableTownCardCount--;
        }
        public void BuildRoad()
        {
            _availableRoadCardCount--;
        }
        public bool CanBuildSettlement()
        {
            return (_availableSettlementCardCount > 0) ? true : false;
        }
        public bool CanBuildTown()
        {
            return (_availableTownCardCount > 0) ? true : false;
        }
        public bool CanBuildRoad()
        {
            return (_availableRoadCardCount > 0) ? true : false;
        }
        public void AddScoreCard()
        {
            _scoreCardCount++;
        }
        public void AddKnightCard()
        {
            _knightCardCount++;
        }
        #endregion

        #region Score methods
        public int CalculateScore() 
        {
            return 15 - (_availableSettlementCardCount + 2 * _availableTownCardCount) + AddPointForTheLongestRoad() + ScoreCardCount + AddPointForGreatestKnightlyPower();
        }
        private int AddPointForTheLongestRoad()
        {
            return (LongestRoadOwner.Instance.Owner == this) ? LongestRoadOwner.Instance.Score : 0;
        }
        private int AddPointForGreatestKnightlyPower()
        {
            return (LargestArmyHolder.Instance.Owner == this) ? LargestArmyHolder.Instance.Score : 0;
        }
        #endregion
        
        #region Methods
        public void AddResource(Goods resourcesToAdd)
        {
            _resources += resourcesToAdd;
        }
        public void ReduceResources(Goods resourcesToReduce)
        {
            _resources -= resourcesToReduce;
        }
        public bool CanAfford(Goods resourcesToSpend)
        {
            Goods balance = _resources - resourcesToSpend;
            return balance.Valid;
        }
        #endregion
    }
}

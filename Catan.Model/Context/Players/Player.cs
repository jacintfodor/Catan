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
        
        private int _firstRoll;
        
        #endregion

        #region Properties
        public int AvailableSettlementCardCount { get { return _availableSettlementCardCount; } }
        public int AvailableTownCardCount { get { return _availableTownCardCount; } }
        public int AvailableRoadCardCount { get { return _availableRoadCardCount; } }
        public int LengthOfLongestRoad { get { return _longestRoad; } set { _longestRoad = _longestRoad < value ? value : _longestRoad; } }
        public int ScoreCardCount { get { return _scoreCardCount; } }
        public int KnightCardCount { get { return _knightCardCount; } }
        public Goods AvailableResources { get { return _resources; } set { _resources = value; } }
        public PlayerEnum ID { get { return _id; } set { _id = value; } }
        public int FirstRoll { get { return _firstRoll; } set { _firstRoll = value; } }

        public bool HasLargestArmy => LargestArmyTitle.Instance.Owner == this;

        public bool HasLongestRoad => LongestRoadTitle.Instance.Owner == this;

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
        #endregion

        #region Score methods
        public int Score
        {
            get
            {
                int setl = 15 - (_availableSettlementCardCount + 2 * _availableTownCardCount);
                int longest = LongestRoadTitleScore();
                int scorcard = ScoreCardCount;
                int army = LargestArmyTitleScore();

                return setl + longest + scorcard + army;
            }
        }

        private int LongestRoadTitleScore()
        {
            return (LongestRoadTitle.Instance.Owner == this) ? LongestRoadTitle.Instance.Score : 0;
        }
        private int LargestArmyTitleScore()
        {
            return (LargestArmyTitle.Instance.Owner == this) ? LargestArmyTitle.Instance.Score : 0;
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
        public void PurchaseBonusCard(Goods resourcesToSpend)
        {
            Random rnd = new Random();
            if (rnd.NextDouble() < .3)
            {
                _scoreCardCount++;
            }
            else
            {
                _knightCardCount++;
            }
        }
        #endregion
    }
}

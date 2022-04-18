using Catan.Model.Board;
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
        private int _horesCardCount = 0;
        
        private bool _doIHavaTheGreatestKnightlyPower = false;

        private bool _doIHaveTheLongestRoad = false;
        
        #endregion

        #region Properties
        public int AvailableSettlementCardCount { get { return _availableSettlementCardCount; } }//set { _availableSettlementCardCount = value; } }
        public int AvailableTownCardCount { get { return _availableTownCardCount; } }//set { _availableTownCardCount = value; } }
        public int AvailableRoadCardCount { get { return _availableRoadCardCount; } }//set { _availableRoadCardCount = value; } }

        public int ScoreCardCount { get { return _scoreCardCount; } }
        public int HoresCardCount { get { return _horesCardCount; } }
        
        public bool DoIHavaTheGreatestKnightlyPower { get { return _doIHavaTheGreatestKnightlyPower; } set { _doIHavaTheGreatestKnightlyPower = value; } }
        public bool DoIHaveTheLongestRoad { get { return _doIHaveTheLongestRoad; } set { _doIHaveTheLongestRoad = value; } }
        
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

        #region Public methods
        public int CalculateScore() 
        {
            return 15 - (_availableSettlementCardCount + 2 * _availableTownCardCount) + AddPointForTheLongestRoad() + ScoreCardCount + AddPointForGreatestKnightlyPower();
        }
        public int LengthOfLongestRoad()//nem jó
        {
            // nem tudom hol/hogyan lehetne ezt kiszámolni de addig is 
            //return 15 - _availableRoadCardCount;
            throw new NotImplementedException();
        }
        public int SizeOfArmy()// ua mint a HoresCardCount
        {
            //return 2;
            return _horesCardCount;
        }
        public void AddScoreCard() 
        {
            _scoreCardCount++;
        }
        public void AddHoresCard()
        {
            _horesCardCount++;
        }
      
        public void AddResource(Goods resourcesToAdd)
        {
            _resources += resourcesToAdd;
        }
        public void ReduceResources(Goods resourcesToReduce)
        {
            _resources -= resourcesToReduce;
        }

        public bool CanAfford(Goods resourcesToSpend, String s) 
        {
            Goods balance = _resources - resourcesToSpend;
            if (CanBuild(s))
                Build(s);
            else
                return false;
            return balance.Valid;
        }
        // még a bónuszkártyához kell máshol is változtatni
        public bool CanAfford(Goods resourcesToSpend)
        {
            Goods balance = _resources - resourcesToSpend;
            return balance.Valid;
        }

        #region Talan meg kellhet?

        /*
        public void BuildSettlement() 
        {
            if (CanBuildSettlement())
                _availableSettlementCardCount--; 
        }
        public void BuildTown() 
        {
            if (CanBuildTown())
            {
                _availableSettlementCardCount++;
                _availableTownCardCount--;
            }
        }
        public void BuildRoad() 
        {
            if(CanBuildRoad())
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
        public bool CanBuild(String s) 
        {
            switch (s)
            {
                case "Settlement":
                    return CanBuildSettlement();
                
                case "Town":
                    return CanBuildTown();

                case "Road":
                    return CanBuildRoad();
                
                case "BonusCard":
                    return true;

                default:
                    return false;
            }
        }
        */

        #endregion

        #endregion

        #region Private methods
        private int AddPointForTheLongestRoad()
        {
            return (_doIHaveTheLongestRoad) ? 2 : 0;
        }
        private int AddPointForGreatestKnightlyPower()
        {
            return (_doIHavaTheGreatestKnightlyPower) ? 2 : 0;
        }

        private void BuildSettlement()
        {
            if (CanBuildSettlement())
                _availableSettlementCardCount--;
        }
        private void BuildTown()
        {
            if (CanBuildTown())
            {
                _availableSettlementCardCount++;
                _availableTownCardCount--;
            }
        }
        private void BuildRoad()
        {
            if (CanBuildRoad())
                _availableRoadCardCount--;
        }
        private bool CanBuildSettlement()
        {
            return (_availableSettlementCardCount > 0) ? true : false;
        }
        private bool CanBuildTown()
        {
            return (_availableTownCardCount > 0) ? true : false;
        }
        private bool CanBuildRoad()
        {
            return (_availableRoadCardCount > 0) ? true : false;
        }
        private bool CanBuild(String s)
        {
            switch (s)
            {
                case "Settlement":
                    return CanBuildSettlement();

                case "Town":
                    return CanBuildTown();

                case "Road":
                    return CanBuildRoad();

                case "BonusCard":
                    return true;

                default:
                    return false;
            }
        }
        private void Build(String s)
        {
            switch (s)
            {
                case "Settlement":
                    BuildSettlement();
                    break;

                case "Town":
                    BuildTown();
                    break;

                case "Road":
                    BuildRoad();
                    break;

                case "BonusCard":
                    BonusCard(30);
                    break;
            }
        }
        private void BonusCard(int p) 
        {
            Random rand = new Random();
            int number = rand.Next(0, 100);
            if (number > p)
                AddScoreCard();
            else
                AddHoresCard();
        }
        #endregion

    }
}

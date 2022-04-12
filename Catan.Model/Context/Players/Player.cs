using Catan.Model.Board;
using Catan.Model.Enums;

namespace Catan.Model.Context.Players
{
    public class Player : IPlayer
    {
        private Goods _resources;
        private PlayerEnum _id;
        

        public Goods AvailableResources { get { return _resources; } set { _resources = value; } }
        public PlayerEnum ID { get { return _id; } set { _id = value; } }

        public Player(PlayerEnum Name)
        {
            _resources = new Goods();
            _id = Name;
        }

        public int CalculateScore()
        {
            return -1;
        }

        public int LengthOfLongestRoad()
        {
            return 4;
        }

        public int SizeOfArmy()
        {
            return 2;
        }

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
    }
}

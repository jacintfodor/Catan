using Catan.Model.Board;

namespace Catan.Model.Context.Players
{
    public class Player : IPlayer
    {
        private Goods _resources;
        private string _name;
        

        public Goods AvailableResources { get { return _resources; } set { _resources = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public Player(string Name)
        {
            _resources = new Goods();
            _name = Name;
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

using Catan.Model.Board;
using Catan.Model.Enums;

namespace Catan.Model.Context.Players
{
    public class NotPlayer : IPlayer
    {
        private NotPlayer()
        {
        }

        public PlayerEnum ID { get ; set; }

        private static readonly NotPlayer _instance = new NotPlayer();
        public static NotPlayer Instance
        { get { return _instance; } }

        public Goods AvailableResources { get => new Goods(); set => new Goods();}

        public int AvailableSettlementCardCount => 0;

        public int AvailableTownCardCount => 0;

        public int AvailableRoadCardCount => 0;

        public int ScoreCardCount => 0;

        public int KnightCardCount => 0;

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

        public void AddResource(Goods resourcesToRemove) { }

        public void ReduceResources(Goods resourcesToReduce) { }

        public bool CanAfford(Goods resourcesToAfford)
        {
            return false;
        }
        public bool CanAfford(Goods resourcesToAfford, String s)
        {
            return false;
        }

        public void BuildRoad()
        {
            throw new NotImplementedException();
        }

        public void BuildTown()
        {
            throw new NotImplementedException();
        }

        public void BuildSettlement()
        {
            throw new NotImplementedException();
        }

        public bool CanBuildRoad()
        {
            throw new NotImplementedException();
        }

        public bool CanBuildTown()
        {
            throw new NotImplementedException();
        }

        public bool CanBuildSettlement()
        {
            throw new NotImplementedException();
        }

        public void AddScoreCard()
        {
            throw new NotImplementedException();
        }

        public void AddKnightCard()
        {
            throw new NotImplementedException();
        }

        public void SetLengthOfMyLongestRoad(int length)
        {
            throw new NotImplementedException();
        }
    }
}

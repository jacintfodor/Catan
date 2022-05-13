using Catan.Model.Context.Titles;
using Catan.Model.Enums;

namespace Catan.Model.Context.Players
{
    public class NotPlayer : IPlayer
    {
        private NotPlayer()
        {
        }

        public PlayerEnum ID { get => PlayerEnum.NotPlayer; set =>
            throw new NotImplementedException();
        }

        private static readonly NotPlayer _instance = new NotPlayer();
        public static NotPlayer Instance
        { get { return _instance; } }

        public Goods AvailableResources { get => new Goods(); set => new Goods();}

        public int AvailableSettlementCardCount => -1;

        public int AvailableTownCardCount => -1;

        public int AvailableRoadCardCount => -1;

        public int ScoreCardCount => 0;

        public int KnightCardCount => 2;

        public int LengthOfLongestRoad { get => 4; set =>
            throw new NotImplementedException(); }

        public int Score => -1;

        public int FirstRoll { get => -1; set  { } }

        public bool HasLargestArmy => LargestArmyTitle.Instance.Owner == this;

        public bool HasLongestRoad => LongestRoadTitle.Instance.Owner == this;

        public void AddResource(Goods resourcesToRemove)
        {
            throw new InvalidOperationException("NotPlayer");
        }

        public void ReduceResources(Goods resourcesToReduce)
        {
            throw new InvalidOperationException("NotPlayer");
        }
        public bool CanAfford(Goods resourcesToAfford)
        {
            return false;
        }
        public void SpendRoadCards()
        {
            throw new InvalidOperationException("NotPlayer");
        }

        public void SpendTownCard()
        {
            throw new InvalidOperationException("NotPlayer");
        }

        public void SpendSettlementCard()
        {
            throw new InvalidOperationException("NotPlayer");
        }

        public bool CanBuildRoad()
        {
            return false;
        }

        public bool CanBuildTown()
        {
            return false;
        }

        public bool CanBuildSettlement()
        {
            return false;
        }
        public BonusCardEnum DrawBonusCard()
        {
            throw new InvalidOperationException("NotPlayer");
        }

    }
}

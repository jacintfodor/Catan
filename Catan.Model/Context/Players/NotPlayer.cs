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

        public Goods AvailableResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
}

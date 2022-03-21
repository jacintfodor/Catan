using Catan.Model.Board;

namespace Catan.Model.Context.Players
{
    public class NotPlayer : IPlayer
    {
        private NotPlayer()
        {
        }

        private static readonly NotPlayer _instance = new NotPlayer();
        public static NotPlayer Instance
        { get { return _instance; } }

        public Goods resources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CalculateScore()
        {
            return -1;
        }

        public int LengthOfLongestRoad()
        {
            return 4;
        }

        public int sizeOfArmy()
        {
            return 2;
        }

        public void addResource(ResourceEnum resourceToAdd, int amount) { }

        public void reduceResources(Goods resourcesToReduce) { }
    }
}

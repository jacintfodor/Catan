using Catan.Model.Context;
using Catan.Model.Context.Players;

namespace Catan.Model.Board.Buildings
{
    public class NotBuilding : Building
    {
        public static Goods BuildCost =  new Goods(new List<int> { 0, 0, 0, 0, 0 });

        private NotBuilding()
        {
        }

        private static readonly NotBuilding _instance = new NotBuilding();
        public static NotBuilding Instance
        { get { return _instance; } }

        override public int score() { return 0; }
        override public int amount() { return 0; }
        override public bool isBuildable() { return true; }
        override public List<Player> canBuild() { return new List<Player>();}
    }
}

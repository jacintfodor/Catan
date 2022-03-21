using Catan.Model.Context;

namespace Catan.Model.Board.Buildings
{
    public class Road : Building
    {
        public static Goods buildCost = new Goods(new List<int> { 0, 0, 1, 1, 0 });
        override public int score() {return 0;}
        override public int amount() {return 0;}
    }
}

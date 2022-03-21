using Catan.Model.Context;

namespace Catan.Model.Board.Buildings
{
    public class Settlement : Building
    {
        public static Goods BuildCost = new Goods(new List<int> { 1, 0, 1, 1, 1 });
        override public int score() { return 1; }
        override public int amount() { return 1;}
    }
}

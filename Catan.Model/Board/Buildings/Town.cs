using Catan.Model.Context;

namespace Catan.Model.Board.Buildings
{
    public class Town : Building
    {
        public static Goods BuildCost = new Goods(new List<int> { 3, 3, 0, 0, 0 });
        override public int score() { return 2; }
        override public int amount() { return 2; }
        
    }
}

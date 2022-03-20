namespace Catan.Model.Board.Buildings
{
    public class Road : IBuilding
    {
        public int score() {return 0;}
        public int amount() {return 0;}
        public List<int> buildCost() {return new List<int>{0, 0, 1, 1, 0};}
    }
}

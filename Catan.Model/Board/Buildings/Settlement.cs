namespace Catan.Model.Board.Buildings
{
    public class Settlement : IBuilding
    {
        public int score() { return 1; }
        public int amount() { return 1;}
        public List<int> buildCost() {return new List<int>{1, 0, 1, 1, 1};}
    }
}

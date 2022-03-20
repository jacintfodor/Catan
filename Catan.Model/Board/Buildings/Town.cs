namespace Catan.Model.Board.Buildings
{
    public class Town : IBuilding
    {
        public int score() { return 2; }
        public int amount() { return 2; }
        public List<int> buildCost() { return new List<int> {3, 3, 0, 0, 0 };
        }
    }
}

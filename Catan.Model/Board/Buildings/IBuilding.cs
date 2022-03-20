namespace Catan.Model.Board.Buildings
{
    public interface IBuilding
    {
        public int score();
        public int amount();
        public List<int> buildCost();
    }
}

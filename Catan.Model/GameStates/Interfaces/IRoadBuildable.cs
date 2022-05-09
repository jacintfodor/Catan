namespace Catan.Model.GameStates
{
    public interface IRoadBuildable
    {
        public void BuildRoad(ICatanContext context, int row, int col);
    }
}

namespace Catan.Model.GameStates
{
    internal interface IRoadBuildable
    {
        public void BuildRoad(ICatanContext context, int row, int col);
    }
}

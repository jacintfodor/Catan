namespace Catan.Model.GameStates.Interfaces
{
    internal interface ISettlementBuildable
    {
        public void BuildSettleMent(ICatanContext context, int row, int col);
    }
}

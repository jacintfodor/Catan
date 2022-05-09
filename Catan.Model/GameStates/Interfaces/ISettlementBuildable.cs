namespace Catan.Model.GameStates.Interfaces
{
    public interface ISettlementBuildable
    {
        public void BuildSettleMent(ICatanContext context, int row, int col);
    }
}

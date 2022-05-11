namespace Catan.Model.GameStates.Interfaces
{
    public interface ISettlementBuildable
    {
        /// <summary>
        /// Build settlement with context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="row">The row to build</param>
        /// <param name="col">The column to build</param>
        public void BuildSettleMent(ICatanContext context, int row, int col);
    }
}

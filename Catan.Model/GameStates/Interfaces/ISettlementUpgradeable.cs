namespace Catan.Model.GameStates.Interfaces
{
    
    public interface ISettlementUpgradeable
    {
        /// <summary>
        /// The position of the settlement will be a town
        /// </summary>
        /// <param name="context"></param>
        /// <param name="row">The row to build</param>
        /// <param name="col">The column to build</param>
        public void UpgradeSettleMentToTown(ICatanContext context, int row, int col);
    }
}

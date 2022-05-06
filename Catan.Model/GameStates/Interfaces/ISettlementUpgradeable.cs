namespace Catan.Model.GameStates.Interfaces
{
    internal interface ISettlementUpgradeable
    {
        public void UpgradeSettleMentToTown(ICatanContext context, int row, int col);
    }
}

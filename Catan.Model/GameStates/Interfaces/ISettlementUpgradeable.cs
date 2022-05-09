namespace Catan.Model.GameStates.Interfaces
{
    public interface ISettlementUpgradeable
    {
        public void UpgradeSettleMentToTown(ICatanContext context, int row, int col);
    }
}

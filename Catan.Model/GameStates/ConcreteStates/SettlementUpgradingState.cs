using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class SettlementUpgradingState : ICatanGameState, ISettlementUpgradeable, ICancellable
    {
        public bool IsSettlementUpgradingState => true;

        public void Cancel(ICatanContext context)
        {
            context.Events.OnCancelled();
            context.SetContext(new MainState());
        }

        public void UpgradeSettleMentToTown(ICatanContext context, int row, int col)
        {

            context.Board.UpgradeSettlement(row, col);
            context.Events.OnSettlementUpgraded(context, row, col);

            context.CurrentPlayer.SpendTownCard();
            context.CurrentPlayer.ReduceResources(Constants.TownCost);
            context.Events.OnPlayerUpdated(context);
            
            context.SetContext(new MainState());
        }
    }
}

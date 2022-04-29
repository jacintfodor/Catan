using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class SettlementUpgradingState : ICatanGameState, ISettlementUpgradeable, ICancellable
    {
        public bool IsSettlementUpgradingState => true;

        public void Cancel(CatanContext context)
        {
            context.Events.OnCancel();
            context.SetContext(new MainState());
        }

        public void UpgradeSettleMentToTown(CatanContext context, int row, int col)
        {

            context.Board.UpgradeSettlement(row, col);
            context.Events.OnSettlementUpgraded(context, row, col);

            context.CurrentPlayer.BuildTown();
            context.CurrentPlayer.ReduceResources(Constants.TownCost);
            context.Events.OnPlayer(context);
            context.SetContext(new MainState());
        }
    }
}

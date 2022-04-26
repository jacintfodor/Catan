using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class SettlementUpgradingState : AbstractSettlementupgradingState
    {
        public override bool IsSettlementUpgradingState => true;

        public override sealed void Cancel(CatanContext context)
        {
            context.Events.OnCancel();
            context.SetContext(new MainState());
        }

        public override sealed void UpgradeSettleMentToTown(CatanContext context, int row, int col)
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

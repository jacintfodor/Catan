using Catan.Model.Board;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class SettlementUpgradingState : ICatanGameState, ISettlementUpgradeable, ICancellable
    {
        public bool IsSettlementUpgradingState => true;

        public void Cancel(ICatanContext context, ICatanEvents events)
        {
            events.OnCancel();
            context.SetContext(new MainState());
        }

        public void UpgradeSettleMentToTown(ICatanContext context, ICatanEvents events, ICatanBoard board, IPlayer currentPlayer, int row, int col)
        {

            board.UpgradeSettlement(row, col);
            events.OnSettlementUpgraded(context, row, col);

            currentPlayer.BuildTown();
            currentPlayer.ReduceResources(Constants.TownCost);
            events.OnPlayer(context);
            context.SetContext(new MainState());
        }
    }
}

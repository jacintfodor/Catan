using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

using Catan.Model.Board;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class SettlementUpgradingState : ICatanGameState, ISettlementUpgradeable, ICancellable
    {
        public bool IsSettlementUpgradingState => true;

        public void Cancel(CatanContext context)
        {
            context.OnCancel();
            context.SetContext(new MainState());
        }

        public void UpgradeSettleMentToTown(CatanContext context, CatanBoard board, IPlayer currentPlayer, int row, int col)
        {

            board.UpgradeSettlement(row, col);
            context.OnSettlementUpgraded(context, row, col);

            currentPlayer.BuildTown();
            currentPlayer.ReduceResources(Constants.TownCost);
            context.OnPlayer(context);
            context.SetContext(new MainState());
        }
    }
}

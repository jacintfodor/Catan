using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Board;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class SettlementBuildingState : ICatanGameState, ISettlementBuildable, ICancellable
    {
        public bool IsSettlementBuildingState => true;

        public void BuildSettleMent(CatanContext context, CatanBoard board, IPlayer currentPlayer, int row, int col)
        {
            board.BuildSettlement(row, col, currentPlayer.ID);
            context.OnSettlementBuilt(context, row, col, currentPlayer.ID);

            board.GetNeighborEdgesOfVertex(row, col).ForEach(e => e.AddPotentialBuilder(currentPlayer.ID));
            board.GetNeighborVerticesOfVertex(row, col).ForEach(v => v.SetNotBuildableCommunity());

            currentPlayer.BuildSettlement();
            currentPlayer.ReduceResources(Constants.SettlementCost);
            context.OnPlayer(context);
            context.SetContext(new MainState());
        }

        public void Cancel(CatanContext context)
        {
            context.OnCancel();
            context.SetContext(new MainState());
        }
    }
}

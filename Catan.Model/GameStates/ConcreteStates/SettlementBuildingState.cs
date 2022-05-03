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

        public void BuildSettleMent(ICatanContext context, ICatanEvents events, ICatanBoard board, IPlayer currentPlayer, int row, int col)
        {
            board.BuildSettlement(row, col, currentPlayer.ID);
            events.OnSettlementBuilt(context, row, col, currentPlayer.ID);

            board.GetNeighborEdgesOfVertex(row, col).ForEach(e => e.AddPotentialBuilder(currentPlayer.ID));
            board.MarkNeighbouringVerticesNotBuildable(row, col);

            currentPlayer.BuildSettlement();
            currentPlayer.ReduceResources(Constants.SettlementCost);
            events.OnPlayer(context);
            context.SetContext(new MainState());
        }

        public void Cancel(ICatanContext context, ICatanEvents events)
        {
            events.OnCancel();
            context.SetContext(new MainState());
        }
    }
}

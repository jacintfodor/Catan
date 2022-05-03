using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;
using Catan.Model.Board;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class EarlySettlementBuildingState : ICatanGameState, ISettlementBuildable
    {
        readonly int _turnCount;

        public EarlySettlementBuildingState(int turnCount)
        {
            _turnCount = turnCount;
        }

        public bool IsEarlySettlementBuildingState => true;


        public void BuildSettleMent(CatanContext context, CatanBoard board, IPlayer currentPlayer, int row, int col)
        {
            currentPlayer.BuildSettlement();
            context.OnPlayer(context);

            board.BuildSettlement(row, col, currentPlayer.ID);
            context.OnSettlementBuilt(context, row, col, currentPlayer.ID);

            board.GetNeighborEdgesOfVertex(row, col).ForEach(e => e.AddPotentialBuilder(currentPlayer.ID));
            board.GetNeighborVerticesOfVertex(row, col).ForEach(v => v.SetNotBuildableCommunity());

            var list = board.GetNeighborEdgesOfVertex(row, col).ToList().Where(e => e.IsBuildableByPlayer(currentPlayer.ID)).ToList();
            context.OnRoadBuildingStarted(list);

            context.SetContext(new EarlyRoadBuildingState(_turnCount + 1));
        }
    }
}

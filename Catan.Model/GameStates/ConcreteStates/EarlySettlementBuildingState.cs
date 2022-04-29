using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

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


        public void BuildSettleMent(CatanContext context, int row, int col)
        {
            context.CurrentPlayer.BuildSettlement();
            context.Events.OnPlayer(context);

            context.Board.BuildSettlement(row, col, context.CurrentPlayer.ID);
            context.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID);

            context.Board.GetNeighborEdgesOfVertex(row, col).ForEach(e => e.AddPotentialBuilder(context.CurrentPlayer.ID));
            context.Board.GetNeighborVerticesOfVertex(row, col).ForEach(v => v.SetNotBuildableCommunity());

            var list = context.Board.GetNeighborEdgesOfVertex(row, col).ToList().Where(e => e.IsBuildableByPlayer(context.CurrentPlayer.ID)).ToList();
            context.Events.OnRoadBuildingStarted(list);

            context.SetContext(new EarlyRoadBuildingState(_turnCount + 1));
        }
    }
}

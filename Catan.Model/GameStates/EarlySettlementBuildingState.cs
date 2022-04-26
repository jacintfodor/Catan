using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates
{
    internal class EarlySettlementBuildingState : AbstractSettlementBuildingState
    {
        int _turnCount;

        public EarlySettlementBuildingState(int tCount)
        {
            _turnCount = tCount;
        }

        public override sealed bool IsEarlySettlementBuildingState => true;

        public override sealed bool IsSettlementBuildingState => false;

        public override sealed void BuildSettleMent(CatanContext context, int row, int col)
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

        public override sealed void Cancel(CatanContext context)
        {
            throw new InvalidOperationException("skipping settlement building is not allowed at this phase");
        }
    }
}

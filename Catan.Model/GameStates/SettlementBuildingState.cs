using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates
{
    internal class SettlementBuildingState : AbstractSettlementBuildingState
    {
        public override bool IsEarlySettlementBuildingState => false;

        public override bool IsSettlementBuildingState => true;

        public override sealed void BuildSettleMent(CatanContext context, int row, int col)
        {

            context.Board.BuildSettlement(row, col, context.CurrentPlayer.ID);
            context.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID);

            context.Board.GetNeighborEdgesOfVertex(row, col).ForEach(e => e.AddPotentialBuilder(context.CurrentPlayer.ID));
            context.Board.GetNeighborVerticesOfVertex(row, col).ForEach(v => v.SetNotBuildableCommunity());

            context.CurrentPlayer.BuildSettlement();
            context.CurrentPlayer.ReduceResources(Constants.SettlementCost);
            context.Events.OnPlayer(context);
            context.SetContext(new MainState());
        }

        public override sealed void Cancel(CatanContext context)
        {
            context.Events.OnCancel();
            context.SetContext(new MainState());
        }
    }
}

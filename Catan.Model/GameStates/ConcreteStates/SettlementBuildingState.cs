﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class SettlementBuildingState : ICatanGameState, ISettlementBuildable, ICancellable
    {
        public bool IsSettlementBuildingState => true;

        public void BuildSettleMent(CatanContext context, int row, int col)
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

        public void Cancel(CatanContext context)
        {
            context.Events.OnCancel();
            context.SetContext(new MainState());
        }
    }
}

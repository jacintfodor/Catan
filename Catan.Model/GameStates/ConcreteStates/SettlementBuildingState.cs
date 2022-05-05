using System;
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

        public void BuildSettleMent(ICatanContext context, int row, int col)
        {

            context.Board.BuildSettlement(row, col, context.State, context.CurrentPlayer.ID);
            context.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID);
            
            context.CurrentPlayer.BuildSettlement();
            context.CurrentPlayer.ReduceResources(Constants.SettlementCost);
            context.Events.OnPlayerUpdated(context);
            
            context.SetContext(new MainState());
        }

        public void Cancel(ICatanContext context)
        {
            context.Events.OnCancelled();
            context.SetContext(new MainState());
        }
    }
}

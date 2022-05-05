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
    internal class RoadBuildingState : ICatanGameState, IRoadBuildable, ICancellable
    {
        public bool IsRoadBuildingState => true;

        public void BuildRoad(ICatanContext context, int row, int col)
        {
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);
            
            context.CurrentPlayer.LengthOfLongestRoad = context.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID);
            context.LongestRoadOwner.ProcessOwner(context.CurrentPlayer);

            context.CurrentPlayer.BuildRoad();
            context.CurrentPlayer.ReduceResources(Constants.RoadCost);
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

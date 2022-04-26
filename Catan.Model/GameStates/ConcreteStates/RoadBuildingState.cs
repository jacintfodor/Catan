using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class RoadBuildingState : AbstractRoadBuildingState
    {
        public override sealed bool IsRoadBuildingState => true;

        public override sealed bool IsEarlyRoadBuildingState => false;

        public override sealed void BuildRoad(CatanContext context, int row, int col)
        {
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);
            context.CurrentPlayer.LengthOfLongestRoad = context.CalculateLongestRoadFromEdge(context.Board.GetEdge(row, col));
            context.LongestRoadOwner.ProcessOwner(context.CurrentPlayer);
            //mark neighbouring vertexes as buildable by current player
            context.Board.GetNeighbourVerticesOfEdge(row, col).ForEach(v => v.AddPotentialBuilder(context.CurrentPlayer.ID));

            //mark neighbouring Edges as Buildable
            context.Board.GetEdgesofEdge(row, col).ForEach(edge =>
            {
                edge.AddPotentialBuilder(context.CurrentPlayer.ID);
            });

            context.CurrentPlayer.BuildRoad();
            context.CurrentPlayer.ReduceResources(Constants.RoadCost);
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

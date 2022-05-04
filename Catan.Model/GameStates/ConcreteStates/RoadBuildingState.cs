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
    internal class RoadBuildingState : ICatanGameState, IRoadBuildable, ICancellable
    {
        public bool IsRoadBuildingState => true;

        public void BuildRoad(ICatanContext context, ICatanEvents events, ICatanBoard board, ITitle longestRoad, IPlayer currentPlayer, int row, int col)
        {
            board.BuildRoad(row, col, currentPlayer.ID);
            events.OnRoadBuilt(context, row, col, currentPlayer.ID);
            currentPlayer.LengthOfLongestRoad = context.CalculateLongestRoadFromEdge(board.GetEdge(row, col));
            longestRoad.ProcessOwner(currentPlayer);
            //mark neighbouring vertexes as buildable by current player
            board.GetNeighbourVerticesOfEdge(row, col).ForEach(v => v.AddPotentialBuilder(currentPlayer.ID));

            //mark neighbouring Edges as Buildable
            board.GetEdgesofEdge(row, col).ForEach(edge =>
            {
                edge.AddPotentialBuilder(currentPlayer.ID);
            });

            currentPlayer.BuildRoad();
            currentPlayer.ReduceResources(Constants.RoadCost);
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

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
    //TODO set internal
    public class EarlyRoadBuildingState : ICatanGameState, IRoadBuildable
    {
        private int _turnCount = 0;

        public EarlyRoadBuildingState(int turnCount)
        {
            _turnCount = turnCount;
        }

        public bool IsEarlyRoadBuildingState => true;

        public void BuildRoad(ICatanContext context, int row, int col)
        {
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);

            context.CurrentPlayer.LengthOfLongestRoad = context.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID);
            context.LongestRoadOwner.ProcessOwner(context.CurrentPlayer);
            //mark neighbouring vertexes as buildable by current player
            context.Board.GetNeighbourVerticesOfEdge(row, col).ForEach(v => v.AddPotentialBuilder(context.CurrentPlayer.ID));

            //mark neighbouring Edges as Buildable
            context.Board.GetEdgesofEdge(row, col).ForEach(edge =>
            {
                edge.AddPotentialBuilder(context.CurrentPlayer.ID);
            });

            //TODO remove magic number 6
            if (_turnCount > 6 && _turnCount < 0) ; //TODO throw error

            else if (_turnCount == 6)
            {
                context.DistributeResources(this);
                context.SetContext(new RollingState());
            }
            else
            {
                var list = context.Board.GetVerticesEnumerable().ToList().Where(v => v.IsBuildableByPlayer(context.State, context.CurrentPlayer.ID)).ToList();
                context.Events.OnSettlementBuildingStarted(list);

                context.SetContext(new EarlySettlementBuildingState(_turnCount));
            }

            context.NextPlayer();
            context.CurrentPlayer.BuildRoad();
            context.Events.OnPlayer(context);
        }
    }
}

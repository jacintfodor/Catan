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
    internal class EarlyRoadBuildingState : ICatanGameState, IRoadBuildable
    {
        private int _turnCount = 0;

        public EarlyRoadBuildingState(int turnCount)
        {
            _turnCount = turnCount;
        }

        public bool IsEarlyRoadBuildingState => true;

        public void BuildRoad(CatanContext context, int row, int col)
        {
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);

            context.CurrentPlayer.LengthOfLongestRoad = context.CalculateLongestRoadFromEdge(context.Board.GetEdge(row, col));
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
                context.DistributeResources(-1, true);
                context.SetContext(new RollingState());
            }
            else
            {
                var list = context.Board.GetVerticesEnumerable().ToList().Where(v => v.IsBuildable).ToList();
                context.OnSettlementBuildingStarted(list);

                context.SetContext(new EarlySettlementBuildingState(_turnCount));
            }

            context.NextPlayer();
            context.CurrentPlayer.BuildRoad();
            context.OnPlayer(context);
        }
    }
}

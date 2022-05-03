﻿using System;
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
    internal class EarlyRoadBuildingState : ICatanGameState, IRoadBuildable
    {
        private int _turnCount = 0;

        public EarlyRoadBuildingState(int turnCount)
        {
            _turnCount = turnCount;
        }

        public bool IsEarlyRoadBuildingState => true;

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

            //TODO remove magic number 6
            if (_turnCount > 6 && _turnCount < 0) ; //TODO throw error

            else if (_turnCount == 6)
            {
                context.DistributeResources(-1, true);
                context.SetContext(new RollingState());
            }
            else
            {
                var list = board.GetVerticesEnumerable().ToList().Where(v => v.IsBuildable).ToList();
                events.OnSettlementBuildingStarted(list);

                context.SetContext(new EarlySettlementBuildingState(_turnCount));
            }

            context.NextPlayer();
            currentPlayer.BuildRoad();
            events.OnPlayer(context);
        }
    }
}
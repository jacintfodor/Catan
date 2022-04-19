using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Context;
using Catan.Model.Enums;

namespace Catan.Model.GameStates
{
    public class EarlyRoadBuildingState : ICatanGameState
    {
        int _turnCount = 0;

        public EarlyRoadBuildingState(int tCount)
        {
            _turnCount = tCount;
        }

        public void AcceptTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void BuildRoad(CatanContext context, int row, int col)
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
                context.Events.OnSettlementBuildingStarted(list);

                context.SetContext(new EarlySettlementBuildingState(_turnCount));
            }

            context.NextPlayer();
            context.CurrentPlayer.BuildRoad();
            context.Events.OnPlayer(context);
        }

        public void BuildSettleMent(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void Cancel(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void DenyTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void EndTurn(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to)
        {
            throw new NotImplementedException();
        }

        public void IsAffordable(CatanContext context, Goods g)
        {
            throw new NotImplementedException();
        }

        public void MoveRogue(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void PurchaseBonusCard(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void RollDices(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartRoadBuilding(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartSettlementBuilding(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartSettlementUpgrading(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void UpgradeSettleMentToTown(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}

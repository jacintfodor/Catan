using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Context;

namespace Catan.Model.GameStates
{
    public class RoadBuildingState : ICatanGameState
    {
        public RoadBuildingState()
        {
            
        }

        public void AcceptTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void BuildRoad(CatanContext context, int row, int col)
        {
            

            //TODO reduce roadCards, reduce player resources
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);

            //mark neighbouring vertexes as buildable by current player
            context.Board.getNeighbourVerticesOfEdge(row, col).ForEach(v => v.AddPotentialBuilder(context.CurrentPlayer.ID));

            //mark neighbouring Edges as Buildable
            //TODO use getNeighbourEdgesOfEdge later
            context.Board.getNeighbourVerticesOfEdge(row, col).ForEach(
                v => context.Board.getNeighborEdgesOfVertex(v.Row, v.Col).ForEach(e => e.AddPotentialBuilder(context.CurrentPlayer.ID))
            );

            
            context.SetContext(new MainState());
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

        public void ExchangeWithBank(CatanContext context)
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

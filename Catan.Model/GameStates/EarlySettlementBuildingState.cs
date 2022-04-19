using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Context;
using Catan.Model.Board.Components;
using Catan.Model.Enums;

namespace Catan.Model.GameStates
{
    public class EarlySettlementBuildingState : ICatanGameState
    {
        int _turnCount;

        public EarlySettlementBuildingState(int tCount)
        {
            _turnCount = tCount;
        }

        public void AcceptTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void BuildRoad(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void BuildSettleMent(CatanContext context, int row, int col)
        {
            context.CurrentPlayer.BuildSettlement();
            context.Events.OnPlayer(context);

            context.Board.BuildSettlement(row, col, context.CurrentPlayer.ID);
            context.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID);
            
            context.Board.GetNeighborEdgesOfVertex(row, col).ForEach(e => e.AddPotentialBuilder(context.CurrentPlayer.ID));
            context.Board.GetNeighborVerticesOfVertex(row, col).ForEach(v => v.SetNotBuildableCommunity());
            
            var list = context.Board.GetNeighborEdgesOfVertex(row, col).ToList().Where(e => e.IsBuildableByPlayer(context.CurrentPlayer.ID)).ToList();
            context.Events.OnRoadBuildingStarted(list);

            context.SetContext(new EarlyRoadBuildingState(_turnCount + 1));
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

        public bool IsAffordable(CatanContext context, Goods g)
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

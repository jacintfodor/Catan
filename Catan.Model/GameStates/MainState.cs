using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;
using Catan.Model.Context;

namespace Catan.Model.GameStates
{
    public class MainState : ICatanGameState
    {
        public bool IsMainState => true;

        public void AcceptTrade(CatanContext context)
        {
            
        }

        public void BuildRoad(CatanContext context, int row, int col)
        {
            
        }

        public void BuildSettleMent(CatanContext context, int row, int col)
        {
            
        }

        public void Cancel(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void DenyTrade(CatanContext context)
        {
            
        }

        public void EndTurn(CatanContext context)
        {
            //TODO check winner

            context.NextPlayer();
            context.Events.OnPlayer(context);

            //context.Events.OnBuildableByPlayer(context);
            context.SetContext(new RollingState());
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

        //Crop, Ore, Wood, Brick, Wool
        public void PurchaseBonusCard(CatanContext context)
        {
            if (context.CurrentPlayer.CanAfford(Constants.BonusCardCost))
                context.CurrentPlayer.ReduceResources(Constants.BonusCardCost);
        }

        public void RollDices(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartRoadBuilding(CatanContext context)
        {
            context.Events.OnRoadBuildingStarted(context.GetBuildableRoadsByPlayer());
            context.SetContext(new RoadBuildingState());
        }

        public void StartSettlementBuilding(CatanContext context)
        {
            context.Events.OnSettlementBuildingStarted(context.GetBuildableSettlementsByPlayer());
            context.SetContext(new SettlementBuildingState());
        }

        public void StartSettlementUpgrading(CatanContext context)
        {
            context.Events.OnSettlementUpgradingStarted(context.GetUpgradeableSettlementsByPlayer());
            context.SetContext(new SettlementUpgradingState());
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

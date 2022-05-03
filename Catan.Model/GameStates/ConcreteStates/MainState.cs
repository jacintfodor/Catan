using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class MainState : ICatanGameState, IMainState
    {
        public bool IsMainState => true;

        public void EndTurn(CatanContext context)
        {
            //TODO check winner

            context.NextPlayer();
            context.OnPlayer(context);

            //context.Events.OnBuildableByPlayer(context);
            context.SetContext(new RollingState());
        }

        public void ExchangeWithBank(CatanContext context, IPlayer currentPlayer, ResourceEnum from, ResourceEnum to)
        {
            //TODO handle from=to as invalid
            currentPlayer.ReduceResources(new Goods(from) * 3);
            currentPlayer.AddResource(new Goods(to));
            context.OnPlayer(context);
        }

        public bool IsAffordable(IPlayer currentPlayer, Goods g)
        {
            return currentPlayer.CanAfford(g);
        }

        //Crop, Ore, Wood, Brick, Wool
        public void PurchaseBonusCard(CatanContext context, IPlayer currentPlayer, ITitle largestArmy)
        {
            currentPlayer.PurchaseBonusCard(Constants.BonusCardCost);
            currentPlayer.ReduceResources(Constants.BonusCardCost);
            largestArmy.ProcessOwner(context.CurrentPlayer);
            context.OnPlayer(context);
        }

        public void StartRoadBuilding(CatanContext context)
        {
            context.OnRoadBuildingStarted(context.GetBuildableRoadsByPlayer());
            context.SetContext(new RoadBuildingState());
        }

        public void StartSettlementBuilding(CatanContext context)
        {
            context.OnSettlementBuildingStarted(context.GetBuildableSettlementsByPlayer());
            context.SetContext(new SettlementBuildingState());
        }

        public void StartSettlementUpgrading(CatanContext context)
        {
            context.OnSettlementUpgradingStarted(context.GetUpgradeableSettlementsByPlayer());
            context.SetContext(new SettlementUpgradingState());
        }
    }
}

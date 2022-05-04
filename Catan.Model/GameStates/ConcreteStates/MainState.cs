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

        public void EndTurn(ICatanContext context, ICatanEvents events)
        {
            //TODO check winner

            context.NextPlayer();
            events.OnPlayer(context);

            //context.Events.OnBuildableByPlayer(context);
            context.SetContext(new RollingState());
        }

        public void ExchangeWithBank(ICatanContext context, ICatanEvents events, IPlayer currentPlayer, ResourceEnum from, ResourceEnum to)
        {
            //TODO handle from=to as invalid
            currentPlayer.ReduceResources(new Goods(from) * 3);
            currentPlayer.AddResource(new Goods(to));
            events.OnPlayer(context);
        }


        public bool IsAffordable(ICatanContext context, IPlayer currentPlayer, Goods g)
        {
            return currentPlayer.CanAfford(g);
        }

        //Crop, Ore, Wood, Brick, Wool
        public void PurchaseBonusCard(ICatanContext context, ICatanEvents events, IPlayer currentPlayer, ITitle largestArmy)
        {
            currentPlayer.PurchaseBonusCard(Constants.BonusCardCost);
            currentPlayer.ReduceResources(Constants.BonusCardCost);
            largestArmy.ProcessOwner(currentPlayer);
            events.OnPlayer(context);
        }

        public void StartRoadBuilding(ICatanContext context, ICatanEvents events)
        {
            events.OnRoadBuildingStarted(context.GetBuildableRoadsByPlayer());
            context.SetContext(new RoadBuildingState());
        }

        public void StartSettlementBuilding(ICatanContext context, ICatanEvents events)
        {
            events.OnSettlementBuildingStarted(context.GetBuildableSettlementsByPlayer());
            context.SetContext(new SettlementBuildingState());
        }

        public void StartSettlementUpgrading(ICatanContext context, ICatanEvents events)
        {
            events.OnSettlementUpgradingStarted(context.GetUpgradeableSettlementsByPlayer());
            context.SetContext(new SettlementUpgradingState());
        }
    }
}

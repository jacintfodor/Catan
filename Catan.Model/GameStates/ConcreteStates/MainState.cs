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

        public void EndTurn(ICatanContext context)
        {
            //TODO check winner

            context.NextPlayer();
            context.Events.OnPlayer(context);

            //context.Events.OnBuildableByPlayer(context);
            context.SetContext(new RollingState());
        }

        public void ExchangeWithBank(ICatanContext context, ResourceEnum from, ResourceEnum to)
        {
            //TODO handle from=to as invalid
            context.CurrentPlayer.ReduceResources(new Goods(from) * 3);
            context.CurrentPlayer.AddResource(new Goods(to));
            context.Events.OnPlayer(context);
        }

        public bool IsAffordable(ICatanContext context, Goods g)
        {
            return context.CurrentPlayer.CanAfford(g);
        }

        //Crop, Ore, Wood, Brick, Wool
        public void PurchaseBonusCard(ICatanContext context)
        {
            context.CurrentPlayer.PurchaseBonusCard(Constants.BonusCardCost);
            context.CurrentPlayer.ReduceResources(Constants.BonusCardCost);
            context.LargestArmyHolder.ProcessOwner(context.CurrentPlayer);
            context.Events.OnPlayer(context);
        }

        public void StartRoadBuilding(ICatanContext context)
        {
            context.Events.OnRoadBuildingStarted(context.Board.GetBuildableRoadsByPlayer(context.CurrentPlayer.ID));
            context.SetContext(new RoadBuildingState());
        }

        public void StartSettlementBuilding(ICatanContext context)
        {
            context.Events.OnSettlementBuildingStarted(context.Board.GetBuildableSettlementsByPlayer(context.State, context.CurrentPlayer.ID));
            context.SetContext(new SettlementBuildingState());
        }

        public void StartSettlementUpgrading(ICatanContext context)
        {
            context.Events.OnSettlementUpgradingStarted(context.Board.GetUpgradeableSettlementsByPlayer(context.CurrentPlayer.ID));
            context.SetContext(new SettlementUpgradingState());
        }
    }
}

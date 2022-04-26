using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates
{
    internal class MainState : AbstractMainState
    {
        public override bool IsMainState => true;

        public override sealed void EndTurn(CatanContext context)
        {
            //TODO check winner

            context.NextPlayer();
            context.Events.OnPlayer(context);

            //context.Events.OnBuildableByPlayer(context);
            context.SetContext(new RollingState());
        }

        public override sealed void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to)
        {
            //TODO handle from=to as invalid
            context.CurrentPlayer.ReduceResources((new Goods(from) * 3));
            context.CurrentPlayer.AddResource(new Goods(to));
            context.Events.OnPlayer(context);
        }

        public override sealed bool IsAffordable(CatanContext context, Goods g)
        {
            return context.CurrentPlayer.CanAfford(g);
        }

        //Crop, Ore, Wood, Brick, Wool
        public override sealed void PurchaseBonusCard(CatanContext context)
        {
            context.CurrentPlayer.PurchaseBonusCard(Constants.BonusCardCost);
            context.CurrentPlayer.ReduceResources(Constants.BonusCardCost);
            context.LargestArmyHolder.ProcessOwner(context.CurrentPlayer);
            context.Events.OnPlayer(context);
        }

        public override sealed void StartRoadBuilding(CatanContext context)
        {
            context.Events.OnRoadBuildingStarted(context.GetBuildableRoadsByPlayer());
            context.SetContext(new RoadBuildingState());
        }

        public override sealed void StartSettlementBuilding(CatanContext context)
        {
            context.Events.OnSettlementBuildingStarted(context.GetBuildableSettlementsByPlayer());
            context.SetContext(new SettlementBuildingState());
        }

        public override sealed void StartSettlementUpgrading(CatanContext context)
        {
            context.Events.OnSettlementUpgradingStarted(context.GetUpgradeableSettlementsByPlayer());
            context.SetContext(new SettlementUpgradingState());
        }

        public override sealed void StartTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }
    }
}

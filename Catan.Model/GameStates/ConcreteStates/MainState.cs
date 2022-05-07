using Catan.Model.Context.Players;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;
using Catan.Model.DTOs;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class MainState : ICatanGameState, IMainState
    {
        public bool IsMainState => true;

        public void EndTurn(ICatanContext context)
        {
            if (context.Winner == context.CurrentPlayer)
            {
                context.Events.OnGameWon(context);
                context.SetContext(new GameWonState());
            }
            else
            {
                context.NextPlayer();
                context.Events.OnPlayerUpdated(context);

                context.SetContext(new RollingState());
            }
        }

        public void ExchangeWithBank(ICatanContext context, ResourceEnum from, ResourceEnum to)
        {
            //TODO handle from=to as invalid
            context.CurrentPlayer.ReduceResources(new Goods(from) * 3);
            context.CurrentPlayer.AddResource(new Goods(to));
            context.Events.OnPlayerUpdated(context);
        }

        //Crop, Ore, Wood, Brick, Wool
        public void PurchaseBonusCard(ICatanContext context)
        {
            context.CurrentPlayer.PurchaseBonusCard(Constants.BonusCardCost);
            context.CurrentPlayer.ReduceResources(Constants.BonusCardCost);
            context.LargestArmyHolder.ProcessOwner(context.CurrentPlayer);
            context.Events.OnPlayerUpdated(context);
        }

        public void StartRoadBuilding(ICatanContext context)
        {
            List<EdgeDTO> buildableRoadCandidates =
                context.Board.GetBuildableRoadsByPlayer(context.CurrentPlayer.ID)
                .Select(e => Mapping.Mapper.Map<EdgeDTO>(e))
                .ToList();
            context.Events.OnRoadBuildingStarted(buildableRoadCandidates);
            context.SetContext(new RoadBuildingState());
        }

        public void StartSettlementBuilding(ICatanContext context)
        {
            List<VertexDTO> buildableSettlementCandidates =
                context.Board.GetBuildableSettlementsByPlayer(context.State, context.CurrentPlayer.ID)
                .Select(v => Mapping.Mapper.Map<VertexDTO>(v))
                .ToList();
            context.Events.OnSettlementBuildingStarted(buildableSettlementCandidates);
            context.SetContext(new SettlementBuildingState());
        }

        public void StartSettlementUpgrading(ICatanContext context)
        {
            List<VertexDTO> upgradableSettlements =
                context.Board.GetUpgradeableSettlementsByPlayer(context.CurrentPlayer.ID)
                .Select(v => Mapping.Mapper.Map<VertexDTO>(v))
                .ToList();
            context.Events.OnSettlementUpgradingStarted(upgradableSettlements);
            context.SetContext(new SettlementUpgradingState());
        }
    }
}

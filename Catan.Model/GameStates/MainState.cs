using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;
using Catan.Model.Board.Buildings;
using Catan.Model.Context;

namespace Catan.Model.GameStates
{
    public class MainState : ICatanGameState
    {
        public void AcceptTrade(CatanContext context)
        {
            
        }

        public void DenyTrade(CatanContext context)
        {
            
        }

        public void EndTurn(CatanContext context)
        {
            context.NextPlayer();
        }

        public void ExchangeWithBank(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public bool HasEnoughResourcesToBuildRoad(CatanContext context)
        {
            return context.CurrentPlayer.CanAfford(Road.BuildCost);
        }

        public bool HasEnoughResourcesToBuildSettlement(CatanContext context)
        {
            return context.CurrentPlayer.CanAfford(Settlement.BuildCost);
        }

        public bool HasEnoughResourcesToUpgradeSettlementToTown(CatanContext context)
        {
            return context.CurrentPlayer.CanAfford(Town.BuildCost);
        }

        public bool IsGameInProgress(CatanContext context)
        {
            return context.Winner == NotPlayer.Instance;
        }

        public bool IsTradeInProgress(CatanContext context)
        {
            return false;
        }

        public void MoveRogue(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        //Crop, Ore, Wood, Brick, Wool
        public void PurchaseBonusCard(CatanContext context)
        {
            if (context.CurrentPlayer.CanAfford(new Goods(new List<int> { 1, 1, 0, 0, 1 })))
                context.CurrentPlayer.ReduceResources(new Goods(new List<int> { 1, 1, 0, 0, 1 }));
        }

        public void StartTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void RollDices(CatanContext context)
        {
            context.FirstDice.roll();
            context.SecondDice.roll();

            context.Board.distributeResource(context.RolledSum);
        }
    }
}

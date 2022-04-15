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

        public void BuildRoad(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
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
            
        }

        public void EndTurn(CatanContext context)
        {
            context.NextPlayer();
            
            context.Events.OnTransactionsHappened(context);
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
            if (context.CurrentPlayer.CanAfford(new Goods(new List<int> { 1, 1, 0, 0, 1 })))
                context.CurrentPlayer.ReduceResources(new Goods(new List<int> { 1, 1, 0, 0, 1 }));
        }

        public void RollDices(CatanContext context)
        {
            context.FirstDice.roll();
            context.SecondDice.roll();

            context.Board.distributeResource(context.RolledSum);
            
            context.Events.OnDiceThrown(context);
            context.Events.OnTransactionsHappened(context);
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

        public bool IsMainState => true;
    }
}

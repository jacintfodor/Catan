using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.GameStates;

namespace Catan.Model.GameStates
{
    public class EarlyRollingState : ICatanGameState
    {
        private int _rollCount = 0;

        public bool IsEarlyRollingState => true;

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
            ++_rollCount;
            context.FirstDice.roll();
            context.SecondDice.roll();

            context.Events.OnDiceThrown(context);
            if (_rollCount == 3)
            {
                var list = context.Board.GetVerticesEnumerable().ToList().Where(v => !v.IsNotBuildable).ToList();
                context.Events.OnSettlementBuildingStarted(list);

                context.SetContext(new EarlySettlementBuildingState(0));
            }
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

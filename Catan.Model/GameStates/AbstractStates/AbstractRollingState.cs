using Catan.Model.Context;
using Catan.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates.AbstractStates
{
    internal abstract class AbstractRollingState : ICatanGameState
    {
        public void AcceptTrade(CatanContext context) { }
        public void BuildRoad(CatanContext context, int row, int col) { }
        public void BuildSettleMent(CatanContext context, int row, int col) { }
        public void Cancel(CatanContext context) { }
        public void DenyTrade(CatanContext context) { }
        public void EndTurn(CatanContext context) { }
        public void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to) { }
        public bool IsAffordable(CatanContext context, Goods g) { return false; }
        public void MoveRogue(CatanContext context, int row, int col) { }
        public void PurchaseBonusCard(CatanContext context) {  }
        public abstract void RollDices(CatanContext context);
        public void StartRoadBuilding(CatanContext context) { }
        public void StartSettlementBuilding(CatanContext context) { }
        public void StartSettlementUpgrading(CatanContext context) { }
        public void StartTrade(CatanContext context) { }
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col) { }
    }
}

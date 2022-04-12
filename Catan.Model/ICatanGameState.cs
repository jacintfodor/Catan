using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model
{
    interface ICatanGameState
    {
        public void EndTurn(CatanContext context);
        public void RollDices(CatanContext context);
        public void MoveRogue(CatanContext context, int row, int col);
        public void IsAffordable(CatanContext context, Goods g);
        public void ExchangeWithBank(CatanContext context);
        public void PurchaseBonusCard(CatanContext context);
        public void StartRoadBuilding(CatanContext context);
        public void BuildRoad(CatanContext context, int row, int col);
        public void StartSettlementBuilding(CatanContext context);
        public void BuildSettleMent(CatanContext context, int row, int col);
        public void StartSettlementUpgrading(CatanContext context);
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col);
        public void Cancel(CatanContext context);
        public void StartTrade(CatanContext context);
        public void AcceptTrade(CatanContext context);
        public void DenyTrade(CatanContext context);

        public bool IsEarlyRollingState() { return false; }
        public bool IsEarlySettlementBuildingState() { return false; }
        public bool IsEarlyRoadBuildingState() { return false; }
        public bool IsRollingState() { return false; }
        public bool IsMainState() { return false; }
        public bool IsSettlementBuildingState() { return false; }
        public bool IsRoadBuildingState() { return false; }
        public bool IsSettlementUpgradingState() { return false; }
        public bool IsWinningState() { return false; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;
using Catan.Model.Enums;

namespace Catan.Model.GameStates
{
    public interface ICatanGameState
    {
        public void EndTurn(CatanContext context);
        public void RollDices(CatanContext context);
        public void MoveRogue(CatanContext context, int row, int col);
        public bool IsAffordable(CatanContext context, Goods g);
        public void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to);
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

        public bool IsEarlyRollingState { get; }
        public bool IsEarlySettlementBuildingState { get; }
        public bool IsEarlyRoadBuildingState { get; }
        public bool IsRollingState { get; }
        public bool IsMainState { get; }
        public bool IsSettlementBuildingState { get; }
        public bool IsRoadBuildingState { get; }
        public bool IsSettlementUpgradingState { get; }
        public bool IsWinningState { get; }
        public bool IsRogueMovingState { get; }
    }
}

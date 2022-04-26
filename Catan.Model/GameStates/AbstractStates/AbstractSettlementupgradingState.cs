using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.GameStates.AbstractStates
{
    internal abstract class AbstractSettlementupgradingState : ICatanGameState
    {
        public abstract bool IsSettlementUpgradingState { get; }
        public abstract void Cancel(CatanContext context);
        public abstract void UpgradeSettleMentToTown(CatanContext context, int row, int col);




        public bool IsEarlyRollingState => false;
        public bool IsEarlySettlementBuildingState => false;
        public bool IsEarlyRoadBuildingState => false;
        public bool IsRollingState => false;
        public bool IsMainState => false;
        public bool IsSettlementBuildingState => false;
        public bool IsRoadBuildingState => false;
        public bool IsWinningState => false;
        public bool IsRogueMovingState => false;

        public void AcceptTrade(CatanContext context) { }
        public void BuildRoad(CatanContext context, int row, int col) { }
        public void BuildSettleMent(CatanContext context, int row, int col) { }
        public void DenyTrade(CatanContext context) { }
        public void EndTurn(CatanContext context) { }
        public void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to) { }
        public bool IsAffordable(CatanContext context, Goods g) { return false; }
        public void MoveRogue(CatanContext context, int row, int col) { }
        public void PurchaseBonusCard(CatanContext context) { }
        public void RollDices(CatanContext context) { }
        public void StartRoadBuilding(CatanContext context) { }
        public void StartSettlementBuilding(CatanContext context) { }
        public void StartSettlementUpgrading(CatanContext context) { }
        public void StartTrade(CatanContext context) { }
    }
}

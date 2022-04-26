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
    internal abstract class AbstractMainState : ICatanGameState
    {
        public abstract bool IsMainState { get; }

        public abstract void EndTurn(CatanContext context);
        public abstract void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to);
        public abstract bool IsAffordable(CatanContext context, Goods g);
        public abstract void PurchaseBonusCard(CatanContext context);
        public abstract void StartRoadBuilding(CatanContext context);
        public abstract void StartSettlementBuilding(CatanContext context);
        public abstract void StartSettlementUpgrading(CatanContext context);
        public abstract void StartTrade(CatanContext context);


        public bool IsEarlyRollingState => false;
        public bool IsEarlySettlementBuildingState => false;
        public bool IsEarlyRoadBuildingState => false;
        public bool IsRollingState => false;
        public bool IsSettlementBuildingState => false;
        public bool IsRoadBuildingState => false;
        public bool IsSettlementUpgradingState => false;
        public bool IsWinningState => false;
        public bool IsRogueMovingState => false;

        public void AcceptTrade(CatanContext context) { }
        public void BuildRoad(CatanContext context, int row, int col) { }
        public void BuildSettleMent(CatanContext context, int row, int col) { }
        public void Cancel(CatanContext context) { }
        public void DenyTrade(CatanContext context) { }
        public void MoveRogue(CatanContext context, int row, int col) { }
        public void RollDices(CatanContext context) { }
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col) { }
    }
}

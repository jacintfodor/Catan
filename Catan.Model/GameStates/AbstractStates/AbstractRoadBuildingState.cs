using Catan.Model.Context;
using Catan.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates.AbstractStates
{
    internal abstract class AbstractRoadBuildingState : ICatanGameState
    {
        #region overridable members
        public abstract bool IsRoadBuildingState { get; }
        public abstract bool IsEarlyRoadBuildingState { get; }

        public abstract void BuildRoad(CatanContext context, int row, int col);
        public abstract void Cancel(CatanContext context);
        #endregion


        #region sealed members
        public bool IsEarlyRollingState => false;
        public bool IsEarlySettlementBuildingState => false;
        public bool IsRollingState => false;
        public bool IsMainState => false;
        public bool IsSettlementBuildingState => false;
        public bool IsSettlementUpgradingState => false;
        public bool IsWinningState => false;
        public bool IsRogueMovingState => false;

        public void AcceptTrade(CatanContext context) { }
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
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col) { }
        #endregion
    }
}

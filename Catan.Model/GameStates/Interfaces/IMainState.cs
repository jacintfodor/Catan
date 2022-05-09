﻿using Catan.Model.Enums;

namespace Catan.Model.GameStates.Interfaces
{
    public interface IMainState
    {
        public void EndTurn(ICatanContext context);
        public void ExchangeWithBank(ICatanContext context, ResourceEnum from, ResourceEnum to);
        public void PurchaseBonusCard(ICatanContext context);
        public void StartRoadBuilding(ICatanContext context);
        public void StartSettlementBuilding(ICatanContext context);
        public void StartSettlementUpgrading(ICatanContext context);
    }
}

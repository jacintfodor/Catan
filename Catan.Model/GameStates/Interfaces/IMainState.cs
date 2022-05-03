using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Enums;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IMainState
    {
        public void EndTurn(ICatanContext context);
        public void ExchangeWithBank(ICatanContext context, ResourceEnum from, ResourceEnum to);
        public void PurchaseBonusCard(ICatanContext context);
        public void StartRoadBuilding(ICatanContext context);
        public void StartSettlementBuilding(ICatanContext context);
        public void StartSettlementUpgrading(ICatanContext context);
    }
}

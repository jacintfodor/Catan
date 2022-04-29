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
        public void EndTurn(CatanContext context);
        public void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to);
        public void PurchaseBonusCard(CatanContext context);
        public void StartRoadBuilding(CatanContext context);
        public void StartSettlementBuilding(CatanContext context);
        public void StartSettlementUpgrading(CatanContext context);
    }
}

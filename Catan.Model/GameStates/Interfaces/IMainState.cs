using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Enums;
using Catan.Model.Context;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IMainState
    {
        public void EndTurn(CatanContext context);
        public void ExchangeWithBank(CatanContext context, IPlayer currentPlayer, ResourceEnum from, ResourceEnum to);
        public void PurchaseBonusCard(CatanContext context, IPlayer currentPlayer, ITitle largestArmy);
        public void StartRoadBuilding(CatanContext context);
        public void StartSettlementBuilding(CatanContext context);
        public void StartSettlementUpgrading(CatanContext context);
    }
}

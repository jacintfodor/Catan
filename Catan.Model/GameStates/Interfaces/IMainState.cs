using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IMainState
    {
        public void EndTurn(ICatanContext context, ICatanEvents events);
        public void ExchangeWithBank(ICatanContext context, ICatanEvents events, IPlayer currentPlayer, ResourceEnum from, ResourceEnum to);
        public void PurchaseBonusCard(ICatanContext context, ICatanEvents events, IPlayer currentPlayer, ITitle largestArmy);
        public void StartRoadBuilding(ICatanContext context, ICatanEvents events);
        public void StartSettlementBuilding(ICatanContext context, ICatanEvents events);
        public void StartSettlementUpgrading(ICatanContext context, ICatanEvents events);
    }
}

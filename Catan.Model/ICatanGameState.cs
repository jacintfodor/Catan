using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{
    interface ICatanGameState
    {
        public void EndTurn(CatanContext context);
        public void ThrowDices(CatanContext context);
        public void MoveRogue(CatanContext context, int row, int col);
        public void ExchangeWithBank(CatanContext context);
        public void PurchaseBonusCard(CatanContext context);
        public void BuildRoad(CatanContext context, int row, int col);
        public void BuildSettleMent(CatanContext context, int row, int col);
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col);
        public void StartTrade(CatanContext context);
        public void AcceptTrade(CatanContext context);
        public void DenyTrade(CatanContext context);
        public bool IsGameInProgress(CatanContext context);
        public bool IsTradeInProgress(CatanContext context);
        public bool HasEnoughResourcesToBuildRoad(CatanContext context);
        public bool HasEnoughResourcesToBuildSettlement(CatanContext context);
        public bool HasEnoughResourcesToUpgradeSettlementToTown(CatanContext context);
        public bool IsSettlementOwnedByCurrentPlayer(CatanContext context, int row, int col);

    }
}

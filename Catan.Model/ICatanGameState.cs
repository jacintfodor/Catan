using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model
{
    interface ICatanGameState
    {
        public void EndTurn(CatanContext context);
        public void RollDices(CatanContext context);
        public void MoveRogue(CatanContext context, int row, int col);
        public void IsAffordable(CatanContext context, Goods g);
        public void ExchangeWithBank(CatanContext context);
        public void PurchaseBonusCard(CatanContext context);
        public void BuildRoad(CatanContext context, int row, int col);
        public void BuildSettleMent(CatanContext context, int row, int col);
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col);
        public void StartTrade(CatanContext context);
        public void AcceptTrade(CatanContext context);
        public void DenyTrade(CatanContext context);

    }
}

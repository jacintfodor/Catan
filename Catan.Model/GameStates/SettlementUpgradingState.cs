using Catan.Model.Context;
using Catan.Model.Enums;

namespace Catan.Model.GameStates
{
    public class SettlementUpgradingState : ICatanGameState
    {
        public bool IsSettlementUpgradingState => true;

        public SettlementUpgradingState()
        {

        }

        public void AcceptTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void BuildRoad(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void BuildSettleMent(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void Cancel(CatanContext context)
        {
            context.Events.OnCancel();
            context.SetContext(new MainState());
        }

        public void DenyTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void EndTurn(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void ExchangeWithBank(CatanContext context, ResourceEnum from, ResourceEnum to)
        {
            throw new NotImplementedException();
        }

        public void IsAffordable(CatanContext context, Goods g)
        {
            throw new NotImplementedException();
        }

        public void MoveRogue(CatanContext context, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void PurchaseBonusCard(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void RollDices(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartRoadBuilding(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartSettlementBuilding(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartSettlementUpgrading(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void StartTrade(CatanContext context)
        {
            throw new NotImplementedException();
        }

        public void UpgradeSettleMentToTown(CatanContext context, int row, int col)
        {

            context.Board.UpgradeSettlement(row, col);
            context.Events.OnSettlementUpgraded(context, row, col);

            context.CurrentPlayer.BuildTown();
            context.CurrentPlayer.ReduceResources(Constants.TownCost);
            context.Events.OnPlayer(context);
            context.SetContext(new MainState());
        }
    }
}

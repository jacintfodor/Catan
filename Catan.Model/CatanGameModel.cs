using Catan.Model.Events;
using Catan.Model.Enums;
using Catan.Model.Context;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model
{
    public class CatanGameModel
    {
        private ICatanContext _catanContext = new CatanContext(new EarlyRollingState());

        public ICatanEvents Events { get => _catanContext.Events; }

        public bool IsRollValid => _catanContext.State is IRollable;

        public bool IsSettlementBuildingValid =>
            _catanContext.State is IMainState && 
            _catanContext.CurrentPlayer.CanAfford(Constants.SettlementCost) && 
            _catanContext.CurrentPlayer.CanBuildSettlement();

        public bool IsTownBuildingValid =>
            _catanContext.State is IMainState &&
            _catanContext.CurrentPlayer.CanAfford(Constants.TownCost) &&
            _catanContext.CurrentPlayer.CanBuildTown();

        public bool IsEndTurnValid => _catanContext.IsMainState;

        public bool IsPurchaseBonusCardValid =>
            _catanContext.State is IMainState &&
            _catanContext.CurrentPlayer.CanAfford(Constants.BonusCardCost);

        public bool IsRoadBuildingValid =>
            _catanContext.State is IMainState &&
            _catanContext.CurrentPlayer.CanAfford(Constants.RoadCost) &&
            _catanContext.CurrentPlayer.CanBuildRoad();

        public bool IsCancelValid =>
            _catanContext.State is ICancellable;

        public bool IsExchangeWithBankValid(ResourceEnum from, ResourceEnum to)
        {
            return _catanContext.State is IMainState &&
                from != to &&
                _catanContext.CurrentPlayer.CanAfford(new Goods(from) * 3);
        }

        public void NewGame()
        {
            _catanContext.reset();
            _catanContext.NewGame();
        }

        public void EndTurn()
        {
            _catanContext.EndTurn();
        }
        public void RollDices()
        {
            _catanContext.RollDices();
        }
        public void MoveRogue(int row, int col)
        {
            _catanContext.MoveRogue(row, col);
        }
        public void ExchangeWithBank(ResourceEnum from, ResourceEnum to)
        {
            _catanContext.ExchangeWithBank(from, to);
        }
        public void PurchaseBonusCard()
        {
            _catanContext.PurchaseBonusCard();
        }
        public void StartRoadBuilding()
        {
            _catanContext.StartRoadBuilding();
        }
        public void StartSettlementBuilding()
        {
            _catanContext.StartSettlementBuilding();
        }
        public void StartSettlementUpgrading()
        {
            _catanContext.StartSettlementUpgrading();
        }
        public void Cancel()
        {
            _catanContext.Cancel(); 
        }
        public void BuildRoad(int row, int col)
        {
            _catanContext.BuildRoad(row, col);
        }
        public void BuildSettleMent(int row, int col)
        {
            _catanContext.BuildSettleMent(row, col);
        }
        public void UpgradeSettleMentToTown(int row, int col)
        {
            _catanContext.UpgradeSettleMentToTown(row, col);
        }
        public void StartTrade()
        {
            throw new NotImplementedException();
        }
        public void AcceptTrade()
        {
            throw new NotImplementedException();
        }
        public void DenyTrade()
        {
            throw new NotImplementedException();
        }
    }
}

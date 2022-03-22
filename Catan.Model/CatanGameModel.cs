using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.GameStates;
using Catan.Model.Events;

namespace Catan.Model
{
    public class CatanGameModel
    {
        private CatanContext _catanContext;
        private MainState _mainState;
        
        private ICatanGameState _currentState;

        public event EventHandler<DicesThrownEventArg> DicesThrown;
        public event EventHandler<GameStartEventArgs> GameStart;

        public CatanGameModel()
        {
            _catanContext = CatanContext.Instance;
            _mainState = new MainState();

            _currentState = _mainState;
        }

        public void NewGame()
        {
            _currentState = _mainState;
            _catanContext.reset();
        }

        public void EndTurn()
        {
            _currentState.EndTurn(_catanContext);
        }
        public void ThrowDices()
        {
            _currentState.ThrowDices(_catanContext);
            OnDiceThrown();

        }
        public void MoveRogue(int row, int col)
        {
            _currentState.MoveRogue(_catanContext, row, col);
        }
        public void ExchangeWithBank()
        {
            _currentState.ExchangeWithBank(_catanContext);
        }
        public void PurchaseBonusCard()
        {
            _currentState.PurchaseBonusCard(_catanContext);
        }
        public void BuildRoad(int row, int col)
        {
            _currentState.BuildRoad(_catanContext, row, col);
        }
        public void BuildSettleMent(int row, int col)
        {
            _currentState.BuildSettleMent(_catanContext, row, col);   
        }
        public void UpgradeSettleMentToTown(int row, int col)
        {
            _currentState.UpgradeSettleMentToTown(_catanContext, row, col);
        }
        public void StartTrade()
        {
            _currentState.StartTrade(_catanContext);
        }
        public void AcceptTrade()
        {
            _currentState.AcceptTrade(_catanContext);
        }
        public void DenyTrade()
        {
            _currentState.DenyTrade(_catanContext);
        }
        public bool IsGameInProgress()
        {
            return _currentState.IsGameInProgress(_catanContext);
        }
        public bool IsTradeInProgress()
        {
            return _currentState.IsTradeInProgress(_catanContext);
        }
        public bool HasEnoughResourcesToBuildRoad()
        {
            return _currentState.HasEnoughResourcesToBuildRoad(_catanContext);
        }
        public bool HasEnoughResourcesToBuildSettlement()
        {
            return _currentState.HasEnoughResourcesToBuildSettlement(_catanContext);
        }
        public bool HasEnoughResourcesToUpgradeSettlementToTown()
        {
            return _currentState.HasEnoughResourcesToUpgradeSettlementToTown(_catanContext);
        }

        public bool IsSettlementOwnedByCurrentPlayer(int row, int col)
        {
            return _currentState.IsSettlementOwnedByCurrentPlayer(_catanContext, row, col);
        }



        private void OnDiceThrown()
        {
            DicesThrown?.Invoke(
                this,
                new DicesThrownEventArg(_catanContext.FirstDice.RolledValue,
                                         _catanContext.SecondDice.RolledValue));
        }
    }
}

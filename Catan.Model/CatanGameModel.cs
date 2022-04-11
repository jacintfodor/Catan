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
        private CatanContext _catanContext = CatanContext.Instance;

        public event EventHandler<DicesThrownEventArg> DicesThrown;
        public event EventHandler<GameStartEventArgs> GameStart;

        public void NewGame()
        {
            _catanContext.reset();
            if (GameStart is not null)
            {
                GameStart(this, new GameStartEventArgs(_catanContext.Board.Hexes, _catanContext.Board.Vertices, _catanContext.Board.Edges));
            }
        }

        public void EndTurn()
        {
            throw new NotImplementedException();
        }
        public void ThrowDices()
        {
            throw new NotImplementedException();

        }
        public void MoveRogue(int row, int col)
        {
            throw new NotImplementedException();
        }
        public void ExchangeWithBank()
        {
            throw new NotImplementedException();
        }
        public void PurchaseBonusCard()
        {
            throw new NotImplementedException();
        }
        public void BuildRoad(int row, int col)
        {
            throw new NotImplementedException();
        }
        public void BuildSettleMent(int row, int col)
        {
            throw new NotImplementedException();
        }
        public void UpgradeSettleMentToTown(int row, int col)
        {
            throw new NotImplementedException();
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
        public bool IsGameInProgress()
        {
            throw new NotImplementedException();
        }
        public bool IsTradeInProgress()
        {
            throw new NotImplementedException();
        }
        public bool HasEnoughResourcesToBuildRoad()
        {
            throw new NotImplementedException();
        }
        public bool HasEnoughResourcesToBuildSettlement()
        {
            throw new NotImplementedException();
        }
        public bool HasEnoughResourcesToUpgradeSettlementToTown()
        {
            throw new NotImplementedException();
        }

        public bool IsSettlementOwnedByCurrentPlayer(int row, int col)
        {
            throw new NotImplementedException();
        }



        private void OnDiceThrown()
        {
            DicesThrown?.Invoke(
                this,
                new DicesThrownEventArg(_catanContext.FirstDice.RolledValue,
                                         _catanContext.SecondDice.RolledValue,
                                         _catanContext.CurrentPlayer.AvailableResources
            )) ;
        }
    }
}

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
        private CatanContext _catanContext = new(new MainState());

        public CatanEvents Events { get => CatanContext.Events; }

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
            Events.OnDiceThrown(_catanContext);

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
    }
}

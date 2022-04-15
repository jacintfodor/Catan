using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Context.Titles;
using Catan.Model.Context.Players;
using Catan.Model.Board;
using Catan.Model.Events;
using Catan.Model.GameStates;

namespace Catan.Model
{
    public class CatanContext
    {
        private Queue<IPlayer> _players = new();

        public void NewGame()
        {
            Events.OnGameStart(this);
        }

        public CatanContext(ICatanGameState initialState)
        {
            SetContext(initialState);
            init();
        }
        public CatanBoard Board { get; private set; }
        public CubeDice FirstDice { get; private set; }
        public CubeDice SecondDice { get; private set; }
        
        public int RolledSum { get => FirstDice.RolledValue + SecondDice.RolledValue; }

        public CatanEvents Events { get => CatanEvents.Instance; }

        public static LargestArmyHolder LargestArmyHolder { get => LargestArmyHolder.Instance;}
        public static LongestRoadOwner LongestRoadOwner { get => LongestRoadOwner.Instance;}
        public IPlayer CurrentPlayer { get => _players.ElementAtOrDefault(0) ?? NotPlayer.Instance;}
        public IPlayer NextPlayerInQueue { get => _players.ElementAtOrDefault(1) ?? NotPlayer.Instance; }
        public IPlayer NextNextPlayerInQueue { get => _players.ElementAtOrDefault(2) ?? NotPlayer.Instance; }
        public IPlayer Winner { get => CurrentPlayer.CalculateScore() >= 5 ? CurrentPlayer : NotPlayer.Instance;  }
        public void NextPlayer() { _players.Enqueue( _players.Dequeue()); }

        public void init()
        {
            Board = new();
            Random rng = new Random();
            FirstDice = new(rng.Next());
            SecondDice = new(rng.Next());

            _players.Enqueue(new Player("P1"));
            _players.Enqueue(new Player("P2"));
            _players.Enqueue(new Player("P3"));

            CurrentPlayer.AddResource(new Goods(new List<int> { 1, 1, 1, 1, 1 }));
            NextPlayerInQueue.AddResource(new Goods(new List<int> { 2, 2, 2, 2, 2 }));
            NextNextPlayerInQueue.AddResource(new Goods(new List<int> { 3, 3, 3, 3, 3 }));

            generateBuildings();
        }

        private void generateBuildings()
        {
            var rnd = new Random();
            var rnd2 = new Random(rnd.Next());
            var rnd3 = new Random(rnd2.Next());

            IPlayer p = NotPlayer.Instance;

            List<int> rows = new List<int>() {1, 1, 1, 1, 3, 3, 3, 5, 5, 2, 2, 2, 2, 4, 4};
            List<int> cols = new List<int>() {3, 5, 6, 7, 1, 5, 8, 4, 6, 2, 5, 6, 7, 4, 5};

            for( int i = 0; i < rows.Count; ++i)
            {
                int roll = rnd3.Next(100);
                if (roll > 70)
                    p = NextNextPlayerInQueue;
                else if (roll > 40)
                    p = NextPlayerInQueue;
                else
                    p = CurrentPlayer;


                bool build = rnd.Next(100) > 60;
                
                bool isTown = rnd2.Next(100) > 80;
                if (build)
                {
                    if (isTown)
                        Board.buildTown(rows[i], cols[i], p);
                    else
                        Board.buildSettlement(rows[i], cols[i], p);
                }

            }
            
        }

        public void clear()
        {
            _players.Clear();
        }

        public void reset()
        {
            clear();
            init();
        }

        //TODO change State to be an instance of EarlyRollingState once we can
        public ICatanGameState State { get; private set; } = new MainState();
        public void SetContext(ICatanGameState state) { State = state; }

        #region state dependent methods
        public void EndTurn() { State.EndTurn(this); }
        public void RollDices() { State.RollDices(this); }
        public void MoveRogue(int row, int col) { State.MoveRogue(this, row, col); }
        public void IsAffordable(Goods g) { State.IsAffordable(this, g); }
        public void ExchangeWithBank() { State.ExchangeWithBank(this); }
        public void PurchaseBonusCard() { State.PurchaseBonusCard(this); }
        public void StartRoadBuilding() { State.StartRoadBuilding(this); }
        public void BuildRoad(int row, int col) { State.BuildRoad(this, row, col); }
        public void StartSettlementBuilding() { State.StartSettlementBuilding(this); }
        public void BuildSettleMent(int row, int col) { State.BuildSettleMent(this, row, col); }
        public void StartSettlementUpgrading() { State.StartSettlementUpgrading(this); }
        public void UpgradeSettleMentToTown(int row, int col) { State.UpgradeSettleMentToTown(this, row, col); }
        public void Cancel() { State.Cancel(this); }
        public void StartTrade() { State.StartTrade(this); }
        public void AcceptTrade() { State.AcceptTrade(this); }
        public void DenyTrade() { State.DenyTrade(this); }

        public bool IsEarlyRollingState => State.IsEarlyRollingState;
        public bool IsEarlySettlementBuildingState => State.IsEarlySettlementBuildingState;
        public bool IsEarlyRoadBuildingState => State.IsEarlyRoadBuildingState;
        public bool IsRollingState => State.IsRollingState;
        public bool IsMainState => State.IsMainState;
        public bool IsSettlementBuildingState => State. IsSettlementBuildingState;
        public bool IsRoadBuildingState => State.IsRoadBuildingState;
        public bool IsSettlementUpgradingState => State. IsSettlementUpgradingState;
        public bool IsWinningState => State.IsWinningState;
        #endregion
    }
}

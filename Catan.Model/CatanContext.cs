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
using Catan.Model.Enums;
using Catan.Model.Board.Components;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model
{
    internal class CatanContext : ICatanContext
    {
        private Queue<IPlayer> _players = new();

        public void NewGame()
        {
            Events.OnGameStart(this);
        }

        internal CatanContext(ICatanGameState initialState)
        {
            SetContext(initialState);
            init();
        }
        public ICatanBoard Board { get; private set; }
        public CubeDice FirstDice { get; private set; }
        public CubeDice SecondDice { get; private set; }

        public int RolledSum { get => FirstDice.RolledValue + SecondDice.RolledValue; }

        public Rogue Rogue { get => Rogue.Instance; }

        public ICatanEvents Events { get => CatanEvents.Instance; }

        public ITitle LargestArmyHolder { get => LargestArmyHolderTitle.Instance; }
        public ITitle LongestRoadOwner { get => LongestRoadOwnerTitle.Instance; }
        public IPlayer CurrentPlayer { get => _players.ElementAtOrDefault(0) ?? NotPlayer.Instance; }
        public IPlayer NextPlayerInQueue { get => _players.ElementAtOrDefault(1) ?? NotPlayer.Instance; }
        public IPlayer NextNextPlayerInQueue { get => _players.ElementAtOrDefault(2) ?? NotPlayer.Instance; }
        public IPlayer Winner { get => CurrentPlayer.CalculateScore() >= 5 ? CurrentPlayer : NotPlayer.Instance; }
        public void NextPlayer() { _players.Enqueue(_players.Dequeue()); }

        public void init()
        {
            Board = new CatanBoard();
            var desert = Board.GetHexesEnumerable().SkipWhile(x => x.Resource != ResourceEnum.Desert).ElementAt(0);
            Rogue.Row = desert.Row;
            Rogue.Col = desert.Col;

            Random rng = new Random();
            FirstDice = new(rng.Next());
            SecondDice = new(rng.Next());

            _players.Enqueue(new Player(PlayerEnum.Player1));
            _players.Enqueue(new Player(PlayerEnum.Player2));
            _players.Enqueue(new Player(PlayerEnum.Player3));

            /*
            CurrentPlayer.AddResource(new Goods(new List<int> { 5, 5, 5, 5, 5 }));
            NextPlayerInQueue.AddResource(new Goods(new List<int> { 10, 10, 10, 10, 10 }));
            NextNextPlayerInQueue.AddResource(new Goods(new List<int> { 15, 15, 15, 15, 15 }));
            */
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
        private ICatanGameState State { get; set; } = new EarlyRollingState();
        public void SetContext(ICatanGameState state) { State = state; }

        #region state dependent methods
        public void EndTurn()
        {
            var state = State as IMainState;
            state?.EndTurn(this);
        }
        public void RollDices()
        {
            var state = State as IRollable;
            state?.RollDices(this);
        }
        public void MoveRogue(int row, int col)
        {
            var state = State as IRogueMovable;
            state?.MoveRogue(this, row, col);
        }
        public bool IsAffordable(Goods g) { return State.IsAffordable(this, g); }
        public void ExchangeWithBank(ResourceEnum from, ResourceEnum to)
        {
            var state = State as IMainState;
            state?.ExchangeWithBank(this, from, to);
        }
        public void PurchaseBonusCard()
        {
            var state = State as IMainState;
            state?.PurchaseBonusCard(this);
        }
        public void StartRoadBuilding()
        {
            var state = State as IMainState;
            state?.StartRoadBuilding(this);
        }
        public void BuildRoad(int row, int col)
        {
            var state = State as IRoadBuildable;
            state?.BuildRoad(this, row, col);
        }
        public void StartSettlementBuilding()
        {
            var state = State as IMainState;
            state?.StartSettlementBuilding(this);
        }
        public void BuildSettleMent(int row, int col)
        {
            var state = State as ISettlementBuildable;
            state?.BuildSettleMent(this, row, col);
        }
        public void StartSettlementUpgrading()
        {
            var state = State as IMainState;
            state?.StartSettlementUpgrading(this);
        }
        public void UpgradeSettleMentToTown(int row, int col)
        {
            var state = State as ISettlementUpgradeable;
            state?.UpgradeSettleMentToTown(this, row, col);
        }
        public void Cancel()
        {
            var state = State as ICancellable;
            state?.Cancel(this);
        }
        public void StartTrade() { throw new NotImplementedException(); }
        public void MakeOffer(/* TODO offer vars*/) { throw new NotImplementedException(); }
        public void AcceptTrade() { throw new NotImplementedException(); }
        public void DenyTrade() { throw new NotImplementedException(); }

        public bool IsEarlyRollingState => State.IsEarlyRollingState;
        public bool IsEarlySettlementBuildingState => State.IsEarlySettlementBuildingState;
        public bool IsEarlyRoadBuildingState => State.IsEarlyRoadBuildingState;
        public bool IsRollingState => State.IsRollingState;
        public bool IsMainState => State.IsMainState;
        public bool IsSettlementBuildingState => State.IsSettlementBuildingState;
        public bool IsRoadBuildingState => State.IsRoadBuildingState;
        public bool IsSettlementUpgradingState => State.IsSettlementUpgradingState;
        public bool IsWinningState => State.IsWinningState;
        public bool IsRogueMovingState => State.IsRogueMovingState;
        #endregion

        #region Methods
        public void DistributeResources(int dieValue, bool isEarly = false)
        {
            foreach (IHex hex in Board.GetHexesEnumerable())
            {
                if (isEarly)
                    goto Early;
                if (hex.Value != dieValue || Rogue.Row == hex.Row && Rogue.Col == hex.Col)
                    continue;
                Early:
                Board.GetVerticesOfHex(hex.Row, hex.Col).ForEach(vertex =>
                {
                    if (vertex.Owner != PlayerEnum.NotPlayer)
                    {
                        int amount = (vertex.GetCommunity() is Town) ? 2 : 1;
                        foreach (IPlayer player in _players)
                        {
                            if (player.ID == vertex.Owner)
                                player.AddResource(new Goods(hex.Resource) * amount);
                        }
                    }
                });
            }
        }
        public int CalculateLongestRoadFromEdge(IEdge edge)
        {
            int retVal = 0;

            List<IEdge> processed = new List<IEdge>();
            List<IEdge> toProcess = new List<IEdge>();

            toProcess.Add(edge);
            while (toProcess.Any())
            {
                IEdge currentlyProccessing = toProcess.First();
                toProcess.Remove(currentlyProccessing);
                retVal++;

                Board.GetEdgesofEdge(currentlyProccessing.Row, currentlyProccessing.Col).ForEach(edge =>
                {
                    if (edge.Owner == CurrentPlayer.ID && !toProcess.Contains(edge) && !processed.Contains(edge) && edge != currentlyProccessing)
                        toProcess.Add(edge);
                });
                processed.Add(currentlyProccessing);
            }
            return retVal;
        }
        public List<IEdge> GetBuildableRoadsByPlayer()
        {
            List<IEdge> retVal = new List<IEdge>();
            foreach (IEdge edge in Board.GetEdgesEnumerable())
            {
                if (edge.IsBuildableByPlayer(CurrentPlayer.ID))
                    retVal.Add(edge);
            }

            return retVal;
        }
        public List<IVertex> GetBuildableSettlementsByPlayer()
        {
            List<IVertex> retVal = new List<IVertex>();
            foreach (IVertex vertex in Board.GetVerticesEnumerable())
            {
                if (vertex.IsBuildableByPlayer(CurrentPlayer.ID))
                    retVal.Add(vertex);
            }

            return retVal;
        }
        public List<IVertex> GetUpgradeableSettlementsByPlayer()
        {
            List<IVertex> retVal = new List<IVertex>();
            foreach (IVertex vertex in Board.GetVerticesEnumerable())
            {
                if (vertex.Owner == CurrentPlayer.ID && vertex.GetCommunity().IsUpgradeable)
                    retVal.Add(vertex);
            }

            return retVal;
        }
        public List<IPlayer> GetPlayerList()
        {
            return _players.ToList();
        }
        #endregion
    }
}

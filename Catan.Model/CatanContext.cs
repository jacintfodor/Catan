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

        public static Rogue Rogue { get => Rogue.Instance; }

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

            _players.Enqueue(new Player(PlayerEnum.Player1));
            _players.Enqueue(new Player(PlayerEnum.Player2));
            _players.Enqueue(new Player(PlayerEnum.Player3));

            CurrentPlayer.AddResource(new Goods(new List<int> { 1, 1, 1, 1, 1 }));
            NextPlayerInQueue.AddResource(new Goods(new List<int> { 2, 2, 2, 2, 2 }));
            NextNextPlayerInQueue.AddResource(new Goods(new List<int> { 3, 3, 3, 3, 3 }));

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
        public bool IsSettlementUpgradingState => State.IsSettlementUpgradingState;
        public bool IsWinningState => State.IsWinningState;
        #endregion

        #region methods
        public void DistributeResource(int dieValue)
        {
            foreach (IHex hex in Board.GetHexesEnumerable()) {
                if (hex.Value != dieValue)
                    continue;
                Board.getVerticesOfHex(hex.Row, hex.Col).ForEach(vertex =>
                {
                    if (vertex.Owner != PlayerEnum.NotPlayer)
                    {
                        int amount = (vertex.GetCommunity() is Town) ? 2 : 1;
                        foreach (IPlayer player in _players)
                        {
                            if(player.ID == vertex.Owner)
                                player.AddResource(new Goods(hex.Resource) * amount);
                        }
                    }
                });
            }
        }

        public int CalculateLongestRoadFromEdge(IEdge edge, PlayerEnum player)
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

                
                List<IEdge> connectedEdges = new List<IEdge>();
                List<IVertex> connectedVertices = Board.getNeighbourVerticesOfEdge(currentlyProccessing.Row,currentlyProccessing.Col);
                connectedVertices.ForEach(vertex => {
                    Board.getNeighborEdgesOfVertex(vertex.Row, vertex.Col).ForEach(edge =>
                    {
                        connectedEdges.Add(edge);
                    });
                });

                connectedEdges.ForEach(edge => {
                    if (edge.Owner == player && !toProcess.Contains(edge) && !processed.Contains(edge) && edge != currentlyProccessing)
                        toProcess.Add(edge);
                });
                processed.Add(currentlyProccessing);
            }
            return retVal;
        }
        #endregion
    }
}

using Catan.Model.Context;
using Catan.Model.Context.Titles;
using Catan.Model.Context.Players;
using Catan.Model.Board;
using Catan.Model.Events;
using Catan.Model.GameStates;
using Catan.Model.Enums;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Catan.Model.DTOs;
using Catan.Model.Board.Components.Hex;

namespace Catan.Model
{
    internal class CatanContext : ICatanContext
    {
        private Queue<IPlayer> _players = new();
        private ICatanBoard _board = new CatanBoard();
        private ICubeDice _firstDice;
        private ICubeDice _secondDice;
        private IRogue _rogue = Context.Rogue.Instance;
        private ICatanEvents _events = CatanEvents.Instance;
        private ITitle _largestArmy = LargestArmyTitle.Instance;
        private ITitle _longestRoad = LongestRoadTitle.Instance;
        public void NewGame()
        {
            Events.OnGameStarted(this);
        }

        internal CatanContext(ICatanGameState initialState)
        {
            SetContext(initialState);
            init();
        }

        internal CatanContext(ICatanGameState initialState,
            ICatanBoard board, ICubeDice firstDice, ICubeDice secondDice,
            IRogue rogue, ICatanEvents events, ITitle largestArmy, ITitle longestRoad,
            IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
        {
            SetContext(initialState);
            _players.Enqueue(playerOne);
            _players.Enqueue(playerTwo);
            _players.Enqueue(playerThree);
            _board = board;
            _firstDice = firstDice;
            _secondDice = secondDice;
            _rogue = rogue;
            _events = events;
            _largestArmy = largestArmy;
            _longestRoad = longestRoad;
        }

        public ICatanBoard Board { get => _board; private set => _board = value; }
        public ICubeDice FirstDice { get => _firstDice; private set => _firstDice = value; }
        public ICubeDice SecondDice { get => _secondDice; private set => _secondDice = value; }

        public int RolledSum { get => FirstDice.RolledValue + SecondDice.RolledValue; }

        public IRogue Rogue { get => _rogue; }

        public ICatanEvents Events { get => _events; }

        public ITitle LargestArmyHolder { get => _largestArmy; }
        public ITitle LongestRoadOwner { get => _longestRoad; }
        public IPlayer CurrentPlayer { get => _players.ElementAtOrDefault(0) ?? NotPlayer.Instance; }
        public IPlayer NextPlayerInQueue { get => _players.ElementAtOrDefault(1) ?? NotPlayer.Instance; }
        public IPlayer NextNextPlayerInQueue { get => _players.ElementAtOrDefault(2) ?? NotPlayer.Instance; }
        public IPlayer Winner { get => CurrentPlayer.Score >= 5 ? CurrentPlayer : NotPlayer.Instance; }
        public void NextPlayer() { _players.Enqueue(_players.Dequeue()); }

        public void init()
        {
            Board = new CatanBoard();
            var desert = Board.GetHexesEnumerable().SkipWhile(x => x.Resource != ResourceEnum.Desert).ElementAt(0);
            Rogue.Row = desert.Row;
            Rogue.Col = desert.Col;

            Random rng = new Random();
            FirstDice = new CubeDice(rng.Next());
            SecondDice = new CubeDice(rng.Next());

            _players.Enqueue(new Player(PlayerEnum.Player1));
            _players.Enqueue(new Player(PlayerEnum.Player2));
            _players.Enqueue(new Player(PlayerEnum.Player3));

            Events.OnPlayerUpdated(this);
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
        public ICatanGameState State { get; set; } = new EarlyRollingState();
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
        public bool IsAffordable(Goods g) { return CurrentPlayer.CanAfford(g); }
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

        public void DistributeResources(ICatanGameState state)
        {
            foreach (IHex hex in Board.GetHexesEnumerable())
            {
                if (IsDistributable(state, hex))
                {
                    foreach (var player in _players)
                    {

                        int noSettlementsAtHex = Board.GetVerticesOfHex(hex.Row, hex.Col)
                            .Where(v => v.Owner == player.ID && v.Type == CommunityEnum.Settlement)
                            .Count();

                        int noOfTownsAtHex = Board.GetVerticesOfHex(hex.Row, hex.Col)
                            .Where(v => v.Owner == player.ID && v.Type == CommunityEnum.Town)
                            .Count();

                        int noOfResourcesEarned = 2 * noOfTownsAtHex + noSettlementsAtHex;

                        Goods earned = new Goods(hex.Resource) * noOfResourcesEarned;

                        player.AddResource(earned);
                    }
                }
            }
        }

        public List<PlayerDTO> GetPlayerList()
        {
            List<PlayerDTO> playerDTO = new List<PlayerDTO>();
            foreach (IPlayer p in _players.ToList())
            {
                var dto = Mapping.Mapper.Map<PlayerDTO>(p);
                playerDTO.Add(dto);
            }
            return playerDTO;
        }
        #endregion

        private bool IsDistributable(ICatanGameState state, IHex hex)
        {
            return IsDistributableSpecialisation(state as dynamic, hex);
        }

        private bool IsDistributableSpecialisation(ICatanGameState state, IHex hex)
        {
            return false;
        }

        private bool IsDistributableSpecialisation(EarlyRoadBuildingState state, IHex hex)
        {
            return true;
        }

        private bool IsDistributableSpecialisation(RollingState state, IHex hex)
        {
            return hex.Value == RolledSum && (Rogue.Row != hex.Row || Rogue.Col == hex.Col);
        }
    }
}

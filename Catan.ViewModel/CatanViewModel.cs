using System.Collections.ObjectModel;

using Catan.Model;
using Catan.Model.Context;
using Catan.Model.Context.Players;
using Catan.Model.Enums;
using Catan.Model.Events.EventArguments;
using Catan.Model.DTOs;
using Catan.ViewModel.Edge;
using Catan.ViewModel.Hex;
using Catan.ViewModel.Player;
using Catan.ViewModel.Vertex;
using Catan.ViewModel.Edge.Factory;

namespace Catan.ViewModel
{
    public class CatanViewModel : ViewModelBase
    {
        private CatanGameModel _model;

        public event EventHandler<BankConfirmEventArgs> BankConfirmRequested;

        public event EventHandler<EventArgs> WinnerRequested;
        public event EventHandler<EventArgs> ScoreCardEarned;
        public event EventHandler<EventArgs> KnightCardEarned;
        public event EventHandler<EventArgs> LargestArmyTitleEarned;
        public event EventHandler<EventArgs> LongestRoadTitleEarned;
        public event EventHandler<EventArgs> NewGameRequested;

        private void onWinnerRequested() { WinnerRequested?.Invoke(this, EventArgs.Empty); }

        private void onConfirmRequested(ResourceEnum from) { BankConfirmRequested?.Invoke(this, new BankConfirmEventArgs(from)); }

        public ObservableCollection<HexViewModel> Hexes { get; set; } = new();
        public ObservableCollection<VertexViewModel> Vertices { get; set; } = new();
        public ObservableCollection<BuildableCommunityViewModel> BuildableCommunities { get; set; } = new();
        public ObservableCollection<TownViewModel> TownCommunities { get; set; } = new();
        public ObservableCollection<EdgeViewModel> Edges { get; set; } = new();
        public ObservableCollection<BuildableEdgeViewModel> BuildableEdges { get; set; } = new();
        public ObservableCollection<PlayerViewModel> Players { get; set; } = new();
        public ObservableCollection<PlaceRogueViewModel> RogueMovingNodes { get; set; } = new();
        public ObservableCollection<RogueViewModel> RogueContainer { get; set; } = new();


        int _firstDiceValue = 1;
        int _secondDiceValue = 1;
        public int FirstDiceFace { get => _firstDiceValue; set { _firstDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SecondDiceFace { get => _secondDiceValue; set { _secondDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SumOfDices { get => FirstDiceFace + SecondDiceFace; }

        private PlayerViewModel _currentPlayer;
        private PlayerViewModel _nextPlayer;
        private PlayerViewModel _nextNextPlayer;
        public PlayerViewModel CurrentPlayer { get => _currentPlayer; }
        public PlayerViewModel NextPlayer { get => _nextPlayer; }
        public PlayerViewModel NextNextPlayer { get => _nextNextPlayer; }

        public int PlayerCrop { get => _currentPlayer.Crop; }
        public int PlayerOre { get => _currentPlayer.Ore; }
        public int PlayerWood { get => _currentPlayer.Wood; }
        public int PlayerBrick { get => _currentPlayer.Brick; }
        public int PlayerWool { get => _currentPlayer.Wool; }
        public int PlayerScore { get => _currentPlayer.Score; }
        public string CurrentPlayerColor { get => _currentPlayer.Color; }

        public DelegateCommand ThrowDicesCommand { get; private set; }
        public DelegateCommand EndTurnCommand { get; private set; }
        public DelegateCommand PurchaseBonusCardCommand { get; private set; }
        public DelegateCommand BuildRoadCommand { get; private set; }
        public DelegateCommand BuildSettlementCommand { get; private set; }
        public DelegateCommand UpgradeSettlementCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand ExchangeWithBankCommand { get; private set; }
        public DelegateCommand NewGameCommand { get; private set; }
        public CatanViewModel(CatanGameModel model)
        {
            _model = model;
            _currentPlayer = new PlayerViewModel(Mapping.Mapper.Map<PlayerDTO>(NotPlayer.Instance));
            _nextPlayer = new PlayerViewModel(Mapping.Mapper.Map<PlayerDTO>(NotPlayer.Instance));
            _nextNextPlayer = new PlayerViewModel(Mapping.Mapper.Map<PlayerDTO>(NotPlayer.Instance));


            _model.Events.DicesRolled += Model_Events_DicesThrown;
            _model.Events.GameStarted += Model_Events_NewGame;
            _model.Events.GameWon += Model_Events_GameWon;
            _model.Events.PlayerUpdated += Model_Events_Player;

            _model.Events.SettlementBuildingStarted += Model_Events_SettlementBuildingStarted;
            _model.Events.SettlementBuilt += Model_Events_SettlementBuilt;

            _model.Events.SettlementUpgradingStarted += Model_Events_SettlementUpgradingStarted;
            _model.Events.SettlementUpgraded += Model_Events_SettlementUpgraded;

            _model.Events.RoadBuildingStarted += Model_Events_RoadBuildingStarted;
            _model.Events.RoadBuilt += Model_Events_RoadBuilt;

            _model.Events.Cancelled += Model_Events_Cancel;

            _model.Events.RogueMovingStarted += Model_Events_RogueMovingStarted;
            _model.Events.RogueMoved += Model_Events_RogueMoved;

            _model.Events.ScoreCardDrawn += Model_Events_ScoreCardDrawn;
            _model.Events.KnightCardDrawn += Model_Events_KnightCardDrawn;
            _model.Events.LargestArmyEarned += Model_Events_LargestArmyEarned;
            _model.Events.LongestRoadEarned += Model_Events_LongestRoadEarned;

            ThrowDicesCommand = new DelegateCommand(_ => _model.RollDices(), _ => _model.IsRollValid);
            EndTurnCommand = new DelegateCommand(_ => _model.EndTurn(), _ => _model.IsEndTurnValid);
            PurchaseBonusCardCommand = new DelegateCommand(_ => _model.PurchaseBonusCard(), _ => _model.IsPurchaseBonusCardValid);
            BuildRoadCommand = new DelegateCommand(_ => _model.StartRoadBuilding(), _ => _model.IsRoadBuildingValid);
            BuildSettlementCommand = new DelegateCommand(_ => _model.StartSettlementBuilding(), _ => _model.IsSettlementBuildingValid);
            UpgradeSettlementCommand = new DelegateCommand(_ => _model.StartSettlementUpgrading(), _ => _model.IsTownBuildingValid);
            CancelCommand = new DelegateCommand(_ => _model.Cancel(), _ => _model.IsCancelValid);
            ExchangeWithBankCommand = new DelegateCommand(resource => ExchangeWithBank(resource), resource => IsExchangeWithBankValid(resource));
            NewGameCommand = new DelegateCommand(_ => NewGame());
        }

        private void NewGame()
        {
            NewGameRequested?.Invoke(this, EventArgs.Empty);
        }

        public void ConfirmNewGame()
        {
            BuildableCommunities.Clear();
            BuildableEdges.Clear();
            RogueMovingNodes.Clear();
        }

        private void Model_Events_LongestRoadEarned(object? sender, EventArgs e)
        {
            LongestRoadTitleEarned?.Invoke(this, e);
        }

        private void Model_Events_LargestArmyEarned(object? sender, EventArgs e)
        {
            LargestArmyTitleEarned?.Invoke(this, e);
        }

        private void Model_Events_KnightCardDrawn(object? sender, EventArgs e)
        {
            KnightCardEarned?.Invoke(this, e);
        }

        private void Model_Events_ScoreCardDrawn(object? sender, EventArgs e)
        {
            ScoreCardEarned?.Invoke(this, e);
        }

        private void Model_Events_GameWon(object? sender, GameWonEventArgs e)
        {
            onWinnerRequested();
        }

        private void Model_Events_RogueMoved(object? sender, RogueMovedEventArgs e)
        {
            RogueMovingNodes.Clear();
            RogueContainer.Clear();
            RogueContainer.Add(new RogueViewModel(e.Row, e.Column));
        }

        private void Model_Events_RogueMovingStarted(object? sender, EventArgs e)
        {
            Hexes.ToList().ForEach(e =>
            {
                var rmn = new PlaceRogueViewModel(e.Row, e.Column);
                rmn.MoveRogueCommand = new DelegateCommand(vm => MoveRogue((PlaceRogueViewModel)vm));
                RogueMovingNodes.Add(rmn);
            });
        }

        private void MoveRogue(PlaceRogueViewModel p)
        {
            _model.MoveRogue(p.Row, p.Column);
        }

        private bool IsExchangeWithBankValid(object resource)
        {
            _ = Enum.TryParse(resource.ToString(), out ResourceEnum from);
            return _model.IsExchangeWithBankValid(from);
        }
        private void ExchangeWithBank(object resource)
        {
            _ = Enum.TryParse(resource.ToString(), out ResourceEnum from);
            onConfirmRequested(from);
        }

        private void Model_Events_Cancel(object? sender, CancelEventArgs e)
        {
            BuildableCommunities.Clear();
            BuildableEdges.Clear();

            RogueMovingNodes.Clear();
        }

        private void Model_Events_RoadBuildingStarted(object? sender, RoadBuildingStartedEventArgs e)
        {
            foreach (EdgeDTO edge in e.Edges)
            {
                BuildableEdges.Add(BuildableEdgeFactory(edge));
            }
        }

        private void Model_Events_SettlementBuildingStarted(object? sender, SettlementBuildingStartedEventArgs e)
        {
            foreach (VertexDTO vertex in e.Vertices)
            {
                BuildableCommunityViewModel bcvm = new BuildableCommunityViewModel(vertex.Row, vertex.Col);
                bcvm.BuildCommand = new DelegateCommand(vm => BuildSettlement((BuildableCommunityViewModel)vm));
                BuildableCommunities.Add(bcvm);
            }
        }

        private void Model_Events_SettlementUpgradingStarted(object? sender, SettlementUpgradingStartedEventArgs e)
        {
            foreach (VertexDTO vertex in e.Vertices)
            {
                BuildableCommunityViewModel bcvm = new BuildableCommunityViewModel(vertex.Row, vertex.Col);
                bcvm.BuildCommand = new DelegateCommand(vm => UpgradeSettlement((BuildableCommunityViewModel)vm));
                BuildableCommunities.Add(bcvm);
            }
        }

        private void UpgradeSettlement(BuildableCommunityViewModel vm)
        {
            _model.UpgradeSettleMentToTown(vm.Row, vm.Column);
        }

        private void BuildSettlement(BuildableCommunityViewModel vm)
        {
            _model.BuildSettleMent(vm.Row, vm.Column);
        }

        private void BuildRoad(BuildableEdgeViewModel vm)
        {
            _model.BuildRoad(vm.Row, vm.Column);
        }

        private void Model_Events_SettlementUpgraded(object? sender, SettlementUpgradedEventArgs e)
        {
            VertexViewModel? toBeRemoved = null;
            foreach (VertexViewModel vm in Vertices)
            {
                if (vm.Row == e.Row && vm.Column == e.Column)
                {
                    toBeRemoved = vm;
                    TownCommunities.Add(new TownViewModel(vm.Row, vm.Column, vm.Owner, vm.Community));
                }
            }
            if (toBeRemoved != null) { Vertices.Remove(toBeRemoved); }

            BuildableCommunities.Clear();
        }

        private void Model_Events_SettlementBuilt(object? sender, SettlementBuiltEventArgs e)
        {
            foreach (VertexViewModel vm in Vertices)
            {
                if (vm.Row == e.Row && vm.Column == e.Column)
                {
                    vm.Community = CommunityEnum.Settlement;
                    vm.Owner = e.Owner;
                }
            }

            BuildableCommunities.Clear();
        }

        private void Model_Events_RoadBuilt(object? sender, RoadBuiltEventArgs e)
        {
            foreach (EdgeViewModel edge in Edges)
            {
                if (edge.Row == e.Row && edge.Column == e.Column)
                {
                    edge.Owner = e.Owner;
                }
            }
            BuildableEdges.Clear();
        }

        private void Model_Events_Player(object? sender, PlayerUpdatedEventArgs e)
        {
            _currentPlayer.SetPlayer(e.Players[0]);
            _nextPlayer.SetPlayer(e.Players[1]);
            _nextNextPlayer.SetPlayer(e.Players[2]);
            foreach (PlayerDTO player in e.Players)
            {
                Players.Add(new PlayerViewModel(player));
            }

            OnPropertyChanged(nameof(PlayerCrop));
            OnPropertyChanged(nameof(PlayerOre));
            OnPropertyChanged(nameof(PlayerWood));
            OnPropertyChanged(nameof(PlayerBrick));
            OnPropertyChanged(nameof(PlayerWool));
            OnPropertyChanged(nameof(PlayerScore));
            OnPropertyChanged(nameof(CurrentPlayerColor));
            OnPropertyChanged(nameof(CurrentPlayer));
            OnPropertyChanged(nameof(NextPlayer));
            OnPropertyChanged(nameof(NextNextPlayer));
        }

        private void Model_Events_NewGame(object? sender, GameStartedEventArgs e)
        {
            List<HexDTO> hexes = e.Hexes;
            List<VertexDTO> vertices = e.Vertices;
            List<EdgeDTO> edges = e.Edges;

            foreach (HexDTO hex in hexes)
            {
                var hexVM = new HexViewModel(hex.Resource, hex.Value, hex.Row, hex.Col);
                Hexes.Add(hexVM);
            }

            foreach (VertexDTO vertex in vertices)
            {
                var vertexVM = new VertexViewModel(vertex.Row, vertex.Col, PlayerEnum.NotPlayer, CommunityEnum.BuildableCommunity);
                Vertices.Add(vertexVM);
            }

            foreach (EdgeDTO edge in edges)
            {
                Edges.Add(EdgeFactory(edge));
            }

            RogueContainer.Clear();
            RogueContainer.Add(new RogueViewModel(e.RogueRow, e.RogueCol));
        }

        private void Model_Events_DicesThrown(object? sender, DicesRolledEventArg e)
        {
            FirstDiceFace = e.FirstDice;
            SecondDiceFace = e.SecondDice;
        }

        #region factory
        private BuildableEdgeViewModel BuildableEdgeFactory(EdgeDTO edge)
        {
            BuildableEdgeViewModelFactory factory = null;

            switch (GetEdgeOrientation(edge.Row, edge.Col))
            {
                case "Vertical":
                    factory = new BuildableVerticalViewModelFactory(edge.Row, edge.Col);
                    break;
                case "LeftSlope":
                    factory = new BuildableLeftSlopeViewModelFactory(edge.Row, edge.Col);
                    break;
                case "RightSlope":
                    factory = new BuildableRightSlopeViewModelFactory(edge.Row, edge.Col);
                    break;
            }
            BuildableEdgeViewModel bevm = factory.CreateEdge();
            bevm.BuildCommand = new DelegateCommand(vm => BuildRoad((BuildableEdgeViewModel)vm));
            BuildableEdges.Add(bevm);
            return bevm;
        }
        private EdgeViewModel EdgeFactory(EdgeDTO edge)
        {
            EdgeViewModelFactory factory = null;

            switch (GetEdgeOrientation(edge.Row, edge.Col))
            {
                case "Vertical":
                    factory = new VerticalViewModelFactory(edge.Row, edge.Col,edge.Owner);
                    break;
                case "LeftSlope":
                    factory = new LeftSlopeViewModelFactory(edge.Row, edge.Col, edge.Owner);
                    break;
                case "RightSlope":
                    factory = new RightSlopeViewModelFactory(edge.Row, edge.Col, edge.Owner);
                    break;
            }
            EdgeViewModel evm = factory.CreateEdge();
            return evm;
        }
        private string GetEdgeOrientation(int row, int col)
        {
            if (row % 2 == 1)
            {
                return "Vertical";
            }
            else if ((row / 2) % 2 == 0)
            {
                if (col % 2 == 0)
                {
                    return "LeftSlope";
                }
                else
                {
                    return "RightSlope";
                }
            }
            else
            {
                if (col % 2 == 0)
                {
                    return "RightSlope";
                }
                else
                {
                    return "LeftSlope";
                }
            }
        }
        #endregion
    }
}

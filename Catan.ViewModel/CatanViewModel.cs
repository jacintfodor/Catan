using Catan.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Board.Components;
using Catan.Model.Context;
using Catan.Model.Context.Players;
using Catan.Model.Enums;
using System.Windows.Input;
using Catan.Model.Events.Eventargs;
using Catan.Model.Events;

namespace Catan.ViewModel
{
    public class CatanViewModel : ViewModelBase
    {
        private CatanGameModel _model;

        public ObservableCollection<HexViewModel> Hexes { get; set; }
        public ObservableCollection<VertexViewModel> Vertices { get; set; }
        public ObservableCollection<BuildableCommunityViewModel> BuildableCommunities { get; set; }
        public ObservableCollection<VerticalViewModel> Verticals { get; set; }
        public ObservableCollection<LeftSlopeViewModel> LeftSlopes { get; set; }
        public ObservableCollection<RightSlopeViewModel> RightSlopes { get; set; }
        public ObservableCollection<BuildableVerticalViewModel> BuildableVerticals { get; set; }
        public ObservableCollection<BuildableLeftSlopeViewModel> BuildableLeftSlopes { get; set; }
        public ObservableCollection<BuildableRightSlopeViewModel> BuildableRightSlopes { get; set; }
        public ObservableCollection<PlayerViewModel> Players { get; set; }
        public ObservableCollection<PlaceRogueViewModel> RogueMovingNodes { get; set; } = new();
        public ObservableCollection<RogueViewModel> RogueContainer { get; set; } = new();


        int _firstDiceValue = 1;
        int _secondDiceValue = 1;
        public int FirstDiceFace { get => _firstDiceValue; set { _firstDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SecondDiceFace { get => _secondDiceValue; set { _secondDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SumOfDices { get => FirstDiceFace + SecondDiceFace; }

        private PlayerViewModel _currentPlayer;
        public int PlayerCrop { get => _currentPlayer.Crop; set {_currentPlayer.Crop = value; OnPropertyChanged(); } }
        public int PlayerOre { get => _currentPlayer.Ore; set { _currentPlayer.Ore = value; OnPropertyChanged(); } }
        public int PlayerWood { get => _currentPlayer.Wood; set { _currentPlayer.Wood = value; OnPropertyChanged(); } }
        public int PlayerBrick { get => _currentPlayer.Brick; set { _currentPlayer.Brick = value; OnPropertyChanged(); } }
        public int PlayerWool { get => _currentPlayer.Wool; set { _currentPlayer.Wool = value; OnPropertyChanged(); } }
        public int PlayerLongestRoad { get => _currentPlayer.LongestRoad; set { _currentPlayer.LongestRoad = value; OnPropertyChanged(); } }
        public int PlayerKnightCardCount { get => _currentPlayer.KnightCardCount; set { _currentPlayer.KnightCardCount = value; OnPropertyChanged(); } }
        public int PlayerScore { get => _currentPlayer.Score; set { _currentPlayer.Score = value; OnPropertyChanged(); } }
        public string CurrentPlayerColor { get => _currentPlayer.Color; set { _currentPlayer.Color = value; OnPropertyChanged(); } }
        public DelegateCommand ThrowDicesCommand { get; private set; }
        public DelegateCommand EndTurnCommand { get; private set; }
        public DelegateCommand PurchaseBonusCardCommand { get; private set; }
        public DelegateCommand BuildRoadCommand { get; private set; }
        public DelegateCommand BuildSettlementCommand { get; private set; }
        public DelegateCommand UpgradeSettlementCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand ExchangeWithBankCommand { get; private set; }
        public CatanViewModel(CatanGameModel model)
        {
            _model = model;
            /* Hexes */
            Hexes = new ObservableCollection<HexViewModel>();
            /* Vertices */
            Vertices = new ObservableCollection<VertexViewModel>();
            BuildableCommunities = new ObservableCollection<BuildableCommunityViewModel>();
            /* Edges */
            Verticals = new ObservableCollection<VerticalViewModel>();
            LeftSlopes = new ObservableCollection<LeftSlopeViewModel>();
            RightSlopes = new ObservableCollection<RightSlopeViewModel>();
            BuildableVerticals = new ObservableCollection<BuildableVerticalViewModel>();
            BuildableLeftSlopes = new ObservableCollection<BuildableLeftSlopeViewModel>();
            BuildableRightSlopes = new ObservableCollection<BuildableRightSlopeViewModel>();
            Players = new ObservableCollection<PlayerViewModel>();

            _currentPlayer = new PlayerViewModel(NotPlayer.Instance);


            _model.Events.DicesRolled += Model_Events_DicesThrown;
            _model.Events.GameStarted += Model_Events_NewGame;
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

            ThrowDicesCommand = new DelegateCommand(_ => _model.RollDices(), _ => _model.IsEarlyRollingState || _model.IsRollingState);
            EndTurnCommand = new DelegateCommand(_ => _model.EndTurn(), _ => _model.IsMainState);
            PurchaseBonusCardCommand = new DelegateCommand(_ => _model.PurchaseBonusCard(), _ => _model.IsMainState && _model.HasEnoughResourcesToPurchaseCard());
            BuildRoadCommand = new DelegateCommand(_ => _model.StartRoadBuilding(), _ => _model.IsMainState && _model.HasEnoughResourcesToBuildRoad());
            BuildSettlementCommand = new DelegateCommand(_ => _model.StartSettlementBuilding(), _ => _model.IsMainState && _model.HasEnoughResourcesToBuildSettlement());
            UpgradeSettlementCommand = new DelegateCommand(_ => _model.StartSettlementUpgrading(), _ => _model.IsMainState && _model.HasEnoughResourcesToUpgradeSettlementToTown());
            CancelCommand = new DelegateCommand(_ => _model.Cancel(), _=> _model.IsSettlementBuildingState || _model.IsRoadBuildingState || _model.IsSettlementUpgradingState || _model.IsRogueMovingState);
            //TODO Cost manager rn condition order matters
            ExchangeWithBankCommand = new DelegateCommand(resource => ExchangeWithBank(resource), resource =>  _model.IsMainState && HasThree(resource));
        }

        private void Model_Events_RogueMoved(object? sender, RogueMovedEventArgs e)
        {
            RogueMovingNodes.Clear();
            RogueContainer.Clear();
            RogueContainer.Add(new RogueViewModel(e.Row, e.Column));
        }

        private void Model_Events_RogueMovingStarted(object? sender, EventArgs e)
        {
            Hexes.ToList().ForEach(e => { 
                var rmn = new PlaceRogueViewModel(e.Row, e.Column);
                rmn.MoveRogueCommand = new DelegateCommand(vm => MoveRogue((PlaceRogueViewModel)vm));
                RogueMovingNodes.Add(rmn);
            });
        }

        private void MoveRogue(PlaceRogueViewModel p)
        {
            _model.MoveRogue(p.Row, p.Column);
        }

        private bool HasThree(object resource)
        {
            _ = Enum.TryParse(resource.ToString(), out ResourceEnum from);
            return _model.IsAffordable((new Goods(from)) *3);
        }

        private void ExchangeWithBank(object resource)
        {
            _ = Enum.TryParse(resource.ToString(), out ResourceEnum from);
            _model.ExchangeWithBank(from, (ResourceEnum)ResourceToNumber );
        }

        private void Model_Events_Cancel(object? sender, CancelEventArgs e)
        {
            BuildableCommunities.Clear();
            BuildableVerticals.Clear();
            BuildableLeftSlopes.Clear();
            BuildableRightSlopes.Clear();

            RogueMovingNodes.Clear();
        }

        private void Model_Events_RoadBuildingStarted(object? sender, RoadBuildingStartedEventArgs e)
        {
            foreach (IEdge edge in e.Edges)
            {
                switch (GetEdgeOrientation(edge.Row, edge.Col))
                {
                    case "Vertical":
                        BuildableVerticalViewModel bvvm = new BuildableVerticalViewModel(edge.Row, edge.Col);
                        bvvm.BuildCommand = new DelegateCommand(vm => BuildRoad((BuildableVerticalViewModel)vm));
                        BuildableVerticals.Add(bvvm);
                        break;
                    case "LeftSlope":
                        BuildableLeftSlopeViewModel blvm = new BuildableLeftSlopeViewModel(edge.Row, edge.Col);
                        blvm.BuildCommand = new DelegateCommand(vm => BuildRoad((BuildableLeftSlopeViewModel)vm));
                        BuildableLeftSlopes.Add(blvm);
                        break;
                    case "RightSlope":
                        BuildableRightSlopeViewModel brvm = new BuildableRightSlopeViewModel(edge.Row, edge.Col);
                        brvm.BuildCommand = new DelegateCommand(vm => BuildRoad((BuildableRightSlopeViewModel)vm));
                        BuildableRightSlopes.Add(brvm);
                        break;
                }
            }
        }

        private void Model_Events_SettlementBuildingStarted(object? sender, SettlementBuildingStartedEventArgs e)
        {
            foreach (IVertex vertex in e.Vertices)
            {
                BuildableCommunityViewModel bcvm = new BuildableCommunityViewModel(vertex.Row, vertex.Col);
                bcvm.BuildCommand = new DelegateCommand(vm => BuildSettlement((BuildableCommunityViewModel)vm));
                BuildableCommunities.Add(bcvm);
            }
        }

        private void Model_Events_SettlementUpgradingStarted(object? sender, SettlementUpgradingStartedEventArgs e)
        {
            foreach (IVertex vertex in e.Vertices)
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

        //TODO common interface instead of overloading methods
        private void BuildRoad(BuildableVerticalViewModel vm)
        {
            _model.BuildRoad(vm.Row, vm.Column);
        }
        private void BuildRoad(BuildableLeftSlopeViewModel vm)
        {
            _model.BuildRoad(vm.Row, vm.Column);
        }
        private void BuildRoad(BuildableRightSlopeViewModel vm)
        {
            _model.BuildRoad(vm.Row, vm.Column);
        }
        private void Model_Events_SettlementUpgraded(object? sender, SettlementUpgradedEventArgs e)
        {
            foreach (VertexViewModel vm in Vertices)
            {
                if (vm.Row == e.Row && vm.Column == e.Column)
                {
                    vm.Community = CommunityEnum.Town;
                }
            }

            BuildableCommunities.Clear();
        }
        private void Model_Events_SettlementBuilt(object? sender, SettlementBuiltEventArgs e)
        {
            foreach (VertexViewModel vm in Vertices) {
                if (vm.Row == e.Row && vm.Column == e.Column) {
                    vm.Community =  CommunityEnum.Settlement;
                    vm.Owner = e.Owner;
                }
            }

            BuildableCommunities.Clear();
        }
        private void Model_Events_RoadBuilt(object? sender, RoadBuiltEventArgs e)
        {
            switch (GetEdgeOrientation(e.Row, e.Column))
            {
                case "Vertical":
                    foreach (VerticalViewModel vertical in Verticals)
                    {
                        if (vertical.Row == e.Row && vertical.Column == e.Column)
                        {
                            vertical.Owner = e.Owner;
                        }
                    }
                    break;
                case "LeftSlope":
                    foreach (LeftSlopeViewModel vertical in LeftSlopes)
                    {
                        if (vertical.Row == e.Row && vertical.Column == e.Column)
                        {
                            vertical.Owner = e.Owner;
                        }
                    }
                    break;
                case "RightSlope":
                    foreach (RightSlopeViewModel vertical in RightSlopes)
                    {
                        if (vertical.Row == e.Row && vertical.Column == e.Column)
                        {
                            vertical.Owner = e.Owner;
                        }
                    }
                    break;
            }
            BuildableVerticals.Clear();
            BuildableLeftSlopes.Clear();
            BuildableRightSlopes.Clear();
        }

        private void Model_Events_Player(object? sender, PlayerUpdatedEventArgs e)
        {
            _currentPlayer = new PlayerViewModel(e.Players[0]);
            foreach (IPlayer player in e.Players)
            {
                Players.Add(new PlayerViewModel(player));
            }

            OnPropertyChanged(nameof(PlayerCrop));
            OnPropertyChanged(nameof(PlayerOre));
            OnPropertyChanged(nameof(PlayerWood));
            OnPropertyChanged(nameof(PlayerBrick));
            OnPropertyChanged(nameof(PlayerWool));
            OnPropertyChanged(nameof(PlayerLongestRoad));
            OnPropertyChanged(nameof(PlayerKnightCardCount));
            OnPropertyChanged(nameof(PlayerScore));
            OnPropertyChanged(nameof(CurrentPlayerColor));
        }

        private void Model_Events_NewGame(object? sender, GameStartedEventArgs e)
        {
            List<IHex> hexes = e.Hexes;
            List<IVertex> vertices = e.Vertices;
            List<IEdge> edges = e.Edges;

            foreach (IHex hex in hexes)
            {
                var hexVM = new HexViewModel(hex.Resource, hex.Value, hex.Row, hex.Col);
                Hexes.Add(hexVM);
            }

            foreach (IVertex vertex in vertices)
            {
                var vertexVM = new VertexViewModel(vertex.Row, vertex.Col, PlayerEnum.NotPlayer, CommunityEnum.BuildableCommunity);
                Vertices.Add(vertexVM);
            }

            foreach (IEdge edge in edges)
            {
                switch (GetEdgeOrientation(edge.Row,edge.Col))
                {
                    case "Vertical":
                        Verticals.Add(new VerticalViewModel(edge.Row,edge.Col,PlayerEnum.NotPlayer));
                        break;
                    case "LeftSlope":
                        LeftSlopes.Add(new LeftSlopeViewModel(edge.Row, edge.Col, PlayerEnum.NotPlayer));
                        break;
                    case "RightSlope":
                        RightSlopes.Add(new RightSlopeViewModel(edge.Row, edge.Col, PlayerEnum.NotPlayer));
                        break;
                }
            }

            RogueContainer.Clear();
            RogueContainer.Add(new RogueViewModel(e.RogueRow, e.RogueCol));
        }

        private void Model_Events_DicesThrown(object? sender, DicesRolledEventArg e)
        {
            FirstDiceFace = e.FirstDice;
            SecondDiceFace = e.SecondDice;
        }

        private string GetEdgeOrientation(int row, int col) {
            if (row % 2 == 1)
            {
                return "Vertical";
            }
            else if ((row / 2) % 2 == 0)
            {
                if(col % 2 == 0)
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
        
        #region radio stuff
        int _resourceToNumber = 0; 
        public int ResourceToNumber
        {
            get { return _resourceToNumber; }
            set 
            { 
                _resourceToNumber = value; OnPropertyChanged(nameof(RadioCrop)); OnPropertyChanged(nameof(RadioOre)); 
                OnPropertyChanged(nameof(RadioWood)); OnPropertyChanged(nameof(RadioBrick)); OnPropertyChanged(nameof(RadioWool));
            }
        }
        //Desert = -1, Crop, Ore, Wood, Brick, Wool
        public bool RadioCrop
        {
            get { return ResourceToNumber.Equals(0); }
            set { ResourceToNumber = 0; }
        }
        public bool RadioOre
        {
            get { return ResourceToNumber.Equals(1); }
            set { ResourceToNumber = 1; }
        }
        
        public bool RadioWood {
            get { return ResourceToNumber.Equals(2); }
            set { ResourceToNumber = 2; }
        }

        public bool RadioBrick
        {
            get { return ResourceToNumber.Equals(3); }
            set { ResourceToNumber = 3; }
        }

        public bool RadioWool
        {
            get { return ResourceToNumber.Equals(4); }
            set { ResourceToNumber = 4; }
        }

        #endregion
    }
}

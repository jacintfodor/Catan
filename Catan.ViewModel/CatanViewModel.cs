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


        int _firstDiceValue = 1;
        int _secondDiceValue = 1;
        public int FirstDiceFace { get => _firstDiceValue; set { _firstDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SecondDiceFace { get => _secondDiceValue; set { _secondDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SumOfDices { get => FirstDiceFace + SecondDiceFace; }

        private Dictionary<ResourceEnum, int> _currentPlayersResource;
        public int CurrentPlayerCrop { get => _currentPlayersResource[ResourceEnum.Crop]; set { _currentPlayersResource[ResourceEnum.Crop] = value; OnPropertyChanged(); } }
        public int CurrentPlayerOre { get => _currentPlayersResource[ResourceEnum.Ore]; set { _currentPlayersResource[ResourceEnum.Ore] = value; OnPropertyChanged(); } }
        public int CurrentPlayerWood { get => _currentPlayersResource[ResourceEnum.Wood]; set { _currentPlayersResource[ResourceEnum.Wood] = value; OnPropertyChanged(); } }
        public int CurrentPlayerBrick { get => _currentPlayersResource[ResourceEnum.Brick]; set { _currentPlayersResource[ResourceEnum.Brick] = value; OnPropertyChanged(); } }
        public int CurrentPlayerWool { get => _currentPlayersResource[ResourceEnum.Wool]; set { _currentPlayersResource[ResourceEnum.Wool] = value; OnPropertyChanged(); } }

        public DelegateCommand ThrowDicesCommand { get; private set; }
        public DelegateCommand EndTurnCommand { get; private set; }
        public DelegateCommand PurchaseBonusCardCommand { get; private set; }

        public CatanViewModel(CatanGameModel model)
        {
            _model = model;
            Hexes = new ObservableCollection<HexViewModel>();
            Vertices = new ObservableCollection<VertexViewModel>();

            _currentPlayersResource = new Dictionary<ResourceEnum, int>();
            _currentPlayersResource.Add(ResourceEnum.Crop, 0);
            _currentPlayersResource.Add(ResourceEnum.Ore, 0);
            _currentPlayersResource.Add(ResourceEnum.Wood, 0);
            _currentPlayersResource.Add(ResourceEnum.Brick, 0);
            _currentPlayersResource.Add(ResourceEnum.Wool, 0);


            _model.Events.DicesThrown += Model_Events_DicesThrown;
            _model.Events.GameStart += Model_Events_NewGame;
            _model.Events.TransactionsHappened += Model_Events_TransactionsHappened;

            ThrowDicesCommand = new DelegateCommand(_ => _model.RollDices(), _ => _model.IsEarlyRollingState || _model.IsMainState);
            EndTurnCommand = new DelegateCommand(_ => _model.EndTurn(), _ => _model.IsMainState);
            PurchaseBonusCardCommand = new DelegateCommand(_ => _model.PurchaseBonusCard(), _ => _model.IsMainState);

        }

        private void Model_Events_TransactionsHappened(object? sender, TransactionsHappenedEventArg e)
        {
            CurrentPlayerCrop = e.CropCount;
            CurrentPlayerBrick = e.BrickCount;
            CurrentPlayerOre = e.OreCount;
            CurrentPlayerWood = e.WoodCount;
            CurrentPlayerWool = e.WoolCount;
        }

        private void Model_Events_BuildableByPlayer(object? sender, BuildableByPlayerEventArgs e) { }

        private void Model_Events_NewGame(object? sender, GameStartEventArgs e)
        {
            List<IHex> hexes = e.Hexes;
            List<IVertex> vertices = e.Vertices;
            List<IEdge> edges = e.Edges;

            foreach (IHex hex in hexes)
            {
                var hexVM = new HexViewModel(hex.Row, hex.Col, ResourceEnumToString(hex.Resource), hex.Value);
                Hexes.Add(hexVM);
            }

            foreach (IVertex vertex in vertices)
            {
                var vertexVM = new VertexViewModel(vertex.Row, vertex.Col, PlayerToString(PlayerEnum.NotPlayer), CommunityToString(vertex.GetCommunity()));
                Vertices.Add(vertexVM);
            }

            foreach (IEdge edge in edges)
            {
                switch (GetEdgeOrientation(edge))
                {
                    case "Vertical":
                        Verticals.Add(new VerticalViewModel(edge.Row,edge.Col,PlayerToString(PlayerEnum.NotPlayer)));
                        break;
                    case "LeftSlope":
                        LeftSlopes.Add(new LeftSlopeViewModel(edge.Row, edge.Col, PlayerToString(PlayerEnum.NotPlayer)));
                        break;
                    case "RightSlope":
                        RightSlopes.Add(new RightSlopeViewModel(edge.Row, edge.Col, PlayerToString(PlayerEnum.NotPlayer)));
                        break;
                }
            }
        }

        private void Model_Events_DicesThrown(object? sender, DicesThrownEventArg e)
        {
            FirstDiceFace = e.FirstDice;
            SecondDiceFace = e.SecondDice;
        }

        private string GetEdgeOrientation(IEdge edge) {
            if (edge.Row % 2 == 1)
            {
                return "Vertical";
            }
            else if ((edge.Row / 2) % 2 == 0)
            {
                if(edge.Col % 2 == 0)
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
                if (edge.Col % 2 == 0)
                {
                    return "RightSlope";
                }
                else
                {
                    return "LeftSlope";
                }
            }
        }

        private string PlayerToString(PlayerEnum p)
        {
            string retVal = p.ToString();
            return retVal;
        }

        private string CommunityToString(ICommunity community)
        {
            string retVal = community.GetType().Name;
            return retVal;
        }

        private string ResourceEnumToString(ResourceEnum res)
        {
            string retVal = res.ToString();
            return retVal;
        }
    }
}

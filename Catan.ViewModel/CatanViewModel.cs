using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Board;
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

            _currentPlayersResource = new Dictionary<ResourceEnum,int>();
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

        private void Model_Events_NewGame(object? sender, GameStartEventArgs e)
        {
            List<IHex> hexes = e.Hexes;
            List<IVertex> vertices = e.Vertices;
            List<IEdge> edges = e.Edges;

            foreach (IHex hex in hexes)
            {
                var hexVM = new HexViewModel(ResourceEnumToString(hex.Resource), hex.Value, hex.Row, hex.Col);
                Hexes.Add(hexVM);
            }

            foreach (IVertex vertex in vertices)
            {
                var ver = new VertexViewModel("", "", vertex.Row, vertex.Col);
                Vertices.Add(ver);
            }

            foreach (IEdge edge in edges)
            {

            }
        }

        private void Model_Events_DicesThrown(object? sender, DicesThrownEventArg e)
        {
            FirstDiceFace = e.FirstDice;
            SecondDiceFace = e.SecondDice;
        }

        private string CommunityToString(IPlayer p)
        {
            string retVal = "";
            return retVal;
        }

        private string ResourceEnumToString(ResourceEnum res)
        {
            string retVal;
            switch (res)
            {
                case ResourceEnum.Ore:
                    retVal = "SlateGray";
                    break;
                case ResourceEnum.Brick:
                    retVal = "Firebrick";
                    break;
                case ResourceEnum.Wool:
                    retVal = "PaleGreen";
                    break;
                case ResourceEnum.Wood:
                    retVal = "ForestGreen";
                    break;
                case ResourceEnum.Crop:
                    retVal = "Goldenrod";
                    break;
                case ResourceEnum.Desert:
                    retVal = "Black";
                    break;
                default:
                    retVal = "Black";
                    break;
            }
            return retVal;
        }
    }
}

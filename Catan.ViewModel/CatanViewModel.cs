﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Board;
using Catan.Model.Board.Buildings;
using Catan.Model.Board.Compontents;
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


            _model.DicesThrown += Model_DicesThrown;
            _model.GameStart += Model_NewGame;
            ThrowDicesCommand = new DelegateCommand(_ => _model.ThrowDices());
            EndTurnCommand = new DelegateCommand(_ => _model.EndTurn());
            PurchaseBonusCardCommand = new DelegateCommand(_ => _model.PurchaseBonusCard());

        }

        private void Model_NewGame(object? sender, GameStartEventArgs e)
        {
            Hex[,] hxs = e.Hexes;
            Vertex[,] vxs = e.Vertices;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hxs[i, j] != null) {
                        var hex = new HexViewModel(ResourceEnumToString(hxs[i, j].Resource), hxs[i, j].Number, i,j);
                        Hexes.Add(hex);
                    }
                }
            }
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (vxs[i, j] != null)
                    {
                        var ver = new VertexViewModel("P1", BuildingToString(vxs[i,j].Building), i, j);
                        Vertices.Add(ver);
                    }
                }
            }
        }

        private void Model_DicesThrown(object? sender, Model.Events.DicesThrownEventArg e)
        {
            FirstDiceFace = e.FirstDice;
            SecondDiceFace = e.SecondDice;

            CurrentPlayerCrop = e.CropCount;
            CurrentPlayerOre = e.OreCount;
            CurrentPlayerWood = e.WoodCount;
            CurrentPlayerBrick = e.BrickCount;
            CurrentPlayerWool = e.WoolCount;


        }

        private string BuildingToString(Building b)
        {
            string retVal;
            switch (b)
            {
                case Settlement:
                    retVal = "Brown";
                    break;
                case Town:
                    retVal = "Black";
                    break;
                default:
                    retVal = "Moccasin";
                    break;
            }
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

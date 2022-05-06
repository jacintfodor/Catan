using Catan.Model.Context;
using Catan.Model.DTOs;
using Catan.Model.Enums;

namespace Catan.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private PlayerDTO _player;
        private int _crop;
        private int _ore;
        private int _wood;
        private int _brick;
        private int _wool;
        private int? _knightCardCount;
        private int? _longestRoad;
        private int _score;
        private string _color;   

        public PlayerViewModel(PlayerDTO player)
        {
            _player = player;
            _crop = player.AvailableResources.Crop;
            _ore = player.AvailableResources.Ore;
            _wood = player.AvailableResources.Wood;
            _brick = player.AvailableResources.Brick;
            _wool = player.AvailableResources.Wool;
            _color = _playerToColor[player.ID];
            _knightCardCount = player.KnightCardCount;
            _longestRoad = player.LengthOfLongestRoad;
            _score = player.Score;


        }


        public int Crop { get => _crop; set { _crop = value; OnPropertyChanged(); } }
        public int Ore { get => _ore; set { _ore = value; OnPropertyChanged(); } }
        public int Wood { get => _wood; set { _wood = value; OnPropertyChanged(); } }
        public int Brick { get => _brick; set { _brick = value; OnPropertyChanged(); } }
        public int Wool { get => _wool; set { _wool = value; OnPropertyChanged(); } }
        public int? KnightCardCount { get => _knightCardCount; set { _knightCardCount = value; OnPropertyChanged(); } }
        public int? LongestRoad { get => _longestRoad; set { _longestRoad = value; OnPropertyChanged(); } }
        public int Score { get => _score; set { _score = value; OnPropertyChanged(); } }
        public string Color { get => _color; set { _color = value; OnPropertyChanged(); } }


        //TODO aggregate this to ViewModels
        private Dictionary<PlayerEnum?, string> _playerToColor = new Dictionary<PlayerEnum?, string>()
        {
            { PlayerEnum.NotPlayer, "White" },
            { PlayerEnum.Player1, "Red" },
            { PlayerEnum.Player2, "Yellow" },
            { PlayerEnum.Player3, "Blue" }
        };
    }
}

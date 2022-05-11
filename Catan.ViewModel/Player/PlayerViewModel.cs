using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.Context.Players;

namespace Catan.ViewModel.Player
{
    public class PlayerViewModel : ViewModelBase
    {
        private PlayerDTO _player;

        public PlayerViewModel(PlayerDTO player)
        {
            SetPlayer(player);
        }

        public void SetPlayer(PlayerDTO player)
        {
            _player = player;
            OnPropertyChanged(nameof(Crop));
            OnPropertyChanged(nameof(Ore));
            OnPropertyChanged(nameof(Wood));
            OnPropertyChanged(nameof(Brick));
            OnPropertyChanged(nameof(Wool));
            OnPropertyChanged(nameof(Score));
            OnPropertyChanged(nameof(Color));
            OnPropertyChanged(nameof(ID));
            OnPropertyChanged(nameof(SumOfFirstRoll));
            OnPropertyChanged(nameof(SumOfResources));
            OnPropertyChanged(nameof(SettlementCardCount));
            OnPropertyChanged(nameof(TownCardCount));
            OnPropertyChanged(nameof(RoadCardCount));
            OnPropertyChanged(nameof(HasLongestRoad));
            OnPropertyChanged(nameof(HasLargestArmy));
        }


        public int Crop { get => _player.AvailableResources.Crop; }
        public int Ore { get => _player.AvailableResources.Ore; }
        public int Wood { get => _player.AvailableResources.Wood; }
        public int Brick { get => _player.AvailableResources.Brick; }
        public int Wool { get => _player.AvailableResources.Wool; }
        public int Score { get => _player.Score; }
        public string Color { get => _playerToColor.GetValueOrDefault(_player.ID) ?? "Black"; }
        public PlayerEnum ID { get => _player.ID; }

        public int SumOfFirstRoll { get => _player.FirstRoll; }
        public int SumOfResources { get => Crop + Ore + Wood + Brick + Wool; }
        public int SettlementCardCount { get => _player.AvailableSettlementCardCount; }
        public int TownCardCount { get => _player.AvailableTownCardCount; }
        public int RoadCardCount { get => _player.AvailableRoadCardCount; }

        public string HasLongestRoad { get => _player.HasLongestRoad ? "Igen" : "Nem"; }
        public string HasLargestArmy { get => _player.HasLargestArmy ? "Igen" : "Nem"; }

        //TODO aggregate this to ViewModels
        private Dictionary<PlayerEnum, string> _playerToColor = new Dictionary<PlayerEnum, string>()
        {
            { PlayerEnum.NotPlayer, "White" },
            { PlayerEnum.Player1, "Red" },
            { PlayerEnum.Player2, "Yellow" },
            { PlayerEnum.Player3, "Blue" }
        };
    }
}

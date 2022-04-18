
using Catan.Model.Enums;

namespace Catan.ViewModel
{
    public class VerticalViewModel : ViewModelBase
    {
        private PlayerEnum _owner;
        private int _row;
        private int _col;

        public VerticalViewModel(int row, int column, PlayerEnum owner)
        {
            Row = row;
            Column = column;
            Owner = owner;
        }

        public int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }
        public PlayerEnum Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }

        public string Top
        {
            get => (Row * 30 - 30).ToString();
        }

        private int Offset { get => (Row % 2 == 0) ? 0 : 30; }

        public string Left
        {
            get => (Offset + Column * 30 -30 -3).ToString();
        }

        #region Converter
        private Dictionary<PlayerEnum, string> _ownerToColor = new Dictionary<PlayerEnum, string>()
        {
            {PlayerEnum.NotPlayer, "White" },
            {PlayerEnum.Player1, "Red" },
            {PlayerEnum.Player2, "Yellow" },
            {PlayerEnum.Player3, "Blue" },
        };
        public string Color { get => _ownerToColor[_owner]; }
        #endregion
    }
}

using Catan.Model.Enums;

namespace Catan.ViewModel.Edge
{
    public class VerticalViewModel : EdgeViewModel
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

        public override int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public override int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }
        public override PlayerEnum Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }

        public double Top
        {
            get => (Row * 30 - 30) / 300.0;
        }
        private int Offset { get => Row % 2 == 0 ? 0 : 30; }
        public double Left
        {
            get => ((Offset + Column * 30 - 30) / 300.0);
        }

        public int ZIndex { get => 1; }

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

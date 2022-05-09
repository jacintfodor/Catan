﻿namespace Catan.ViewModel.Hex
{
    public class RogueViewModel : ViewModelBase
    {
        private int _row = 0;
        private int _col = 0;

        public RogueViewModel(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); OnPropertyChanged(nameof(Left)); } }
        public int ZIndex { get => 2; }
        #region converted values

        public double Top
        {
            get => 1/8.0 + 1/4.0 * Row;
        }

        private int Offset { get => Row % 2 == 0 ? 0 : 30; }

        public double Left
        {
            get => (Offset + Column * 60 + 30)/300.0;
        }
        #endregion
    }
}

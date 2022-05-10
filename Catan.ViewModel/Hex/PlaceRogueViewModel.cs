namespace Catan.ViewModel.Hex
{
    public class PlaceRogueViewModel : ViewModelBase
    {
        private int _row = 0;
        private int _col = 0;

        public PlaceRogueViewModel(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); OnPropertyChanged(nameof(Left)); } }

        public int ZIndex { get => 1; }

        #region converted values

        public double Top
        {
            get => (Row * 0.1875);
        }

        private int Offset { get => Row % 2 == 0 ? 0 : 30; }

        public double Left
        {
            get => ((Offset + Column * 60) / 300.0);
        }

        public DelegateCommand MoveRogueCommand { get; set; }
        #endregion
    }
}

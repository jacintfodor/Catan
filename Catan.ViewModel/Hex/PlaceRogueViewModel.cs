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
        #region converted values

        public string Top
        {
            get => (Row * 60 + 30).ToString();
        }

        private int Offset { get => Row % 2 == 0 ? 0 : 30; }

        public string Left
        {
            get => (Offset + Column * 60 + 30).ToString();
        }

        public DelegateCommand MoveRogueCommand { get; set; }
        #endregion
    }
}

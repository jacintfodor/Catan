namespace Catan.ViewModel.Edge
{
    public class BuildableLeftSlopeViewModel : BuildableEdgeViewModel
    {
        private int _row;
        private int _col;

        public BuildableLeftSlopeViewModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public override int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }

        public string Top
        {
            get => (Row * 30 - 3).ToString();
        }

        private int Offset { get => Row % 2 == 0 ? 0 : 30; }

        public string Left
        {
            get => (Offset + Column * 30).ToString();
        }

        public override DelegateCommand BuildCommand { get; set; }
    }
}

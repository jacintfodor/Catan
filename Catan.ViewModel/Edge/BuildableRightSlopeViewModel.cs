namespace Catan.ViewModel.Edge

{
    public class BuildableRightSlopeViewModel : BuildableEdgeViewModel
    {
        private int _row;
        private int _col;
        public BuildableRightSlopeViewModel(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public override int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public override int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }

        public double Top
        {
            get => (1 / 24.0) + Row * 0.1875 / 2.0;
        }

        private int Offset { get => Row % 2 == 0 ? 0 : 30; }

        public double Left
        {
            get => ((Offset + Column * 30) / 300.0);
        }

        public int ZIndex { get => 4; }

        public override DelegateCommand BuildCommand { get; set; }
    }
}

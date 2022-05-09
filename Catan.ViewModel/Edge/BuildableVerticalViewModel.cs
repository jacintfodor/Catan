namespace Catan.ViewModel.Edge
{
    public class BuildableVerticalViewModel : BuildableEdgeViewModel
    {
        private int _row;
        private int _col;

        public BuildableVerticalViewModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public override int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }
        public double Top
        {
            get => (Row * 30 - 30)/300.0;
        }
        private int Offset { get => Row % 2 == 0 ? 0 : 30; }
        public double Left
        {
            get => ((Offset + Column * 30 - 30)/300.0);
        }

        public int ZIndex { get => 3; }

        public override DelegateCommand BuildCommand { get; set; }

    }
}

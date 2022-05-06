namespace Catan.ViewModel.Edge.Factory
{
    public class BuildableVerticalViewModelFactory : BuildableEdgeViewModelFactory
    {
        private int _row;
        private int _col;

        public BuildableVerticalViewModelFactory(int row, int column)
        {
            _row = row;
            _col = column;
        }

        public override BuildableEdgeViewModel CreateEdge()
        {
            return new BuildableVerticalViewModel(_row, _col);
        }
    }
}

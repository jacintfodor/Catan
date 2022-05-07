namespace Catan.ViewModel.Edge.Factory
{
    public class BuildableLeftSlopeViewModelFactory : BuildableEdgeViewModelFactory
    {
        private int _row;
        private int _col;

        public BuildableLeftSlopeViewModelFactory(int row, int column)
        {
            _row = row;
            _col = column;
        }

        public override BuildableEdgeViewModel CreateEdge()
        {
            return new BuildableLeftSlopeViewModel(_row, _col);
        }

    }
}

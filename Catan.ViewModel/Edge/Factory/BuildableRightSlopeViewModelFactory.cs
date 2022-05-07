namespace Catan.ViewModel.Edge.Factory
{
    public class BuildableRightSlopeViewModelFactory : BuildableEdgeViewModelFactory
    {
        private int _row;
        private int _col;

        public BuildableRightSlopeViewModelFactory(int row, int column)
        {
            _row = row;
            _col = column;
        }

        public override BuildableEdgeViewModel CreateEdge()
        {
            return new BuildableRightSlopeViewModel(_row, _col);
        }
    }
}

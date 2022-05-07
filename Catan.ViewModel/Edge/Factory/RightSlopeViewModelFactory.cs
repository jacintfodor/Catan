using Catan.Model.Enums;

namespace Catan.ViewModel.Edge.Factory
{
    public class RightSlopeViewModelFactory : EdgeViewModelFactory
    {
        private PlayerEnum _owner;
        private int _row;
        private int _col;

        public RightSlopeViewModelFactory(int row, int column, PlayerEnum owner)
        {
            _row = row;
            _col = column;
            _owner = owner;
        }

        public override EdgeViewModel CreateEdge()
        {
            return new RightSlopeViewModel(_row, _col, _owner);
        }
    }
}

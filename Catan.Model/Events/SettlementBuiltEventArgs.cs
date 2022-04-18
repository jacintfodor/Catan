using Catan.Model.Board.Components;
using Catan.Model.Enums;

namespace Catan.Model.Events
{
    public class SettlementBuiltEventArgs : EventArgs
    {
        public SettlementBuiltEventArgs(int row, int column, PlayerEnum owner)
        {
            Row = row;
            Column = column;
            Owner = owner;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public PlayerEnum Owner { get; private set; }
    }
}

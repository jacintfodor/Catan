using Catan.Model.Enums;

namespace Catan.Model.Events.Eventargs
{
    public class RoadBuiltEventArgs : EventArgs
    {
        public RoadBuiltEventArgs(int row, int column, PlayerEnum owner)
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

using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class RoadBuiltEventArgs : EventArgs
    {
        public RoadBuiltEventArgs(IEdge edge)
        {
            Row = edge.Row;
            Column = edge.Col;
            Owner = edge.Owner.ToString();
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public string Owner { get; private set; }
    }
}

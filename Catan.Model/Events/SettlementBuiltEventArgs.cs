using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class SettlementBuiltEventArgs : EventArgs
    {
        public SettlementBuiltEventArgs(IVertex vertex)
        {
            Row = vertex.Row;
            Column = vertex.Col;
            Owner = vertex.Owner.ToString();
            Community = vertex.GetCommunity().ToString();
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public string Owner { get; private set; }
        public string Community { get; private set; }   
    }
}

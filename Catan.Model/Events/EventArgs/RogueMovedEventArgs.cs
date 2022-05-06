namespace Catan.Model.Events.Eventargs
{
    public class RogueMovedEventArgs
    {
        public RogueMovedEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
    }
}

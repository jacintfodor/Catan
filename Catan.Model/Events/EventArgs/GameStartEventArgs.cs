using Catan.Model.Board.Components;

namespace Catan.Model.Events.Eventargs
{
    public class GameStartEventArgs : EventArgs
    {
        public GameStartEventArgs(List<IHex> hexes, List<IVertex> vertices, List<IEdge> edges, int rogueRow, int rogueCol)
        {
            Hexes = hexes;
            Vertices = vertices;
            Edges = edges;
            RogueRow = rogueRow;
            RogueCol = rogueCol;
        }

        public List<IHex> Hexes { get; private set; }
        public List<IVertex> Vertices { get; private set; }
        public List<IEdge> Edges { get; private set; }

        public int RogueRow { get; private set; }
        public int RogueCol { get; private set; }
    }
}

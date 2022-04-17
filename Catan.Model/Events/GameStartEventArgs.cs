using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class GameStartEventArgs : EventArgs
    {
        public GameStartEventArgs(List<IHex> hexes, List<IVertex> vertices, List<IEdge> edges)
        {
            Hexes = hexes;
            Vertices = vertices;
            Edges = edges;
        }

        public List<IHex> Hexes { get; private set; }
        public List<IVertex> Vertices { get; private set; }
        public List<IEdge> Edges { get; private set; }
    }
}

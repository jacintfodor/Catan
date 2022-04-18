using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class BuildableByPlayerEventArgs : EventArgs
    {
        public BuildableByPlayerEventArgs(List<IVertex> vertices, List<IEdge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public List<IVertex> Vertices { get; private set; }
        public List<IEdge> Edges { get; private set; }
    }
}

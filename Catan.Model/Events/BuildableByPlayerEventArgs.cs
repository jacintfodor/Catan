using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class BuildableByPlayerEventArgs
    {
        public BuildableByPlayerEventArgs(List<IVertex> vertices, List<IEdge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public List<IVertex> Vertices { get; set; }
        public List<IEdge> Edges { get; set; }
    }
}

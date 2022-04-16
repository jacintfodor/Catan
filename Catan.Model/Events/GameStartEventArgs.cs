using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class GameStartEventArgs : EventArgs
    {


        public GameStartEventArgs(IHex[,] hexes, Vertex[,] vertices, Edge[,] edges)
        {
            Hexes = hexes;
            Vertices = vertices;
            Edges = edges;
        }

        public IHex[,] Hexes { get; set; }
        public Vertex[,] Vertices { get; set; }
        public Edge[,] Edges { get; set; }
    }
}

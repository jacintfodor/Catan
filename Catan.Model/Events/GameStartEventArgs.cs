using Catan.Model.Board.Compontents;

namespace Catan.Model.Events
{
    public class GameStartEventArgs : EventArgs
    {


        public GameStartEventArgs(Hex[,] hexes, Vertex[,] vertices, Edge[,] edges)
        {
            Hexes = hexes;
            Vertices = vertices;
            Edges = edges;
        }

        public Hex[,] Hexes { get; set; }
        public Vertex[,] Vertices { get; set; }
        public Edge[,] Edges { get; set; }
    }
}

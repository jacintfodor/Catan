using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class GameStartEventArgs : EventArgs
    {


        public GameStartEventArgs(IHex[,] hexes, IVertex[,] vertices, IEdge[,] edges)
        {
            Hexes = hexes;
            Vertices = vertices;
            Edges = edges;
        }

        public IHex[,] Hexes { get; set; }
        public IVertex[,] Vertices { get; set; }
        public IEdge[,] Edges { get; set; }
    }
}

using Catan.Model.DTOs;

namespace Catan.Model.Events.Eventargs
{
    public class GameStartedEventArgs : EventArgs
    {
        public GameStartedEventArgs(List<HexDTO> hexes, List<VertexDTO> vertices, List<EdgeDTO> edges, int rogueRow, int rogueCol)
        {
            Hexes = hexes;
            Vertices = vertices;
            Edges = edges;
            RogueRow = rogueRow;
            RogueCol = rogueCol;
        }

        public List<HexDTO> Hexes { get; private set; }
        public List<VertexDTO> Vertices { get; private set; }
        public List<EdgeDTO> Edges { get; private set; }

        public int RogueRow { get; private set; }
        public int RogueCol { get; private set; }
    }
}

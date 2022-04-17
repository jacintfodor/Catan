using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Edge : IEdge
    {
        private IRoad _road;

        public Edge(int row, int col)
        {
            _road = new BuildableRoad();
            Owner = PlayerEnum.NotPlayer;
            Row = row;
            Col = col;
        }

        public PlayerEnum Owner { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public void AddPotentialBuilder(PlayerEnum player)
        {
            _road.AddPotentialBuilder(player);
        }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return _road.IsBuildableByPlayer(player);    
        }

        public void Build(PlayerEnum player)
        {
            if (_road.IsBuildableByPlayer(player)) {
                Owner = player;
                _road = new BuiltRoad(player);
            }
        }
    }
}
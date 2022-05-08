using Catan.Model.Enums;

namespace Catan.Model.Board.Components.Edge
{
    public class Edge : IEdge
    {
        private IRoad _road;

        public Edge(int row, int col, IRoad? road = null)
        {
            Row = row;
            Col = col;

            if (road == null)
                road = new BuildableRoad();
           _road = road;
        }

        public PlayerEnum Owner => _road.Owner;
        public int Row { get; private set; }
        public int Col { get; private set; }

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
            if (!_road.IsBuildableByPlayer(player)) throw new InvalidOperationException("InvalidBuild");

            _road = new BuiltRoad(player);
        }
    }
}
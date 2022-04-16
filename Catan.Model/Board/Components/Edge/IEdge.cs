using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    interface IEdge
    {
        public PlayerEnum Owner { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
        public void Build(PlayerEnum player);
    }
}

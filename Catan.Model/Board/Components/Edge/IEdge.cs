using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public interface IEdge
    {
        public PlayerEnum Owner { get; }
        public int Row { get; }
        public int Col { get; }

        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
        public void Build(PlayerEnum player);
    }
}

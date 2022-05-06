using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public interface IRoad
    {
        public PlayerEnum Owner { get; }
        
        public bool IsBuildable { get; }

        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}

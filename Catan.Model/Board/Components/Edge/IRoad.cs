using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public interface IRoad
    {
        public PlayerEnum Owner { get; set; }
        
        public bool IsBuildable { get; set; }

        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}

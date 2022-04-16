using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class BuiltRoad : IRoad
    {
        public BuiltRoad(PlayerEnum owner)
        {
            Owner = owner;
            IsBuildable = false;
        }

        public PlayerEnum Owner { get; set; }

        public bool IsBuildable { get; set; }

        public void AddPotentialBuilder(PlayerEnum player) { }
        public bool IsBuildableByPlayer(PlayerEnum player) { return false; }
    }
}

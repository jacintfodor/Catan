using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class BuiltRoad : IRoad
    {
        public BuiltRoad(PlayerEnum owner)
        {
            Owner = owner;
        }

        public PlayerEnum Owner { get; private set; }

        public bool IsBuildable => false;

        public void AddPotentialBuilder(PlayerEnum player) { if (player == PlayerEnum.NotPlayer) throw new ArgumentException("InvalidPlayer"); }
        public bool IsBuildableByPlayer(PlayerEnum player) { return false; }
    }
}

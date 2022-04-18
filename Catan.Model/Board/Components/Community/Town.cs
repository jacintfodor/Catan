using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Town : ICommunity
    {
        public Town(PlayerEnum owner)
        {
            Owner = owner;
        }

        public PlayerEnum Owner { get; }

        public bool IsUpgradeable => false;

        public bool IsBuildableCommunity => false;

        public void AddPotentionalBuilder(PlayerEnum player) {}

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return false;
        }
    }
}

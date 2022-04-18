using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Settlement : ICommunity
    {
        public Settlement(PlayerEnum owner)
        {
            Owner = owner;
        }

        public PlayerEnum Owner { get; }

        public bool IsUpgradeable => true;

        public bool IsBuildableCommunity => false;

        public void AddPotentionalBuilder(PlayerEnum player) { }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return false;
        }
    }
}

using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public interface ICommunity
    {
        public PlayerEnum Owner { get; }

        public bool IsUpgradeable { get; }

        public bool IsBuildableCommunity { get; }

        public void AddPotentionalBuilder(PlayerEnum player);

        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}

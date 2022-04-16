using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    interface ICommunity
    {
        public PlayerEnum Owner { get; set; }

        public bool IsUpgradeable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentionalBuilder(PlayerEnum player);

        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}

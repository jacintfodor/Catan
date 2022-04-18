using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Settlement : ICommunity
    {
        public Settlement(PlayerEnum owner)
        {
            Owner = owner;
            IsUpgradeable = true;
            IsBuildableCommunity = false;
        }

        public PlayerEnum Owner { get; set; }

        public bool IsUpgradeable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentionalBuilder(PlayerEnum player) { }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return Owner == player;
        }
    }
}

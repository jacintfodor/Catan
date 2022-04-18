using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class BuildableCommunity : ICommunity
    {
        HashSet<PlayerEnum> _potentialBuilders;

        public BuildableCommunity()
        {
            _potentialBuilders = new HashSet<PlayerEnum>();
            Owner = PlayerEnum.NotPlayer;
            IsUpgradeable = false;
            IsBuildableCommunity = true;
        }

        public PlayerEnum Owner { get; set; }

        public bool IsUpgradeable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentionalBuilder(PlayerEnum player)
        {
            _potentialBuilders.Add(player);
        }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return _potentialBuilders.Contains(player);
        }
    }
}

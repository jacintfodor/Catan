using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class BuildableCommunity : ICommunity
    {
        HashSet<PlayerEnum> _potentialBuilders = new();

        public PlayerEnum Owner => PlayerEnum.NotPlayer;

        public bool IsUpgradeable => false;

        public bool IsBuildableCommunity => true;

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

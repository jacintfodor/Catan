using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components
{
    public class Settlement : ICommunity
    {
        public Settlement(PlayerEnum owner)
        {
            Owner = owner;
        }

        public PlayerEnum Owner { get; }

        public CommunityEnum Type => CommunityEnum.Settlement;

        public bool IsUpgradeable => true;

        public bool IsBuildableCommunity => false;

        public void AddPotentionalBuilder(PlayerEnum player) { if (player == PlayerEnum.NotPlayer) throw new ArgumentException("InvalidPlayer"); }

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player)
        {
            return false;
        }
    }
}

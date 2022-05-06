using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components
{
    public class Town : ICommunity
    {
        public Town(PlayerEnum owner)
        {
            Owner = owner;
        }

        public PlayerEnum Owner { get; }

        public CommunityEnum Type => CommunityEnum.Town;

        public bool IsUpgradeable => false;

        public bool IsBuildableCommunity => false;

        public void AddPotentionalBuilder(PlayerEnum player) { if (player == PlayerEnum.NotPlayer) throw new ArgumentException("InvaldidPlayer"); }

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player)
        {
            return false;
        }
    }
}

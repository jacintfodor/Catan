using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components
{
    public class NotBuildableCommunity : ICommunity
    {

        private static readonly NotBuildableCommunity _instance = new NotBuildableCommunity();

        public static NotBuildableCommunity Instance
        { get { return _instance; } }

        private NotBuildableCommunity()
        {
        }

        public PlayerEnum Owner => PlayerEnum.NotPlayer;

        public bool IsUpgradeable => false;

        public bool IsBuildableCommunity => false;

        public void AddPotentionalBuilder(PlayerEnum player) { }

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player) { return false; }
    }
}

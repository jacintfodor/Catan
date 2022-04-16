using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class NotBuildableCommunity : ICommunity
    {

        private static readonly NotBuildableCommunity _instance = new NotBuildableCommunity();

        public static NotBuildableCommunity Instance
        { get { return _instance; } }

        private NotBuildableCommunity()
        {
            Owner = PlayerEnum.NotPlayer;
            IsUpgradable = false;
            IsBuildableCommunity = false;
        }

        public PlayerEnum Owner { get; set; }

        public bool IsUpgradable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentionalBuilder(PlayerEnum player) { }

        public bool IsBuildableByPlayer(PlayerEnum player) { return false; }
    }
}

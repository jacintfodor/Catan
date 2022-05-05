using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;

namespace Catan.Model.Board.Components
{
    public class BuildableCommunity : ICommunity
    {
        HashSet<PlayerEnum> _potentialBuilders = new();

        public PlayerEnum Owner => PlayerEnum.NotPlayer;

        public CommunityEnum Type => CommunityEnum.BuildableCommunity;

        public bool IsUpgradeable => false;

        public void AddPotentionalBuilder(PlayerEnum player)
        {
            _potentialBuilders.Add(player);
        }

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player)
        {
            return IsBuildableByPlayerSpecialization(state as dynamic, player);
        }

        #region IsBuildableByPlayer specializations
        private bool IsBuildableByPlayerSpecialization(ICatanGameState state, PlayerEnum player)
        {
            return _potentialBuilders.Contains(player);
        }

        private bool IsBuildableByPlayerSpecialization(EarlyRollingState state, PlayerEnum player)
        {
            return true;
        }

        private bool IsBuildableByPlayerSpecialization(EarlyRoadBuildingState state, PlayerEnum player)
        {
            return true;
        }

        private bool IsBuildableByPlayerSpecialization(EarlySettlementBuildingState state, PlayerEnum player)
        {
            return true;
        }
        #endregion
    }
}

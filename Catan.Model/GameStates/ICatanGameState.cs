namespace Catan.Model.GameStates
{
    public interface ICatanGameState
    {
        public bool IsEarlyRollingState => false;
        public bool IsEarlySettlementBuildingState => false;
        public bool IsEarlyRoadBuildingState => false;
        public bool IsRollingState => false;
        public bool IsMainState => false;
        public bool IsSettlementBuildingState => false;
        public bool IsRoadBuildingState => false;
        public bool IsSettlementUpgradingState => false;
        public bool IsWinningState => false;
        public bool IsRogueMovingState => false;
    }
}

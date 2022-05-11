namespace Catan.Model.GameStates
{
    public interface ICatanGameState
    {
        /// <summary>
        /// Is this the EarlyRollingState
        /// </summary>
        public bool IsEarlyRollingState => false;
        /// <summary>
        /// Is this the EarlySettlementBuildingState
        /// </summary>
        public bool IsEarlySettlementBuildingState => false;
        /// <summary>
        /// Is this the EarlyRoadBuildingState
        /// </summary>
        public bool IsEarlyRoadBuildingState => false;
        /// <summary>
        /// Is this the RollingState
        /// </summary>
        public bool IsRollingState => false;
        /// <summary>
        /// Is this the MainState
        /// </summary>
        public bool IsMainState => false;
        /// <summary>
        /// Is this the SettlementBuildingState
        /// </summary>
        public bool IsSettlementBuildingState => false;
        /// <summary>
        /// Is this the RoadBuildingState
        /// </summary>
        public bool IsRoadBuildingState => false;
        /// <summary>
        /// Is this the SettlementUpgradingState
        /// </summary>
        public bool IsSettlementUpgradingState => false;
        /// <summary>
        /// Is this the WinningState
        /// </summary>
        public bool IsWinningState => false;
        /// <summary>
        /// Is this the RogueMovingState
        /// </summary>
        public bool IsRogueMovingState => false;
    }
}

using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.Events.EventArguments;

namespace Catan.Model.Events
{
    public interface ICatanEvents
    {
        event EventHandler<CancelEventArgs> Cancelled;
        event EventHandler<DicesRolledEventArg> DicesRolled;
        event EventHandler<GameStartedEventArgs> GameStarted;
        event EventHandler<GameWonEventArgs> GameWon;
        event EventHandler<PlayerUpdatedEventArgs> PlayerUpdated;
        event EventHandler<RoadBuildingStartedEventArgs> RoadBuildingStarted;
        event EventHandler<RoadBuiltEventArgs> RoadBuilt;
        event EventHandler<RogueMovedEventArgs> RogueMoved;
        event EventHandler<EventArgs> RogueMovingStarted;
        event EventHandler<SettlementBuildingStartedEventArgs> SettlementBuildingStarted;
        event EventHandler<SettlementBuiltEventArgs> SettlementBuilt;
        event EventHandler<SettlementUpgradedEventArgs> SettlementUpgraded;
        event EventHandler<SettlementUpgradingStartedEventArgs> SettlementUpgradingStarted;
        event EventHandler<EventArgs> ScoreCardDrawn;
        event EventHandler<EventArgs> KnightCardDrawn;
        event EventHandler<EventArgs> LargestArmyEarned;
        event EventHandler<EventArgs> LongestRoadEarned;

        void OnScoreCardDrawn();
        void OnKnightCardDrawn();
        void OnLargestArmyEarned();
        void OnLongestRoadEarned();
        void OnDicesRolled(ICatanContext ctx);
        void OnGameStarted(ICatanContext ctx);
        void OnGameWon(ICatanContext ctx);
        void OnPlayerUpdated(ICatanContext ctx);
        void OnRoadBuildingStarted(List<EdgeDTO> edges);
        void OnRoadBuilt(ICatanContext ctx, int row, int col, PlayerEnum player);
        void OnRogueMoved(int row, int col);
        void OnRogueMovingStarted();
        void OnSettlementBuildingStarted(List<VertexDTO> vertices);
        void OnSettlementBuilt(ICatanContext ctx, int row, int col, PlayerEnum player);
        void OnSettlementUpgraded(ICatanContext ctx, int row, int col);
        void OnSettlementUpgradingStarted(List<VertexDTO> vertices);
        void OnCancelled();
    }
}
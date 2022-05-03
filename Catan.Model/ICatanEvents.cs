using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.Events;

namespace Catan.Model
{
    internal interface ICatanEvents
    {
        event EventHandler<CancelEventArgs> Cancel;
        event EventHandler<DicesThrownEventArg> DicesThrown;
        event EventHandler<GameStartEventArgs> GameStart;
        event EventHandler<PlayerEventArgs> Player;
        event EventHandler<RoadBuildingStartedEventArgs> RoadBuildingStarted;
        event EventHandler<RoadBuiltEventArgs> RoadBuilt;
        event EventHandler<RogueMovedEventArgs> RogueMoved;
        event EventHandler<EventArgs> RogueMovingStarted;
        event EventHandler<SettlementBuildingStartedEventArgs> SettlementBuildingStarted;
        event EventHandler<SettlementBuiltEventArgs> SettlementBuilt;
        event EventHandler<SettlementUpgradedEventArgs> SettlementUpgraded;
        event EventHandler<SettlementUpgradingStartedEventArgs> SettlementUpgradingStarted;

        void OnDiceThrown(ICatanContext ctx);
        void OnGameStart(ICatanContext ctx);
        void OnPlayer(ICatanContext ctx);
        void OnRoadBuildingStarted(List<IEdge> edges);
        void OnRoadBuilt(ICatanContext ctx, int row, int col, PlayerEnum player);
        void OnRogueMoved(int row, int col);
        void OnRogueMovingStarted();
        void OnSettlementBuildingStarted(List<IVertex> vertices);
        void OnSettlementBuilt(ICatanContext ctx, int row, int col, PlayerEnum player);
        void OnSettlementUpgraded(ICatanContext ctx, int row, int col);
        void OnSettlementUpgradingStarted(List<IVertex> vertices);
    }
}
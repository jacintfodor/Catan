using Catan.Model.Board;
using Catan.Model.Board.Components;
using Catan.Model.Context;
using Catan.Model.Context.Titles;
using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model
{
    public interface ICatanContext
    {
        ICatanBoard Board { get; }
        IPlayer CurrentPlayer { get; }
        ICatanEvents Events { get; }
        ICubeDice FirstDice { get; }
        bool IsEarlyRoadBuildingState { get; }
        bool IsEarlyRollingState { get; }
        bool IsEarlySettlementBuildingState { get; }
        bool IsMainState { get; }
        bool IsRoadBuildingState { get; }
        bool IsRogueMovingState { get; }
        bool IsRollingState { get; }
        bool IsSettlementBuildingState { get; }
        bool IsSettlementUpgradingState { get; }
        bool IsWinningState { get; }
        ITitle LargestArmyHolder { get; }
        ITitle LongestRoadOwner { get; }
        IPlayer NextNextPlayerInQueue { get; }
        IPlayer NextPlayerInQueue { get; }
        Rogue Rogue { get; }
        int RolledSum { get; }
        ICubeDice SecondDice { get; }
        IPlayer Winner { get; }

        public ICatanGameState State { get; set; }
        void AcceptTrade();
        void BuildRoad(int row, int col);
        void BuildSettleMent(int row, int col);
        void Cancel();
        void clear();
        void DenyTrade();
        void DistributeResources(int dieValue, bool isEarly = false);
        void EndTurn();
        void ExchangeWithBank(ResourceEnum from, ResourceEnum to);
        List<IPlayer> GetPlayerList();
        void init();
        bool IsAffordable(Goods g);
        void MakeOffer();
        void MoveRogue(int row, int col);
        void NewGame();
        void NextPlayer();
        void PurchaseBonusCard();
        void reset();
        void RollDices();
        void SetContext(ICatanGameState state);
        void StartRoadBuilding();
        void StartSettlementBuilding();
        void StartSettlementUpgrading();
        void StartTrade();
        void UpgradeSettleMentToTown(int row, int col);
    }
}
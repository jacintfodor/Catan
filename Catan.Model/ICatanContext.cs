using Catan.Model.Board;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.Events;
using Catan.Model.DTOs;

namespace Catan.Model
{
    public interface ICatanContext
    {
        /// <summary>
        /// Get the board
        /// </summary>
        ICatanBoard Board { get; }
        /// <summary>
        /// Get the current player
        /// </summary>
        IPlayer CurrentPlayer { get; }
        /// <summary>
        /// Get the events
        /// </summary>
        ICatanEvents Events { get; }
        /// <summary>
        /// Get the first dice
        /// </summary>
        ICubeDice FirstDice { get; }
        /// <summary>
        /// Is this the EarlyRoadBuildingState?
        /// </summary>
        bool IsEarlyRoadBuildingState { get; }
        /// <summary>
        /// Is this the EarlyRollingState?
        /// </summary>
        bool IsEarlyRollingState { get; }
        /// <summary>
        /// Is this the EarlySettlementBuildingState?
        /// </summary>
        bool IsEarlySettlementBuildingState { get; }
        /// <summary>
        /// Is this the MainState?
        /// </summary>
        bool IsMainState { get; }
        /// <summary>
        /// Is this the RoadBuildingState?
        /// </summary>
        bool IsRoadBuildingState { get; }
        /// <summary>
        /// Is this the RogueMovingState?
        /// </summary>
        bool IsRogueMovingState { get; }
        /// <summary>
        /// Is this the RollingState?
        /// </summary>
        bool IsRollingState { get; }
        /// <summary>
        /// Is this the SettlementBuildingState?
        /// </summary>
        bool IsSettlementBuildingState { get; }
        /// <summary>
        /// Is this the SettlementUpgradingState?
        /// </summary>
        bool IsSettlementUpgradingState { get; }
        /// <summary>
        /// Is this the WinningState?
        /// </summary>
        bool IsWinningState { get; }
        /// <summary>
        /// Get teh LargestArmyHolder
        /// </summary>
        ITitle LargestArmyHolder { get; }
        /// <summary>
        /// Get the LongestRoadOwner
        /// </summary>
        ITitle LongestRoadOwner { get; }
        /// <summary>
        /// Get the NextNextPlayerInQueue 
        /// </summary>
        IPlayer NextNextPlayerInQueue { get; }
        /// <summary>
        /// Get the NextPlayerInQueue
        /// </summary>
        IPlayer NextPlayerInQueue { get; }
        /// <summary>
        /// Get the Rogue
        /// </summary>
        IRogue Rogue { get; }
        /// <summary>
        /// Get the Rolled sum of dices
        /// </summary>
        int RolledSum { get; }
        /// <summary>
        /// Get the second dice
        /// </summary>
        ICubeDice SecondDice { get; }
        /// <summary>
        /// Get the winner
        /// </summary>
        IPlayer Winner { get; }

        /// <summary>
        /// Get or Set the state
        /// </summary>
        public ICatanGameState State { get; set; }
        /// <summary>
        /// Accept the trade
        /// </summary>
        void AcceptTrade();
        /// <summary>
        /// Build the road
        /// </summary>
        /// <param name="row">The row to build</param>
        /// <param name="col">The column to build</param>
        void BuildRoad(int row, int col);
        /// <summary>
        /// Build the settlement
        /// </summary>
        /// <param name="row">The row to build</param>
        /// <param name="col">The column to build</param>
        void BuildSettleMent(int row, int col);
        /// <summary>
        /// Cannel
        /// </summary>
        void Cancel();
        /// <summary>
        /// Clear the players
        /// </summary>
        void clear();
        void DenyTrade();
        /// <summary>
        /// Distribute the resources they deserve
        /// </summary>
        /// <param name="state"></param>
        void DistributeResources(ICatanGameState state);
        /// <summary>
        /// End the turn
        /// </summary>
        void EndTurn();
        /// <summary>
        /// Exchange with the bank 3 to 1
        /// </summary>
        /// <param name="from">What are you changing</param>
        /// <param name="to">What do you get</param>
        void ExchangeWithBank(ResourceEnum from, ResourceEnum to);
        /// <summary>
        /// Get players list
        /// </summary>
        /// <returns>List<PlayerDTO></returns>
        List<PlayerDTO> GetPlayerList();
        /// <summary>
        /// Initializating CatanBoard, Rogue, Dices, Players
        /// </summary>
        void init();
        /// <summary>
        /// is it afforable?
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        bool IsAffordable(Goods g);
        void MakeOffer();
        /// <summary>
        /// Move rogue
        /// </summary>
        /// <param name="row">The row to move</param>
        /// <param name="col">The column to move</param>
        void MoveRogue(int row, int col);
        /// <summary>
        /// OnGameStarted event
        /// </summary>
        void NewGame();
        /// <summary>
        /// Switches to the next player
        /// </summary>
        void NextPlayer();
        /// <summary>
        /// buy a bonus card
        /// </summary>
        void PurchaseBonusCard();
        /// <summary>
        /// Clear and init
        /// </summary>
        void reset();
        /// <summary>
        /// Roll the dices
        /// </summary>
        void RollDices();
        /// <summary>
        /// Tet context
        /// </summary>
        /// <param name="state"></param>
        void SetContext(ICatanGameState state);
        /// <summary>
        /// Start building a road
        /// </summary>
        void StartRoadBuilding();
        /// <summary>
        /// Start building a settlement
        /// </summary>
        void StartSettlementBuilding();
        /// <summary>
        /// Start uppgrading a settlment
        /// </summary>
        void StartSettlementUpgrading();
        /// <summary>
        /// Start trading
        /// </summary>
        void StartTrade();
        /// <summary>
        /// Uppgrade the settlement to a town
        /// </summary>
        /// <param name="row">The row to build</param>
        /// <param name="col">The column to build</param>
        void UpgradeSettleMentToTown(int row, int col);
    }
}

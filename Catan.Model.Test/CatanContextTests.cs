using Catan.Model;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Catan.Model.Board.Components.Hex;
using System.Linq;
using Catan.Model.Board;
using Catan.Model.Events;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.Test
{
    [TestClass]
    public class CatanContextTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanGameState> mockCatanGameState;
        private Mock<ICatanBoard> mockBoard;
        private Mock<ICubeDice> mockFirstDice;
        private Mock<ICubeDice> mockSecondDice;
        private Mock<IRogue> mockRogue;
        private Mock<ICatanEvents> mockEvents;
        private Mock<ITitle> mockLargestArmy;
        private Mock<ITitle> mockLongestRoad;
        private Mock<IPlayer> mockPlayerOne;
        private Mock<IPlayer> mockPlayerTwo;
        private Mock<IPlayer> mockPlayerThree;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockCatanGameState = this.mockRepository.Create<ICatanGameState>();

            this.mockBoard = this.mockRepository.Create<ICatanBoard>();

            this.mockFirstDice = this.mockRepository.Create<ICubeDice>();
            this.mockSecondDice = this.mockRepository.Create<ICubeDice>();

            this.mockRogue = this.mockRepository.Create<IRogue>();

            this.mockEvents = this.mockRepository.Create<ICatanEvents>();

            this.mockLargestArmy = this.mockRepository.Create<ITitle>();
            this.mockLongestRoad = this.mockRepository.Create<ITitle>();

            this.mockPlayerOne = this.mockRepository.Create<IPlayer>();
            this.mockPlayerTwo = this.mockRepository.Create<IPlayer>();
            this.mockPlayerThree = this.mockRepository.Create<IPlayer>();
        }

        private CatanContext CreateCatanContext()
        {
            return new CatanContext(
                this.mockCatanGameState.Object,
                this.mockBoard.Object,
                this.mockFirstDice.Object,
                this.mockSecondDice.Object,
                this.mockRogue.Object,
                this.mockEvents.Object,
                this.mockLargestArmy.Object,
                this.mockLongestRoad.Object,
                this.mockPlayerOne.Object,
                this.mockPlayerTwo.Object,
                this.mockPlayerThree.Object);
        }
        [TestMethod]
        public void EndTurn_ValidStateCall_EndTurnInvoked()
        {
            //Arrange
            var catanContext = this.CreateCatanContext();
            var mainState = new Mock<ICatanGameState>();
            mainState.As<IMainState>().Setup(m => m.EndTurn(catanContext)).Verifiable();
            catanContext.SetContext(mainState.Object);

            //Act
            catanContext.EndTurn();

            //Assert
            mainState.As<IMainState>().Verify(m => m.EndTurn(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void RollDices_ValidStateCall_RollDicesInvoked()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var rollableState = new Mock<ICatanGameState>();
            rollableState.As<IRollable>().Setup(m => m.RollDices(catanContext)).Verifiable();
            catanContext.SetContext(rollableState.Object);
            // Act
            catanContext.RollDices();

            // Assert
            rollableState.As<IRollable>().Verify(m => m.RollDices(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void MoveRogue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var rogueMovingState = new Mock<ICatanGameState>();
            int row = 0;
            int col = 0;
            rogueMovingState.As<IRogueMovable>().Setup(m => m.MoveRogue(catanContext, row, col)).Verifiable();
            catanContext.SetContext(rogueMovingState.Object);

            // Act
            catanContext.MoveRogue(
                row,
                col);

            // Assert
            rogueMovingState.As<IRogueMovable>().Verify(m => m.MoveRogue(catanContext, row, col), Times.Once);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ExchangeWithBank_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var mainState = new Mock<ICatanGameState>();

            ResourceEnum from = default(global::Catan.Model.Enums.ResourceEnum);
            ResourceEnum to = default(global::Catan.Model.Enums.ResourceEnum);
            mainState.As<IMainState>().Setup(m => m.ExchangeWithBank(catanContext, from, to)).Verifiable();
            catanContext.SetContext(mainState.Object);
            // Act
            catanContext.ExchangeWithBank(
                from,
                to);

            // Assert
            mainState.As<IMainState>().Verify(m => m.ExchangeWithBank(catanContext, from, to), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void PurchaseBonusCard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var mainState = new Mock<ICatanGameState>();
            mainState.As<IMainState>().Setup(m => m.PurchaseBonusCard(catanContext)).Verifiable();
            catanContext.SetContext(mainState.Object);
            // Act
            catanContext.PurchaseBonusCard();

            // Assert
            mainState.As<IMainState>().Verify(m => m.PurchaseBonusCard(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void StartRoadBuilding_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var mainState = new Mock<ICatanGameState>();
            mainState.As<IMainState>().Setup(m => m.StartRoadBuilding(catanContext)).Verifiable();
            catanContext.SetContext(mainState.Object);

            // Act
            catanContext.StartRoadBuilding();

            // Assert
            mainState.As<IMainState>().Verify(m => m.StartRoadBuilding(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void BuildRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var roadBuildingState = new Mock<ICatanGameState>();
            int row = 0;
            int col = 0;
            roadBuildingState.As<IRoadBuildable>().Setup(m => m.BuildRoad(catanContext, row, col)).Verifiable();
            catanContext.SetContext(roadBuildingState.Object);

            // Act
            catanContext.BuildRoad(row, col);

            // Assert
            roadBuildingState.As<IRoadBuildable>().Verify(m => m.BuildRoad(catanContext, row, col), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void StartSettlementBuilding_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var mainState = new Mock<ICatanGameState>();
            mainState.As<IMainState>().Setup(m => m.StartSettlementBuilding(catanContext)).Verifiable();
            catanContext.SetContext(mainState.Object);
            // Act
            catanContext.StartSettlementBuilding();

            // Assert
            mainState.As<IMainState>().Verify(m => m.StartSettlementBuilding(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void BuildSettleMent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var settlementBuildingState = new Mock<ICatanGameState>();
            int row = 0;
            int col = 0;
            settlementBuildingState.As<ISettlementBuildable>().Setup(m => m.BuildSettleMent(catanContext, row, col)).Verifiable();
            catanContext.SetContext(settlementBuildingState.Object);

            // Act
            catanContext.BuildSettleMent(row, col);

            // Assert
            settlementBuildingState.As<ISettlementBuildable>().Verify(m => m.BuildSettleMent(catanContext, row, col), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void StartSettlementUpgrading_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var mainState = new Mock<ICatanGameState>();
            mainState.As<IMainState>().Setup(m => m.StartSettlementUpgrading(catanContext)).Verifiable();
            catanContext.SetContext(mainState.Object);
            // Act
            catanContext.StartSettlementUpgrading();

            // Assert
            mainState.As<IMainState>().Verify(m => m.StartSettlementUpgrading(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void UpgradeSettleMentToTown_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var settlementUpgradingState = new Mock<ICatanGameState>();
            int row = 0;
            int col = 0;
            settlementUpgradingState.As<ISettlementUpgradeable>().Setup(m => m.UpgradeSettleMentToTown(catanContext, row, col)).Verifiable();
            catanContext.SetContext(settlementUpgradingState.Object);

            // Act
            catanContext.UpgradeSettleMentToTown(row, col);

            // Assert
            settlementUpgradingState.As<ISettlementUpgradeable>().Verify(m => m.UpgradeSettleMentToTown(catanContext, row, col), Times.Once);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void Cancel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var catanContext = this.CreateCatanContext();
            var cancelState = new Mock<ICatanGameState>();
            cancelState.As<ICancellable>().Setup(m => m.Cancel(catanContext)).Verifiable();
            catanContext.SetContext(cancelState.Object);
            // Act
            catanContext.Cancel();

            // Assert
            cancelState.As<ICancellable>().Verify(m => m.Cancel(catanContext), Times.Once);
            this.mockRepository.VerifyAll();
        }

    }
}

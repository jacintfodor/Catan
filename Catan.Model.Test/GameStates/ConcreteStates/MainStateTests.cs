using Catan.Model.Board.Components;
using Catan.Model.Board.Components.Edge;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Context;
using Catan.Model.Context.Players;
using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class MainStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;
        private Mock<IPlayer> mockPlayer;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = mockRepository.Create<ICatanContext>();
            this.mockPlayer = mockRepository.Create<IPlayer>();

        }

        private MainState CreateMainState()
        {
            return new MainState();
        }

        [TestMethod]
        public void EndTurn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.Winner).Returns(NotPlayer.Instance).Verifiable();
            this.mockContext.Setup(m => m.NextPlayer()).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<RollingState>())).Verifiable();


            // Act
            (mainState as IMainState)?.EndTurn(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void EndTurn_GameWon_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;
            IPlayer player = this.mockPlayer.Object;

            this.mockContext.Setup(m => m.Winner).Returns(player).Verifiable();
            this.mockContext.Setup(m => m.CurrentPlayer).Returns(player).Verifiable();
            this.mockContext.Setup(m => m.Events.OnGameWon(context)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<GameWonState>())).Verifiable();


            // Act
            (mainState as IMainState)?.EndTurn(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(ResourceEnum.Ore, ResourceEnum.Brick)]
        [DataRow(ResourceEnum.Wood, ResourceEnum.Brick)]
        [DataRow(ResourceEnum.Crop, ResourceEnum.Wool)]
        public void ExchangeWithBank_StateUnderTest_ExpectedBehavior(ResourceEnum from, ResourceEnum to)
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;


            this.mockContext.Setup(m => m.CurrentPlayer.ReduceResources(It.IsAny<Goods>())).Verifiable();
            this.mockContext.Setup(m => m.CurrentPlayer.AddResource(It.IsAny<Goods>())).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            // Act
            var o = mainState as IMainState;
            o?.ExchangeWithBank(
                context,
                from,
                to);

            // Assert
            this.mockContext.Verify();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PurchaseBonusCard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.CurrentPlayer.PurchaseBonusCard(Constants.BonusCardCost)).Verifiable();
            this.mockContext.Setup(m => m.CurrentPlayer.ReduceResources(Constants.BonusCardCost)).Verifiable();
            this.mockContext.Setup(m => m.LargestArmyHolder.ProcessOwner(context.CurrentPlayer)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();

            // Act
            (mainState as IMainState).PurchaseBonusCard(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1)]
        public void StartRoadBuilding_StateUnderTest_ExpectedBehavior(PlayerEnum player)
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(player);
            var list = new List<IEdge>() { new Edge(1, 2) };
            list[0].AddPotentialBuilder(player);
            this.mockContext.Setup(m =>
                m.Board.GetBuildableRoadsByPlayer(player))
                .Returns(list);
            var listDTO = list.Select(x => Mapping.Mapper.Map<EdgeDTO>(x)).ToList();

            this.mockContext.Setup(m => m.Events.OnRoadBuildingStarted(listDTO)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<RoadBuildingState>())).Verifiable();


            // Act
            var o = mainState as IMainState;
            o?.StartRoadBuilding(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1)]
        public void StartSettlementBuilding_StateUnderTest_ExpectedBehavior(PlayerEnum player)
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(player);
            this.mockContext.Setup(m => m.State).Returns(mainState);
            var list = new List<IVertex>() { new Vertex(1, 2) };
            list[0].AddPotentialBuilder(player);
            this.mockContext.Setup(m =>
                m.Board.GetBuildableSettlementsByPlayer(mainState, player))
                .Returns(list);
            var listDTO = list.Select(x => Mapping.Mapper.Map<VertexDTO>(x)).ToList();

            this.mockContext.Setup(m => m.Events.OnSettlementBuildingStarted(listDTO)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<SettlementBuildingState>())).Verifiable();

            // Act
            var o = mainState as IMainState;
            o.StartSettlementBuilding(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1)]
        public void StartSettlementUpgrading_StateUnderTest_ExpectedBehavior(PlayerEnum player)
        {
            // Arrange
            ICatanGameState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(player);
            var list = new List<IVertex>() { new Vertex(1, 2, new Settlement(player)) };
            this.mockContext.Setup(m =>
                m.Board.GetUpgradeableSettlementsByPlayer(player))
                .Returns(list);
            var listDTO = list.Select(x => Mapping.Mapper.Map<VertexDTO>(x)).ToList();

            this.mockContext.Setup(m => m.Events.OnSettlementUpgradingStarted(listDTO)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<SettlementUpgradingState>())).Verifiable();

            // Act
            var o = mainState as IMainState;
            o?.StartSettlementUpgrading(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}

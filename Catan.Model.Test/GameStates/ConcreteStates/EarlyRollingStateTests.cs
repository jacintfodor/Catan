using Catan.Model.Board.Components.Vertex;
using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class EarlyRollingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockContext = this.mockRepository.Create<ICatanContext>();
        }

        private EarlyRollingState CreateEarlyRollingState()
        {
            return new EarlyRollingState();
        }

        [TestMethod]
        public void RollDices_CallOnce_DoesNotChangeState()
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(m => m.SecondDice.roll()).Verifiable();
            
            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(PlayerEnum.Player1);
            this.mockContext.Setup(m => m.RolledSum).Returns(12);

            this.mockContext.Setup(m => m.NextPlayer()).Verifiable();
            
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnDicesRolled(context)).Verifiable();


            // Act
            var o = state as IRollable;
            o?.RollDices(context);

            // Assert
            Assert.IsNotNull(o);

            this.mockContext.Verify(m => m.SetContext(It.IsAny<EarlySettlementBuildingState>()), Times.Never);
            this.mockRepository.VerifyAll();
        }

        [DataTestMethod]
        [DataRow(12, 7, 6, 3, PlayerEnum.Player1)]
        [DataRow(2, 2, 2, 3, PlayerEnum.Player1)]
        [DataRow(12, 12, 12, 3, PlayerEnum.Player1)]
        [DataRow(7, 7, 7, 3, PlayerEnum.Player1)]
        [DataRow(3, 11, 12, 5, PlayerEnum.Player3)]
        [DataRow(3, 12, 5, 4, PlayerEnum.Player2)]
        [DataRow(3, 12, 12, 4, PlayerEnum.Player2)]
        public void RollDices_CallThrice_ChangesStateToEarlyBuildingState(int rollP1, int rollP2, int rollP3, int noOfTimesNexptlayerCalled, PlayerEnum expectedStarterPlayer)
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(m => m.SecondDice.roll()).Verifiable();

            this.mockContext.SetupSequence(m => m.CurrentPlayer.ID)
                .Returns(PlayerEnum.Player1)
                .Returns(PlayerEnum.Player2)
                .Returns(PlayerEnum.Player3)
                .Returns(expectedStarterPlayer);

            this.mockContext.SetupSequence(m => m.RolledSum)
                .Returns(rollP1)
                .Returns(rollP2)
                .Returns(rollP3);

            this.mockContext.Setup(m => m.NextPlayer()).Verifiable();

            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnDicesRolled(context)).Verifiable();

            var list = new List<IVertex>() { new Vertex(1, 2) };
            this.mockContext.Setup(m => 
                m.Board.GetBuildableSettlementsByPlayer(state, expectedStarterPlayer))
                .Returns(list);

            var listDTO = list.Select(x => Mapping.Mapper.Map<VertexDTO>(x)).ToList();

            this.mockContext.Setup(m => m.Events.OnSettlementBuildingStarted(listDTO)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<EarlySettlementBuildingState>())).Verifiable();

            // Act
            var o = state as IRollable;
            o?.RollDices(context);
            o?.RollDices(context);
            o?.RollDices(context);

            // Assert
            Assert.IsNotNull(o);

            this.mockContext.Verify(m => m.NextPlayer(), Times.Exactly(noOfTimesNexptlayerCalled));
            this.mockContext.Verify(m => m.SetContext(It.IsAny<EarlySettlementBuildingState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}

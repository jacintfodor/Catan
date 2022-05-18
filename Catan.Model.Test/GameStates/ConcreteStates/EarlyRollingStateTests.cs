using Catan.Model.Board;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Context;
using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.Events;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    public class EarlyRollingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;
        private Mock<ICatanEvents> mockEvents;
        private Mock<ICubeDice> mockDice;
        private Mock<ICatanBoard> mockBoard;

        public EarlyRollingStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = this.mockRepository.Create<ICatanContext>();
            this.mockEvents = this.mockRepository.Create<ICatanEvents>();
            this.mockDice = this.mockRepository.Create<ICubeDice>();
            this.mockBoard = this.mockRepository.Create<ICatanBoard>();

            this.mockContext.Setup(x => x.Events).Returns(this.mockEvents.Object);
            this.mockContext.Setup(x => x.FirstDice).Returns(this.mockDice.Object);
            this.mockContext.Setup(x => x.SecondDice).Returns(this.mockDice.Object);
        }

        private EarlyRollingState CreateEarlyRollingState()
        {
            return new EarlyRollingState();
        }

        [Fact]
        public void RollDices_RollOnce_DoesNotChangeState()
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(x => x.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(x => x.SecondDice.roll()).Verifiable();

            this.mockContext.SetupGet(x => x.RolledSum).Returns(12).Verifiable();
            this.mockContext.SetupGet(x => x.CurrentPlayer.ID).Returns(PlayerEnum.Player1).Verifiable();
            this.mockContext.SetupSet(x => x.CurrentPlayer.FirstRoll=12).Verifiable();
            
            this.mockContext.Setup(x => x.NextPlayer()).Verifiable();
            
            this.mockContext.Setup(x => x.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(x => x.Events.OnDicesRolled(context)).Verifiable();

            // Act
            var o = state as IRollable;
            o?.RollDices(context);

            // Assert
            Assert.NotNull(o);
            this.mockRepository.VerifyAll();
        }

        [Theory]
        [InlineData(12, 6, 3, 3, PlayerEnum.Player1)]
        [InlineData(12, 12, 3, 3, PlayerEnum.Player1)]
        [InlineData(12, 12, 12, 3, PlayerEnum.Player1)]
        [InlineData(7, 11, 3, 4, PlayerEnum.Player2)]
        [InlineData(7, 11, 11, 4, PlayerEnum.Player2)]
        [InlineData(7, 2, 10, 5, PlayerEnum.Player3)]
        public void RollDices_RollThrice_DoesChangeState(
            int firstRollSum, 
            int secondRollSum, 
            int thirdRollSum, 
            int expectedNoOfNextPlayerInvocations, 
            PlayerEnum expectedStarter)
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRollingState();

            this.mockContext.Setup(x => x.Events.OnSettlementBuildingStarted(It.IsAny<List<VertexDTO>>()));
            this.mockContext.SetupGet(x => x.Board).Returns(this.mockBoard.Object);

            var list = new List<IVertex>();
            this.mockContext.Setup(x => x.Board.GetBuildableSettlementsByPlayer(state, expectedStarter))
                .Returns(list);

            this.mockContext.SetupSequence(x => x.CurrentPlayer.ID)
                .Returns(PlayerEnum.Player1)    //before if
                .Returns(PlayerEnum.Player2)    //before if
                .Returns(PlayerEnum.Player3)    //before if
                .Returns(expectedStarter);   //inside if, expected winner

            this.mockContext.SetupSequence(x => x.RolledSum)
                .Returns(firstRollSum)
                .Returns(secondRollSum)
                .Returns(thirdRollSum);

            ICatanContext context = this.mockContext.Object;

            // Act
            var o = state as IRollable;
            o?.RollDices(context);
            o?.RollDices(context);
            o?.RollDices(context);

            // Assert
            Assert.NotNull(o);

            this.mockContext.Verify(x => x.NextPlayer(), Times.Exactly(expectedNoOfNextPlayerInvocations));
            this.mockContext.Verify(x => x.SetContext(It.IsAny<EarlySettlementBuildingState>()));

            this.mockRepository.VerifyAll();
        }
    }
}

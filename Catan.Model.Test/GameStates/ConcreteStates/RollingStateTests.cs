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
    public class RollingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;
        private Mock<ICatanGameState> mockState;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = this.mockRepository.Create<ICatanContext>();
            this.mockState = this.mockRepository.Create<ICatanGameState>();
        }

        private RollingState CreateRollingState()
        {
            return new RollingState();
        }

        [TestMethod]
        public void RollDices_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            RollingState rollingState = this.CreateRollingState();
            ICatanGameState state = this.mockState.Object;
            ICatanContext context = new CatanContext(state);

            // Act
            rollingState.RollDices(context);

            Assert.IsTrue(context.IsMainState || context.IsRogueMovingState);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RollDices_CallOnceThrow7_ChangesStateToRogueMovingState()
        {
            // Arrange
            ICatanGameState state = this.CreateRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(m => m.SecondDice.roll()).Verifiable();

            this.mockContext.Setup(m => m.DistributeResources(state)).Verifiable();

            this.mockContext.Setup(m => m.Events.OnDicesRolled(context)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();

            this.mockContext.Setup(m => m.RolledSum).Returns(7);

            this.mockContext.Setup(m => m.SetContext(It.IsAny<RogueMovingState>())).Verifiable();
            this.mockContext.Setup(m => m.Events.OnRogueMovingStarted()).Verifiable();

            //this.mockContext.Setup(m => m.SetContext(It.IsAny<MainState>())).Verifiable();
            // Act
            var o = state as IRollable;
            o?.RollDices(context);

            // Assert
            this.mockContext.Verify(m => m.SetContext(It.IsAny<RogueMovingState>()));
            this.mockContext.Verify(m => m.SetContext(It.IsAny<MainState>()), Times.Never);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(11)]
        [DataRow(12)]
        public void RollDices_CallOnceThrowNot7_ChangesStateToMainState(int num)
        {
            // Arrange
            ICatanGameState state = this.CreateRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(m => m.SecondDice.roll()).Verifiable();

            this.mockContext.Setup(m => m.DistributeResources(state)).Verifiable();

            this.mockContext.Setup(m => m.Events.OnDicesRolled(context)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();

            this.mockContext.Setup(m => m.RolledSum).Returns(num);

            this.mockContext.Setup(m => m.SetContext(It.IsAny<MainState>())).Verifiable();
            // Act
            var o = state as IRollable;
            o?.RollDices(context);

            // Assert
            this.mockContext.Verify(m => m.SetContext(It.IsAny<RogueMovingState>()), Times.Never);
            this.mockContext.Verify(m => m.SetContext(It.IsAny<MainState>()));
            this.mockRepository.VerifyAll();
        }
    }
}

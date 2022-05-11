using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class RogueMovingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;
        private Mock<ICatanGameState> mockState;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockContext = this.mockRepository.Create<ICatanContext>();
            this.mockState = this.mockRepository.Create<ICatanGameState>();
        }

        private RogueMovingState CreateRogueMovingState()
        {
            return new RogueMovingState();
        }

        [TestMethod]
        public void Cancel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICancellable rogueMovingState = this.CreateRogueMovingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.Events.OnCancelled()).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<MainState>())).Verifiable();

            // Act
            rogueMovingState.Cancel(context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 4)]
        [DataRow(5, 5)]
        [DataRow(1, 2)]
        [DataRow(3, 2)]
        public void MoveRogue_StateUnderTest_ExpectedBehavior(int r, int c)
        {
            // Arrange
            IRogueMovable rogueMovingState = this.CreateRogueMovingState();
            ICatanGameState state = this.mockState.Object;
            ICatanContext context = new CatanContext(state);
            int row = r;
            int col = c;
            context.Rogue.Move(row, col);
            context.Events.OnRogueMoved(row, col);
            context.SetContext(new MainState());

            // Act
            rogueMovingState.MoveRogue(context, row, col);

            // Assert
            Assert.IsTrue(context.Rogue.Row == row && context.Rogue.Col == col);
            this.mockRepository.VerifyAll();
        }
    }
}

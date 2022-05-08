using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class SettlementUpgradingStateTests
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

        private SettlementUpgradingState CreateSettlementUpgradingState()
        {
            return new SettlementUpgradingState();
        }

        [TestMethod]
        public void Cancel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICancellable settlementUpgradingState = this.CreateSettlementUpgradingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.Events.OnCancelled()).Verifiable();
           
            // Act
            settlementUpgradingState.Cancel(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpgradeSettleMentToTown_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ISettlementUpgradeable settlementUpgradingState = this.CreateSettlementUpgradingState();
            ICatanGameState state = this.mockState.Object;
            ICatanContext context = new CatanContext(state);
            int row = 2;
            int col = 2;

            context.Board.GetVerticesEnumerable().First(v => v.Col == 2 && v.Row == 2).AddPotentialBuilder(context.CurrentPlayer.ID);
            context.Board.BuildSettlement(row, col, state, context.CurrentPlayer.ID);

            // Act
            settlementUpgradingState.UpgradeSettleMentToTown(
                context,
                row,
                col);

            // Assert
            Assert.IsTrue(context.Board.GetVerticesEnumerable().First(v => v.Col == 2 && v.Row == 2).Type == CommunityEnum.Town);
            this.mockRepository.VerifyAll();
        }
    }
}

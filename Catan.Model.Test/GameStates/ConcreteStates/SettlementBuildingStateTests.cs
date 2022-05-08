using Catan.Model.Board;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class SettlementBuildingStateTests
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

        private SettlementBuildingState CreateSettlementBuildingState()
        {
            return new SettlementBuildingState();
        }

        [TestMethod]
        public void BuildSettleMent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ISettlementBuildable settlementUpgradingState = this.CreateSettlementBuildingState();
            ICatanGameState state = this.mockState.Object;
            ICatanContext context = new CatanContext(state);
            int row = 2;
            int col = 2;

            context.Board.GetVerticesEnumerable().First(v => v.Col == 2 && v.Row == 2).AddPotentialBuilder(context.CurrentPlayer.ID);


           
            // Act
            settlementUpgradingState.BuildSettleMent(
                context,
                row,
                col);

            // Assert
            Assert.IsTrue(context.Board.GetVerticesEnumerable().First(v => v.Col == 2 && v.Row == 2).Type == CommunityEnum.Settlement);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Cancel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICancellable settlementBuildinState = this.CreateSettlementBuildingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.Events.OnCancelled()).Verifiable();

            // Act
            settlementBuildinState.Cancel(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
